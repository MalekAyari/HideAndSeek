using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{

    public int ScoreValue;
    public TextMeshProUGUI Score;

    public int Burgers;
    public int HotDogs;
    public int Pizzas;

    
    public void UpdateScoreHotdog()
    {
        HotDogs++;
        ScoreValue += 1;
        Score.SetText(ScoreValue.ToString());
    }

    public void UpdateScoreBurger()
    {
        Burgers++;
        ScoreValue += 2;
        Score.SetText(ScoreValue.ToString());
    }

    public void UpdateScorePizza()
    {
        Pizzas++;
        ScoreValue += 5;
        Score.SetText(ScoreValue.ToString());
    }

}
