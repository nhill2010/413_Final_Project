using UnityEngine;
using UnityEngine.InputSystem;


namespace LP.ClickToPlace
{
    public class ClickToPlace : MonoBehaviour
    {
        // will need to create an array of hero objects here 
        // and select them based on user input
        // for now, objToSpawn will be Hero1
        [ SerializeField ] GameObject objToSpawn = null;
        private Camera cam = null;

        private void Start()
        {
            cam = Camera.main;
        }

        private void Update()
        {
            SpawnAtMousePos();
            // RemoveAtMousePos();
        }

        // Function SpawnAtMousePos:
        // responsible for spawning hero objects on mouse
        // click at current mouse position
        private void SpawnAtMousePos()
        {
            if ( Mouse.current.leftButton.wasPressedThisFrame )
            {
                Ray ray = cam.ScreenPointToRay( Mouse.current.position.ReadValue() );
                RaycastHit hit;

                if ( Physics.Raycast( ray, out hit ) )
                {
                    Instantiate( objToSpawn, hit.point, Quaternion.identity );
                }
            }
        }

        // brought this in from old project - not sure if we'll need it
        // private void RemoveAtMousePos()
        // {
        //     if ( Mouse.current.rightButton.wasPressedThisFrame )
        //     {
        //         Ray ray = cam.ScreenPointToRay( Mouse.current.position.ReadValue() );
        //         RaycastHit hit;

        //         if ( Physics.Raycast( ray, out hit ) && hit.collider.tag == "Obstacle" )
        //         {
        //             Destroy( hit.collider.gameObject );
        //         }
        //     }
        // }
    }
}