using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ToggleInventory : MonoBehaviour
{
    public InputActionReference leftPrimary = null, rightPrimary = null;
    public GameObject inventoryCanvas;
    public XRSocketInteractor[] sockets;
    public GameObject[] contained;

    private void Awake()
    {
        contained = new GameObject[10];
        Debug.Log("awake");
        leftPrimary.action.performed += Toggle;
        rightPrimary.action.performed += Toggle;
    }

    private void OnDestroy()
    {
        Debug.Log("ondestroy");
        leftPrimary.action.performed -= Toggle;
        rightPrimary.action.performed -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        Debug.Log("toggle start");
        if (inventoryCanvas.activeSelf)
        {
            for (int i = 0; i < sockets.Length; i++)
            {
                if (sockets[i].hasSelection)
                {
                    GameObject _g = sockets[i].firstInteractableSelected.transform.gameObject;
                    contained[i] = _g;
                    _g.SetActive(false);
                }
                else
                {
                    contained[i] = null;
                }
                sockets[i].transform.gameObject.SetActive(false);
            }
            inventoryCanvas.SetActive(false);
        }
        else
        {
            inventoryCanvas.SetActive(true);
            for (int i = 0; i < sockets.Length; i++)
            {
                sockets[i].transform.gameObject.SetActive(true);
                if (contained[i])
                {
                    contained[i].SetActive(true);
                    sockets[i].IsSelecting(contained[i].GetComponent<IXRSelectInteractable>());
                }
            }
        }
    }
}
