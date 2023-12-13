using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneHandler : MonoBehaviour
{
    public GameObject inventoryCanvas;
    public ToggleInventory toggle;
    public GameObject playerHandler; // playerhandler per scene
    public GameObject playerPrefab;
    private GameObject playerObject;
    public GameObject playerInvUI;
    private int invSocketAmt = 9;
    public List<GameObject> publicItems; // items added in editor to save between scenes

    public void TravelScene(string sceneName) // move across scenes normally
    {
        try
        {
            List<GameObject> saveItems = new List<GameObject>();
            saveItems = AddInvToSaveItems();
            saveItems.AddRange(publicItems);
            foreach (GameObject i2s in saveItems)
            {
                if (i2s)
                    DontDestroyOnLoad(i2s);
                Debug.Log(i2s ? i2s.name : "none1");
            }
            SceneManager.LoadScene(sceneName);
            Debug.LogFormat("Scene {0} successfully loaded with {1} attached", sceneName, saveItems);
        }
        catch (System.Exception e)
        {
            Debug.LogErrorFormat("Error loading scene {0}\n\r {1}", sceneName, e);
        }
    }

    public void NewScene(string sceneName) // change scenes without saving inv
    {
        try
        {
            SceneManager.LoadScene(sceneName);
            if (!playerObject)
            {
                playerObject = Instantiate<GameObject>(playerPrefab);
            }
            Debug.LogFormat("Scene {0} successfully loaded", sceneName);
        }
        catch(System.Exception e)
        {
            Debug.LogErrorFormat("Error loading scene {0}\n\r {1}", sceneName, e);
        }
    }

    private List<GameObject> AddInvToSaveItems()
    {
        GameObject panelOBJ = playerInvUI.transform.Find("Panel").gameObject;
        XRSocketInteractor[] invSockets = panelOBJ.GetComponentsInChildren<XRSocketInteractor>();
        GameObject[] socketObjects = new GameObject[invSocketAmt + 1];
        if (inventoryCanvas.activeSelf)
        {
            for (int i = 0; i < invSocketAmt; i++)
            {
                socketObjects[i] = invSockets[i].hasSelection ? invSockets[i].firstInteractableSelected.transform.gameObject : null;
                Debug.Log(socketObjects[i] ? socketObjects[i].name : "none");
            }
            return new List<GameObject>(socketObjects);
        }
        else
        {
                return new List<GameObject>(toggle.contained);
        }

    }

}