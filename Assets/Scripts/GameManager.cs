using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int TargetFrameRate = -1;
    public bool DEBUG, MUTE;
    
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }
 
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(gameObject);
        }

        #if UNITY_STANDALONE
        Cursor.visible = false;
        #endif
        
        #if UNITY_EDITOR
        Cursor.visible = true;
        Application.targetFrameRate = TargetFrameRate;
        AudioListener.pause = MUTE;
        #endif
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (Input.GetKeyDown(KeyCode.Q))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (Input.GetKeyDown(KeyCode.M))
        {
            MUTE = !MUTE;
            AudioListener.pause = MUTE;
        }
    }
}
