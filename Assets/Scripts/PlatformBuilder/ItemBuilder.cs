using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class ItemBuilder : MonoBehaviour
{
    [SerializeField] PlatformType selectedPlatformType = null;
    //Serialize field for choosing grid size. CHANGE numbers here to adjust grid size.
    public static Vector3 gridSize = new Vector3(1f, 1f, 1f);
    private List<GameObject> platforms=new List<GameObject>();
    // Update is called once per frame
    void Update()
    {
        if (selectedPlatformType != null) {
            //If the left mouse button is pressed and the mouse cursor is not on top of a game obect.
            if (Mouse.current.leftButton.wasPressedThisFrame && !EventSystem.current.IsPointerOverGameObject())
            {
                Vector3 mousePosition = GetMouseWorldPosition();
                //Snaps to grid, depends on grid size.
                mousePosition = snapToGridSquare(mousePosition);
                //If the current selected platform does not overlap with anything and can be placed.
                if (canPlaceHere(selectedPlatformType, mousePosition))
                {
                    //Place the platform at the mouse position.
                    platforms.Add(Instantiate(selectedPlatformType.platformPrefab, mousePosition, Quaternion.identity).gameObject);
                    selectedPlatformType = null;

                }
            }
        }
    }
				public void resetPlatforms() {
        print(platforms.Count);
        for (int i = 0; i <platforms.Count;i++) {
            
            Destroy(platforms[i]);
								}
				}
				/**
     * A method that sets the current selected platform to be of type "type".
     */
				public void setSelectedPlatformType(PlatformType type) {
        selectedPlatformType = type;
    }

    /**
     * A method that returns the current selected platform type.
     */
    public PlatformType getSelectedPlatformType()
    {
        if (selectedPlatformType != null) {
            return selectedPlatformType;
        } else {
            return null;
        }
    }

    /**
     * A function to check if the current selected platform can be placed or not.
     */
    private bool canPlaceHere(PlatformType currentType, Vector3 position) {
        //Gets the box collider of the current platform
        BoxCollider2D currentPlatformCollider = currentType.platformPrefab.GetComponent<BoxCollider2D>();

        //Checks if this platform overlaps with any other object in the world.
        if(Physics2D.OverlapBox(position + (Vector3)currentPlatformCollider.offset, currentPlatformCollider.size, 0) != null){
            return false;
        } else {
            return true;
        }
    }

    // Get Mouse Position in World with Z = 0f
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Mouse.current.position.ReadValue(), Camera.main);
        vec.z = 0f;
        return vec;
    }

    //No paramaters
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Mouse.current.position.ReadValue(), Camera.main);
    }

    //Only the world camera parameter.
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Mouse.current.position.ReadValue(), worldCamera);
    }

    //all parameters included: screen position and world camera.
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

    // Gets the mouse position and then snap to grid size of 1 at the same time.
    public static Vector3 GetMouseWorldPositionWithSnap()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Mouse.current.position.ReadValue(), Camera.main);
        vec = snapToGridSquareGridOne(vec);
        vec.z = 0f;
        return vec;
    }

    //A method that sets the mouse position/spawn position to be a integer, so that it snaps to grid.
    public Vector3 snapToGridSquare(Vector3 mousePosition) {
        //Creates a new Vector3 that has x, y and z values rounded to a integer
        Vector3 newPosition = new Vector3(Mathf.RoundToInt(mousePosition.x / gridSize.x) * gridSize.x,
            Mathf.RoundToInt(mousePosition.y / gridSize.y) * gridSize.y,
            Mathf.RoundToInt(mousePosition.z / gridSize.z) * gridSize.z);

        return newPosition;
    }

    //Grid size of 1. Can be adjusted in another class using the static gridSize variable.
    public static Vector3 snapToGridSquareGridOne(Vector3 mousePosition)
    {
        //Creates a new Vector3 that has x, y and z values rounded to a integer
        Vector3 newPosition = new Vector3(Mathf.RoundToInt(mousePosition.x),
            Mathf.RoundToInt(mousePosition.y),
            Mathf.RoundToInt(mousePosition.z));

        return newPosition;
    }
}
