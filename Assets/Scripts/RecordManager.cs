using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RecordManager : MonoBehaviour
{
    public static RecordManager Instance;

    public string highestUser = "";
    public int highestScore = 0;

    public string currentUser;
    public int currentScore;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadRecord();
        }
    }


    public void UpdateRecord(string name, int score)
    {
        currentUser = name;
        currentScore = score;
        
        if(currentScore > highestScore)
        {
            highestUser = currentUser;
            highestScore = currentScore;
        }
    }

    public void UpdateRecord(int score)
    {
        UpdateRecord(currentUser, score);

    }

    public void SaveRecord()
    {

        Record record = new Record(highestUser, highestScore);

        string json = JsonUtility.ToJson(record);

        File.WriteAllText(Application.persistentDataPath + "/save_data.json", json);
    }

    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/save_data.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Record record = JsonUtility.FromJson<Record>(json);

            highestUser = record.name;
            highestScore = record.score;
        }
    }
}

[System.Serializable]
class Record
{
    public string name;
    public int score;

    public Record(string name, int score)
    {
        this.name = name;
        this.score = score;
    }

}


