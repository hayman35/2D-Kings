using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformSelectUI : MonoBehaviour
{
    [SerializeField] private ItemBuilder builder;

    [SerializeField] private List<PlatformType> platforms;
    [SerializeField] private List<Button> buttons;
    

    //Code for displaying the visual ghost of the platform.
    public Transform Ghost; //The ghost object.
    public Material GhostMaterial; //Material of the ghost sprite, should be transparent.
    public static bool GhostActive = false; //boolean to check if a visual ghost is active.

    void Awake() {
        for (int i = 0; i < platforms.Count; i++) {
            if (i < buttons.Count) {
																buttons[i].onClick.AddListener(() => { builder.setSelectedPlatformType(platforms[i]); });
                createGhost();
												}
        }

    }

    /**
     * Creates the visual ghost that allows the player to see where the platform will be built.
     */
    private void createGhost() {
        //If a ghost object has already spawned, destroy the object.
        if (GhostActive)
        {
            Destroy(Ghost);
        }
        //Instantiate the ghost object at the mouse location
        Ghost = Instantiate(builder.getSelectedPlatformType().GUIGhost, Vector3.zero, Quaternion.identity);
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
}
