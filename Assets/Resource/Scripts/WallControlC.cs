using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WallControlC : MonoBehaviour
{
    // Assign the object to be controlled in the Unity Inspector
    public GameObject controlledObject;

    // Cache the Renderer and BoxCollider2D components of the controlled object
    private Renderer controlledObjectRenderer;
    private BoxCollider2D controlledObjectCollider;

    // Track whether it's the first X key press
    private bool isFirstXKeyPress = true;

    private void Start()
    {
        controlledObject = this.gameObject;
        // Get the Renderer and BoxCollider2D components of the controlled object
        controlledObjectRenderer = controlledObject.GetComponent<Renderer>();
        controlledObjectCollider = controlledObject.GetComponent<BoxCollider2D>();

        // Make sure the controlled object has the required components
        if (controlledObjectRenderer == null)
        {
            Debug.LogError("Controlled object does not have a Renderer component.");
        }
        if (controlledObjectCollider == null)
        {
            Debug.LogError("Controlled object does not have a BoxCollider2D component.");
        }
    }

    private void Update()
    {
        // Check if the X key is pressed
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Ignore the first X key press
            if (isFirstXKeyPress)
            {
                isFirstXKeyPress = false;
            }
            else
            {
                // Toggle the Renderer and BoxCollider2D components of the controlled object
                controlledObjectRenderer.enabled = !controlledObjectRenderer.enabled;
                controlledObjectCollider.enabled = !controlledObjectCollider.enabled;
            }
        }
    }
    
}
