using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    public static Menu Instance;
    public static string playerName;

    // Start is called before the first frame update
    void Start()
    {
        LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void StoreName(string name)
    {
        playerName = name;
        Debug.Log(playerName);
    }


    public void StartNew()
    {
        SceneManager.LoadScene(1);

    }

    public void LeaderBoard()
    {
        SceneManager.LoadScene(2);

    }
    public void Exit()
    {
        SaveHighScore();
        // something like: MainManager.Instance.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    [System.Serializable]
    class SaveData
    {
        public int savedScore;
        public string savedWinner;
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.savedScore = HighScore.permaScore;
        data.savedWinner = HighScore.winner;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            if (HighScore.permaScore < data.savedScore)
            {
                HighScore.permaScore = data.savedScore;
                HighScore.winner = data.savedWinner;
            }
        }
    }
}
