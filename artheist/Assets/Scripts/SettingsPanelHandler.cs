using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SettingsPanelHandler : MonoBehaviour
{
    public bool snapTurn, vignetteEnabled, rayGrab;
    public ActionBasedSnapTurnProvider snapTurnProvider;
    public ActionBasedContinuousTurnProvider continuousTurnProvider;
    public GameObject vignetteObject;
    public XRRayInteractor leftRayInteractor, rightRayInteractor;

    public void ToggleTurnStyle()
    {
        snapTurnProvider.enabled = !snapTurnProvider.enabled;
        snapTurn = !snapTurn;
        continuousTurnProvider.enabled = !continuousTurnProvider.enabled;
        return;
    }

    public void ToggleVignette()
    {
        vignetteObject.SetActive(!vignetteObject.activeSelf);
        vignetteEnabled = !vignetteEnabled;
        return;
    }    

    public void ToggleGrabMode()
    {
        rayGrab = !rayGrab;
        if (rayGrab)
        {
            rightRayInteractor.interactionLayers = InteractionLayerMask.GetMask("Default");
            leftRayInteractor.interactionLayers = InteractionLayerMask.GetMask("Default");
        }
        else
        {
        rightRayInteractor.interactionLayers = InteractionLayerMask.GetMask("Nothing");
        leftRayInteractor.interactionLayers = InteractionLayerMask.GetMask("Nothing");
        }
    }


}
