using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerHandler : MonoBehaviour
{
    public GameObject playerOrigin;
    public string savePath = "Assets/Resources/save.sf";
    public Vector3 museumStartSpawn, museumDefaultSpawn;
    public SceneHandler sceneHandler;
    private void Start()
    {
        museumStartSpawn = new Vector3(19, 0, 14.35f);
        museumDefaultSpawn = new Vector3(24, 3.58f, 32.5f);
        switch (SceneManager.GetActiveScene().name)
        {
            case "BasicScene":
                if (File.Exists(savePath))
                    playerOrigin.transform.position = museumStartSpawn;
                else
                    playerOrigin.transform.position = museumDefaultSpawn;
                sceneHandler.home = true;
                sceneHandler.alarmTriggered = false;
                break;
            default:
                playerOrigin.transform.position = Vector3.zero;
                sceneHandler.home = false;
                break;

        }
    }
    
}
