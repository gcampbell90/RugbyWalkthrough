using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

class Poi : XRSimpleInteractable
{
    [field: SerializeField] public Transform TeleportAnchor { get; set; }
    private GameObject _textBox;
    public delegate void ButtonGrabbed(Poi inventoryObject, ActivateEventArgs args);
    public ButtonGrabbed onItemSelected;

    protected override void OnEnable()
    {
        base.OnEnable();
        hoverEntered.AddListener(ItemHovered);
        hoverExited.AddListener(ItemHoverExit);
    }



    protected override void OnDisable()
    {
        base.OnDisable();
        hoverEntered.RemoveListener(ItemHovered);
        hoverExited.RemoveListener(ItemHoverExit);
    }

    protected override void Awake()
    {
        base.Awake();

        _textBox = transform.GetChild(0).gameObject;
        _textBox.SetActive(false);
    }

    private void ItemHovered(HoverEnterEventArgs arg)
    {
        Debug.Log($"UI Item hovered {this.name}");
        _textBox.SetActive(true);
    }
    private void ItemHoverExit(HoverExitEventArgs arg0)
    {
        Debug.Log($"UI Item hover exited {this.name}");
        _textBox.SetActive(false);
    }

}