using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    [SerializeField] private GameObject WinScreen;
    [SerializeField] private GameObject LoseScreen;

    public void ShowWinScreen()
    {
        WinScreen.SetActive(true);
    }
    
    public void ShowLoseScreen()
    {
        LoseScreen.SetActive(true);
    }

    public void NextLevel()
    {
        string name = SceneManager.GetActiveScene().name.Substring(0, SceneManager.GetActiveScene().name.Length);
        GameManager.instance.IncreaseLevel();
        GameManager.instance.Play();
    }
   
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }


    
}
