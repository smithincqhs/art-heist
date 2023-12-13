using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetector : MonoBehaviour
{
    public Light alarmLight;
    public SceneHandler sceneHandler;
    private void OnTriggerEnter(Collider other)
    {
        if (!sceneHandler.alarmTriggered && other.gameObject.tag == "Player")
        {
            InvokeRepeating(nameof(FlashingLight), 0, 1);
            Debug.Log("ALERT! INTRUDER DETECTED!");
        }
    }

    private IEnumerator FlashingLight()
    {
        alarmLight.enabled = !alarmLight.enabled;
        return null;
    }
}
