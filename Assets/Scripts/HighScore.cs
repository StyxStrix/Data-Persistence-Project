using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class HighScore : MonoBehaviour
{

    public static HighScore Instance;
    public Text highScoreText;
    public int score;
    public static int permaScore;
    public static string winner;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

         //   SetScore(MainManager.m_Points);
        if(MainManager.m_Points > permaScore)
        {
            SetScore(MainManager.m_Points, Menu.playerName);
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log(MainManager.m_Points);
            Debug.Log(score);
            Debug.Log(permaScore);
        }
            
            SetHighScoreText(permaScore, winner); 
            
    }

    private void Awake()
    {
        //Checks if Main Manager object has been carried over - if so destroying any new instance of it
        //(this stops us from ending up with multiple objects when switching between scenes.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        //stops Main Manager object (which we assigned this script to) from being destroyed during scene switch)
        Instance = this;
        DontDestroyOnLoad(gameObject);

        DontDestroyOnLoad(canvas);
        SetHighScoreText(score, Menu.playerName);

    }

    void SetScore(int a, string b)
    {
        permaScore = a;
;       winner = b;
    }

    void SetHighScoreText(int a, string b)
    {
        highScoreText.GetComponent<Text>().text = "Highscore: " + a + "  -  " + b;
    }


}
