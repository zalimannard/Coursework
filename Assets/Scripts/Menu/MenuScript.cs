using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Levels");
    }
    
    public void Continue()
    {
        SceneManager.LoadScene("Levels");
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
