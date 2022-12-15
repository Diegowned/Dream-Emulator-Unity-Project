using System.Collections;
using UnityEngine;

public class ObjectInteractor : MonoBehaviour
{
    // The distance at which the player can interact with objects
    public float interactionDistance = 3.0f;

    // The tag that indicates that an object is interactable
    public string interactableTag = "Interactable";

    void Update()
    {
        // Raycast from the center of the player's view
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        // Check if the raycast hits an object
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // Check if the hit object has the interactable tag
            if (hit.collider.gameObject.tag == interactableTag)
            {
                // Check if the left mouse button is pressed
                if (Input.GetMouseButtonDown(0))
                {
                    // Start the interact coroutine on the object's script
                    hit.collider.gameObject.GetComponent<SceneChanger>().StartInteractCoroutine();
                }
            }
        }
    }
}


