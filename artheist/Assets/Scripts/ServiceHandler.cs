using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceHandler : MonoBehaviour
{
    public static ServiceHandler instance { get; private set; }
    public static SceneHandler sceneHandler { get; private set; }
    public static PlayerHandler playerHandler { get; private set; }
    public static ToggleUI toggleUI { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
        sceneHandler = GetComponentInChildren<SceneHandler>();
        playerHandler = GetComponentInChildren<PlayerHandler>();
        toggleUI = GetComponentInChildren<ToggleUI>();
    }
}
