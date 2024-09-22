using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{

    public AudioSource src;

    [Header("Collectibles")]
    public AudioClip HotdogSFX;
    public AudioClip BurgerSFX; 
    public AudioClip PizzaSFX;
    public AudioClip ExitSFX;

    [Header("GUI")]
    public AudioClip ButtonPressSFX;
    public AudioClip StarSFX;
    public AudioClip FullClearSFX;

    public void Star()
    {
        src.clip = StarSFX;
        src.Play();
    }

    public void Exit()
    {
        src.clip = ExitSFX;
        src.Play();
    }
    public void FullClear()
    {
        src.clip = FullClearSFX;
        src.Play();
    }

    public void GUIClick()
    {
        src.clip = ButtonPressSFX;
        src.Play();
    }

    public void HotDogCollect()
    {
        src.clip = HotdogSFX;
        src.Play();
    }

    public void BurgerCollect()
    {
        src.clip = BurgerSFX;
        src.Play();
    }

    public void PizzaCollect()
    {
        src.clip = PizzaSFX;
        src.Play();
    }

}
