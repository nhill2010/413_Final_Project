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
        // min and max values define a range of the screen where
        // the hero select button is - this will be a null range
        private Vector2 voidRangeMins = new Vector2( -18, -10 ); // xmin, ymin
        private Vector2 voidRangeMaxs = new Vector2( -14, -6 ); // xmax, ymax

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
                    // if click point not in void range
                    if ( !( hit.point.x > voidRangeMins.x && hit.point.x < voidRangeMaxs.x ) ||
                         !( hit.point.y > voidRangeMins.y && hit.point.y < voidRangeMaxs.y ) ) {

                        // set hero's position to z=0, the plane with the enemies
                        Vector3 heroPos = hit.point;
                        heroPos.z = 0;
                        Instantiate(objToSpawn, heroPos, Quaternion.identity);
                    }
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