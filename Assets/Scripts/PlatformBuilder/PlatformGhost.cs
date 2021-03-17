using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

/**
 * This is attached to the visual ghost object, so all methods will only affect the visual ghost.
 */
public class PlatformGhost : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Gets the current mouse position.
        Vector3 mousePosition = ItemBuilder.GetMouseWorldPositionWithSnap();
        //Sets the position of the game object this script is attached to, to be at the mouse position. Uses the static gridSize variable, which can be changed in the ItemBuilder class.
        gameObject.transform.position = new Vector3(Mathf.RoundToInt(mousePosition.x / ItemBuilder.gridSize.x) * ItemBuilder.gridSize.x, 
            Mathf.RoundToInt(mousePosition.y / ItemBuilder.gridSize.y) * ItemBuilder.gridSize.y, 
            Mathf.RoundToInt(mousePosition.z / ItemBuilder.gridSize.z) * ItemBuilder.gridSize.z);

        //OverlapBox creates a box around the ghost and checks if anything collides with it, if there are collisions, change colour of ghost to red, otherwise, green.
        if (Physics2D.OverlapBox(mousePosition + (Vector3)gameObject.GetComponent<BoxCollider2D>().offset, gameObject.GetComponent<BoxCollider2D>().size, 0) != null){
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);
            }
        } else {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.green);
            }
        }

        //If left mouse button is pressed, destroy this ghost object.
        if (Mouse.current.leftButton.wasPressedThisFrame) {
            Destroy(this.gameObject);
            //Set ghost active to be false.
            PlatformSelectUI.GhostActive = false;
        }
    }
}
