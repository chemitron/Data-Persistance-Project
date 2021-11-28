using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance; //static makes this variable common to all instances of MainManager
    public SavedData savedData = new SavedData();

    void Awake()
    { 
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveHighScore()
    {
        string json = JsonUtility.ToJson(savedData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedData data = JsonUtility.FromJson<SavedData>(json);
            savedData = data;
        }
    }
}
