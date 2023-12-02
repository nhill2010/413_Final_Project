using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.PackageManager;
using UnityEngine;


/*
 * Health Bar:
 *   value between 0 and 1
 *   when value is changed, the health bar fill's position will
 *   match to fit the ratio value
 * Position of fill is left-aligned
 *   no other alignments available currently
 */
public class HealthBar : MonoBehaviour
{
    private float _value;
    private GameObject fgGO;
    private GameObject bgGO;

    public float value
    {
        get
        {
            return _value;
        }
        set
        {
            // set the value, realign
            _value = value;
            Realign();
            Recolor();
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Transform child in this.transform)
        {
            GameObject obj = child.gameObject;
            if (obj.name == "Foreground")
            {
                fgGO = obj;
            }
            else if (obj.name == "Background")
            {
                bgGO = obj;
            }
        }
        if( fgGO == null || bgGO == null )
        {
            Destroy(this.gameObject);
            throw new Exception("Background or Foreground not found in Healthbar's children");
        }

        // start at full value
        value = 1; // start at 1 (default)
    }

    private void Realign()
    {
        float fillRatio = value;
        // set between 0 and 1
        if (value < 0)
        {
            fillRatio = 0;
        }
        else if (value > 1)
        {
            fillRatio = 1;
        }

        Vector3 fgPos = fgGO.gameObject.transform.position;
        Vector3 bgPos = bgGO.gameObject.transform.position;
        Vector3 fgScale = fgGO.gameObject.transform.localScale;
        Vector3 bgScale = bgGO.gameObject.transform.localScale;
        // calculate assuming values in scale are directly proportional to position
        // ERROR: positioning bug when scale of parent.x is not 1. 
        fgScale.x = bgScale.x * fillRatio;
        fgPos.x = bgPos.x - bgScale.x * ( 1 - fillRatio ) / 2;
        fgGO.gameObject.transform.localScale = fgScale;
        fgGO.gameObject.transform.position = fgPos;
    }

    private void Recolor()
    {
        Color color = fgGO.GetComponent<Renderer>().material.color;
        // red, green, blue
        // scale red from 0 to 1, 
        // scale green from 1 to 0
        color.b = 0;
        color.g = value;
        color.r = 1 - value;
        fgGO.GetComponent<Renderer>().material.color = color;
    }
}
