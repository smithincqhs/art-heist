using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivate : MonoBehaviour
{
    GameObject sceneHandlerObject;
    SceneHandler sceneHandler;
    private void Awake()
    {
        sceneHandlerObject = GameObject.Find("SceneHandler");
        sceneHandler = sceneHandlerObject.GetComponent<SceneHandler>();
    }

    public void LoadSceneExternal(string sceneName)
    {
        sceneHandler.TravelScene(sceneName);
    }
}
