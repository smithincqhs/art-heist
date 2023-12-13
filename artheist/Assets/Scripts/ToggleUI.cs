using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ToggleUI : MonoBehaviour
{
    public InputActionReference leftPrimary = null, rightPrimary = null, leftPauseButton = null, rightPauseButton = null;
    public GameObject inventoryCanvas;
    public XRSocketInteractor[] sockets;
    public GameObject[] contained;
    public GameObject pauseCanvas, settingsPanel;

    private void Awake()
    {
        contained = new GameObject[10];
        Debug.Log("awake");
        leftPrimary.action.performed += ToggleInv;
        rightPrimary.action.performed += ToggleInv;
        leftPauseButton.action.performed += TogglePause;
        rightPauseButton.action.performed += TogglePause;
    }

    private void OnDestroy()
    {
        Debug.Log("ondestroy");
        leftPrimary.action.performed -= ToggleInv;
        rightPrimary.action.performed -= ToggleInv;
        rightPauseButton.action.performed -= TogglePause;
        leftPauseButton.action.performed -= TogglePause;
    }

    private void ToggleInv(InputAction.CallbackContext context)
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
        return;
    }

    public void TogglePauseUI()
    {
        TogglePause(new InputAction.CallbackContext());
    }

    public void ToggleSettings()
    {
        Debug.Log("toggle start");

        try
        {

            settingsPanel.SetActive(!settingsPanel.activeSelf);
        }
        catch (System.Exception e)
        {
            Debug.LogFormat("settings failed: {0}", e);
        }
    }

    private void TogglePause(InputAction.CallbackContext context)
    {
        Debug.Log("toggle start");
        try
        {
            pauseCanvas.SetActive(!pauseCanvas.activeSelf);
            // camera.animation enabled = !camera.enabled or whatever
        }
        catch (System.Exception e)
        {
            Debug.LogFormat("pause failed: {0}", e);
        }
    }
}
