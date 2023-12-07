using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.IO;

public class SaveMuseum : MonoBehaviour
{ // this is the only script that should touch save data
    public List<XRSocketInteractor> homeSockets;
    public ItemID itemForm;
    public Dictionary<int, int> socketSaveDict;
    private StreamWriter streamWriter;
    private StreamReader streamReader;

    public string savePath = "Assets/Resources/save.sf";

    public GameObject CreateInstanceFromId(int InstanceID)
    {
        GameObject trueOBJ = itemForm.PrefabFromID(InstanceID);
        if (trueOBJ)
        {
            return Instantiate(trueOBJ);
        }
        else
        {
            Debug.LogError("Instancing Exception: Failed to instance prefab from id " + InstanceID);
            return null;
        }
    }

    public void LoadItems()
    {
        socketSaveDict.Clear();
        streamReader = new StreamReader(savePath);
        string stream = streamReader.ToString();
        string[] data = stream.Split('\r');
        string[] dataTwo = new string[2];
        foreach (string line in data)
        {
            dataTwo = line.Split(',');
            socketSaveDict.Add(int.Parse(dataTwo[0]), int.Parse(dataTwo[1]));
        }
        foreach (KeyValuePair<int, int> socket in socketSaveDict)
        {
            GameObject newInstanced = CreateInstanceFromId(socket.Value);
            homeSockets[socket.Key].startingSelectedInteractable = newInstanced.GetComponent<XRBaseInteractable>();
        }
    }

    public void SaveItems()
    {
        streamWriter = new StreamWriter(savePath);
        foreach (XRSocketInteractor socket in homeSockets)
        {
            if (socket.hasSelection)
            {
                streamWriter.WriteLine("{0},{1}\r",homeSockets.IndexOf(socket),itemForm.IDFromPrefab(socket.firstInteractableSelected.transform.parent.gameObject));
            }
        }
    }

}
