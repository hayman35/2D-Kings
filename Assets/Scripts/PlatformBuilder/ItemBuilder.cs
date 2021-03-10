﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class ItemBuilder : MonoBehaviour
{
    [SerializeField] PlatformType selectedPlatformType;

    // Update is called once per frame
    void Update()
    {
        //If the left mouse button is pressed and the mouse cursor is not on top of a game obect.
        if (Mouse.current.leftButton.wasPressedThisFrame && !EventSystem.current.IsPointerOverGameObject()) {
            Vector3 mousePosition = GetMouseWorldPosition();
            //If the current selected platform does not overlap with anything and can be placed.
            if (canPlaceHere(selectedPlatformType, mousePosition)) {
                //Place the platform at the mouse position.
                Instantiate(selectedPlatformType.platformPrefab, mousePosition, Quaternion.identity);
            }
        }
    }

    /**
     * A method that sets the current selected platform to be of type "type".
     */
    public void setSelectedPlatformType(PlatformType type) {
        selectedPlatformType = type;
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
}
