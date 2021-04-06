using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformSelectUI : MonoBehaviour{
    [SerializeField] private ItemBuilder builder;
    

    //Code for displaying the visual ghost of the platform.
    public Transform Ghost; //The ghost object.
    public Material GhostMaterial; //Material of the ghost sprite, should be transparent.
    public static bool GhostActive = false; //boolean to check if a visual ghost is active.

    /**
     * Creates the visual ghost that allows the player to see where the platform will be built.
     */
    public void createGhost(PlatformType type) {
        builder.setSelectedPlatformType(type);
        //If a ghost object has already spawned, destroy the object.
        if (GhostActive)
        {
            if (Ghost != null)
        {
            Destroy(Ghost.gameObject);
        }
        }
        //Instantiate the ghost object at the mouse location
        Ghost = Instantiate(type.GUIGhost, Vector3.zero, Quaternion.identity);
        //Adds the PlatformGhost script to the ghost object.
        Ghost.gameObject.AddComponent<PlatformGhost>();
        //Disable the box collider so that the player can place the platform, without colliding with it.
        Ghost.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //For every sprite in the ghost object (which is a prefab), set the sprite renderer material to GhostMaterial.
        foreach (Transform child in Ghost)
        {
            child.gameObject.GetComponent<SpriteRenderer>().material = GhostMaterial;
        }
        //Set GhostActive to be true.
        GhostActive = true;
    }

    public void DestoryGhost()
    {
        if (Ghost != null)
        {
            Destroy(Ghost.gameObject);
        }
    }
}
