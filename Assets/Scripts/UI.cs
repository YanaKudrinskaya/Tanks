using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _hpText;
    [SerializeField] private Text _levelText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _winText;

    public void UpdateScoreAndLevel()
    {
        _levelText.text = $"Level {Stats.Level}";
        _scoreText.text = "Score: " + Stats.Score.ToString("D4");// score = 23; 0023 4 знака 

    }

    public void UpdateHp(int hp)
    {
        _hpText.text = $"HP: {hp}";
    }

    public void UpdateWin() 
    {
        _winText.text = "Congratulations!";

    }
}
