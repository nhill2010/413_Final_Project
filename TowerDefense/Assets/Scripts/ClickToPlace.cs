using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace LP.ClickToPlace
{

    public class ClickToPlace : MonoBehaviour
    {
        [ SerializeField ] GameObject objToSpawn = null;
        private Camera cam = null;
        private int h1Amt, h2Amt, h3Amt, heroAmt;
        public GameObject h1Obj, h2Obj, h3Obj;
        private heroType hType;

        private void Start()
        {
            cam = Camera.main;
            h1Amt = PlayerPrefs.GetInt( "Hero1Inventory" );
            h2Amt = PlayerPrefs.GetInt( "Hero2Inventory" );
            h3Amt = PlayerPrefs.GetInt( "Hero3Inventory" );
        }

        private void Update()
        {
            SpawnAtMousePos();
        }

        public void SetHero( string type )
        {
            switch( type ) {
                case "hero1":
                    heroAmt = h1Amt;
                    objToSpawn = h1Obj;
                    hType = heroType.hero1;
                    break;
                case "hero2":
                    heroAmt = h2Amt;
                    objToSpawn = h2Obj;
                    hType = heroType.hero2;
                    break;
                case "hero3":
                    heroAmt = h3Amt;
                    objToSpawn = h3Obj;
                    hType = heroType.hero3;
                    break;
            }
        }

        // Function SpawnAtMousePos:
        // responsible for spawning hero objects on mouse
        // click at current mouse position
        private void SpawnAtMousePos()
        {
            // this line prevents player from placing objects under UI elements
            if ( EventSystem.current.IsPointerOverGameObject()) return;

            if ( Mouse.current.leftButton.wasPressedThisFrame )
            {
                Ray ray = cam.ScreenPointToRay( Mouse.current.position.ReadValue() );
                RaycastHit hit;

                if ( Physics.Raycast( ray, out hit ) )
                {
                    // set hero's position to z=0, the plane with the enemies
                    Vector3 heroPos = hit.point;
                    heroPos.z = 0;

                    if ( heroAmt > 0 ) {
                        Instantiate(objToSpawn, heroPos, Quaternion.identity);
                        UIManagement.S.UpdateInventory( hType, -1 );
                        heroAmt--;
                    }
                }
            }
        }
    }
}