using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class Stats
{
    public static int Level { get; private set; } = 1;
    private static int _score = 0;
    
    public static int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            if(_score >100 * Level)
            {
                Level++;
                _score = 0;
            }
        }
    }
    public static void ResetAllStats()
    {
        Level = 1;
        _score = 0;
    }

    public static void UploadLevel(bool status)
    {
        Stats.ResetAllStats();
        int indexCurrentLevel = SceneManager.GetActiveScene().buildIndex;
        int indexNextLevel = indexCurrentLevel + 1;
        if (status == true)
            SceneManager.LoadScene(indexCurrentLevel);
        else 
        {
            if (indexNextLevel == SceneManager.sceneCountInBuildSettings)
                indexNextLevel = 0;
            SceneManager.LoadScene(indexNextLevel);
        }
    }
}
