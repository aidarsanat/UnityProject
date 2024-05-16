using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{

    public GameObject camera;
    public float distance = 17f;
    GameObject currentWeapon;
    bool canPickUp = false;
   
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PickUp();
        if (Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    void PickUp()
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if(hit.transform.tag == "Weapon")
            {
                if (canPickUp) Drop();

                currentWeapon = hit.transform.gameObject;
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                currentWeapon.GetComponent<Collider>().isTrigger = true;
                currentWeapon.transform.parent = transform;
                currentWeapon.transform.localPosition = Vector3.zero;
                currentWeapon.transform.localEulerAngles = new Vector3(0f, -177f, -85f);
                canPickUp = true;
            }

            if(hit.transform.tag == "Range")
            {
                if (canPickUp) Drop();

                currentWeapon = hit.transform.gameObject;
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                currentWeapon.GetComponent<Collider>().isTrigger = true;
                currentWeapon.transform.parent = transform;
                currentWeapon.transform.localPosition = Vector3.zero;
                currentWeapon.transform.localEulerAngles = new Vector3(0f, -177f, -85f);
                canPickUp = true;
            }
        }

        
    }

    void Drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon.GetComponent<Collider>().isTrigger = false;
        canPickUp = false;
        currentWeapon = null;
    }
}



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PickUpWeapon : MonoBehaviour
// {

//     public GameObject camera;
//     public float distance = 150f;
//     GameObject currentWeapon;
//     bool canPickUp = false;
   
    
//     void Update()
//     {
//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//         RaycastHit hit;
        

//         if (Physics.Raycast(ray, out hit, distance))
//         {
//             if(hit.collider.CompareTag("Weapon"))
//             {
//                 if (canPickUp) Drop();

//                 currentWeapon = hit.transform.gameObject;
//                 currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
//                 currentWeapon.GetComponent<Collider>().isTrigger = true;
//                 currentWeapon.transform.parent = transform;
//                 currentWeapon.transform.localPosition = Vector3.zero;
//                 currentWeapon.transform.localEulerAngles = new Vector3(0f, -177f, -85f);
//                 canPickUp = true;
//             }
//         }

//         if (Input.GetKeyDown(KeyCode.Q)) Drop();
//     }


//     void Drop()
//     {
//         currentWeapon.transform.parent = null;
//         currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
//         currentWeapon.GetComponent<Collider>().isTrigger = false;
//         canPickUp = false;
//         currentWeapon = null;
//     }


// }

// using UnityEngine;

// public class WeaponPickup : MonoBehaviour
// {
//     public float pickupRadius = 3f;
//     public GameObject camera;
//     public float distance = 150f;
//     GameObject currentWeapon;
//     bool canPickUp = false; // Set your desired pickup radius

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.E)) PickUp();
//         if (Input.GetKeyDown(KeyCode.Q)) Drop();
//     }

//     bool IsWithinPickupRadius(Vector3 point, float radius)
//     {
//         // Check if the point is within the circular pickup region
//         float distance = Vector3.Distance(transform.position, point);
//         return distance <= radius;
//     }

//     void PickUp()
//     {
//         // Implement logic for picking up the weapon
//         // For example, you might equip the weapon and disable it in the scene
//         // Get the center of the camera's view
//         Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
//         RaycastHit hit;

//         // Check if the ray hits an object within the pickup radius
//         if (Physics.Raycast(ray, out hit, distance) && hit.collider.CompareTag("Weapon"))
//         {
//             // Check if the hit point is within the circular pickup region
//             Vector3 hitPoint = hit.point;
//             hitPoint.y = transform.position.y; // Ensure the y-coordinate matches the player's height

//             // Check if the hit point is within the circular region
//             if (IsWithinPickupRadius(hitPoint, pickupRadius))
//             {
//                 if (canPickUp) Drop();

//                 currentWeapon = hit.transform.gameObject;
//                 currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
//                 currentWeapon.GetComponent<Collider>().isTrigger = true;
//                 currentWeapon.transform.parent = transform;
//                 currentWeapon.transform.localPosition = Vector3.zero;
//                 currentWeapon.transform.localEulerAngles = new Vector3(0f, -177f, -85f);
//                 canPickUp = true;
//             }
//         }
        
//     }

//     void Drop()
//     {
//         currentWeapon.transform.parent = null;
//         currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
//         currentWeapon.GetComponent<Collider>().isTrigger = false;
//         canPickUp = false;
//         currentWeapon = null;
//     }
// }






