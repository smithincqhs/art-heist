using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerHandler : MonoBehaviour
{
    public GameObject playerOrigin;
    public string savePath = "Assets/Resources/save.sf";
    public Vector3 museumStartSpawn, museumDefaultSpawn, house1Spawn;
    public SceneHandler sceneHandler;
    private void Start()
    {
        museumStartSpawn = new Vector3(19, 0, 14.35f);
        museumDefaultSpawn = new Vector3(24, 3.58f, 32.5f);
        Scene scene = SceneManager.GetActiveScene();

        switch (scene.name)
        {
            case "BasicScene":
                if (File.Exists(savePath))
                    playerOrigin.transform.position = museumStartSpawn;
                else
                    playerOrigin.transform.position = museumDefaultSpawn;
                sceneHandler.home = true;
                sceneHandler.alarmTriggered = false;
                break;
            case "House1":
                playerOrigin.transform.position = house1Spawn;
                sceneHandler.home = false;
                sceneHandler.alarmTriggered = false;
                break;
            default:
                playerOrigin.transform.position = Vector3.zero;
                sceneHandler.home = false;
                break;

        }
    }
    
}
