using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamecontroller : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStartNewGame()
    {
        Debug.LogWarning("Load level 1");
        SceneManager.LoadScene("scenes/level1");
    }

    public void OnDeath()
    {
        Debug.LogWarning("death");
        SceneManager.LoadScene("Scenes/youdied");
    }

    public void OnGotoWrapper()
    {
        Debug.LogWarning("death");
        SceneManager.LoadScene("Scenes/wrapper");
    }

    public void OnQuit()
    {
        Debug.LogWarning("quit game completely");
        Application.Quit();
    }
}


