using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class ButtonVariables : MonoBehaviour{
    [SerializeField]private PlatformType type;
    [SerializeField]private int quantity;
    [SerializeField]private PlatformSelectUI selector;

    private Button button;
    bool hide = true;
    private void Awake() 
    {
        button = GetComponent<Button>();
    }

    private void Update() 
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            FadeToColor(button.colors.pressedColor);
            button.onClick.Invoke(); 
            
        }
        else if(Keyboard.current.eKey.wasReleasedThisFrame)
        {
            FadeToColor(button.colors.normalColor);
            hide = !hide;
            if (hide)
            {
                selector.DestoryGhost();
            }
        }
    }

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color,button.colors.fadeDuration,true,true);
    }

    public void OnButtonPress() 
    {
        quantity = ItemBuilder.platformCount;
        
        if (quantity > 0) {
            selector.createGhost(type);
        }
    }
}
