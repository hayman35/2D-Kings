using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformSelectUI : MonoBehaviour
{
    [SerializeField] private ItemBuilder builder;

    [SerializeField] private PlatformType platformLarge;
    [SerializeField] private PlatformType platformMedium;
    [SerializeField] private PlatformType platformSmall;
    [SerializeField] private PlatformType spikyPlatfromLarge;
    [SerializeField] private PlatformType spikyPlatformMedium;
    [SerializeField] private PlatformType spikyPlatformSmall;

    //Code for displaying the visual ghost of the platform.
    public Transform Ghost; //The ghost object.
    public Material GhostMaterial; //Material of the ghost sprite, should be transparent.
    public static bool GhostActive = false; //boolean to check if a visual ghost is active.

    void Awake() {
        //Not sure how to loop this.
        //Finds all the buttons and assigns them to a variable.
        Transform PlatformLargeButton = transform.Find("PlatformLargeButton");
        Transform PlatformMediumButton = transform.Find("PlatformMediumButton");
        Transform PlatformSmallButton = transform.Find("PlatformSmallButton");
        Transform SpikyPlatformLargeButton = transform.Find("SpikyPlatformLargeButton");
        Transform SpikyPlatformMediumButton = transform.Find("SpikyPlatformMediumButton");
        Transform SpikyPlatformSmallButton = transform.Find("SpikyPlatformSmallButton");

        //Sets what the buttons do when they are clicked on.
        //When a button is clicked, sets the selected platform to be of the type specified by the button.
        PlatformLargeButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            builder.setSelectedPlatformType(platformLarge);
            createGhost();
        });

        PlatformMediumButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            builder.setSelectedPlatformType(platformMedium);
            createGhost();
        });

        PlatformSmallButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            builder.setSelectedPlatformType(platformSmall);
            createGhost();
        });

        SpikyPlatformLargeButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            builder.setSelectedPlatformType(spikyPlatfromLarge);
            createGhost();
        });

        SpikyPlatformMediumButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            builder.setSelectedPlatformType(spikyPlatformMedium);
            createGhost();
        });

        SpikyPlatformSmallButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            builder.setSelectedPlatformType(spikyPlatformSmall);
            createGhost();
        });

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
