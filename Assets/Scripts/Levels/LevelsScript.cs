using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[Serializable]
public class LevelsScript : MonoBehaviour
{
    [SerializeField] private int _currentLevel;
    [SerializeField] private GameObject[] _buttons;
    [SerializeField] private GameObject[] _locks;

    public void Start()
    {
        for (int i = 0; i < _locks.Length; i++)
        {
            if (i < getCurrentLevel())
            {
                _locks[i].SetActive(false);
            }
        }
    }

    public void loadLevel(int indexLevel)
    {
        if (indexLevel <= getCurrentLevel())
        {
            DataHolder.setProgram("");
            DataHolder.setLoadedLevel(indexLevel);
            SceneManager.LoadScene("SampleScene");
        }
    }
    
    public int getCurrentLevel()
    {
        return _currentLevel;
    }

    public void setCurrentLevel(int value)
    {
        _currentLevel = value;
    }
}
