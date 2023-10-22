using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MapController : MonoBehaviour
{
   [SerializeField] private List<Poi> _pois = new List<Poi> ();
    [SerializeField] private Transform _xrOrigin;
    void Awake()
    {
        for (int i = 0; i < _pois.Count; i++)
        {
            int index = i;
            _pois[index].selectEntered.AddListener(delegate { Teleport(_pois[index].TeleportAnchor); });
        }
    }

    private void Teleport(Transform teleportAnchor)
    {
        Debug.Log($"Teleporting to {teleportAnchor.name}");
        _xrOrigin.SetPositionAndRotation(teleportAnchor.position, teleportAnchor.rotation);
    }
}
