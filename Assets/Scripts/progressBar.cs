using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class progressBar : MonoBehaviour
{

    public int maximum;
    public float progress = 0;
    public Image mask;

    private float multiplier = 0f;

    private float checkpoint1 = 0.25f;
    private float checkpoint2 = 0.45f;
    private float checkpoint3 = 0.70f;
    private float checkpoint4 = 0.95f;


    [Header("Stars")]
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject DoorIcon;

    public GameObject star4;

    [Header("Checkpoints")]
    public bool starPlayed1;
    public bool starPlayed2;
    public bool starPlayed3;
    public bool starPlayed4;

    [Header("Events")]
    public GameEvent DoorOpen;
    public GameEvent FullClear;
    public GameEvent Star;

    private void Start()
    {
        multiplier = ValueMultiplier();
    }

    private void Update()
    {
        mask.fillAmount = progress;

        if (progress >= checkpoint4 && (!starPlayed4))
        {
            starPlayed4 = true;
            star4.GetComponent<Animator>().Play("StarAnimator");
            FullClear.Raise();
        } else if (progress >= checkpoint3 && (!starPlayed3))
        {
            starPlayed3 = true;
            star3.GetComponent<Animator>().Play("StarAnimator");
            DoorIcon.gameObject.SetActive(true);
            DoorOpen.Raise();
            Star.Raise();
        }
        else if (progress >= checkpoint2 && (!starPlayed2) )
        {
            starPlayed2 = true;
            star2.GetComponent<Animator>().Play("StarAnimator");
            Star.Raise();
        }
        else if (progress >= checkpoint1 && (!starPlayed1))
        {
            starPlayed1 = true;
            star1.GetComponent<Animator>().Play("StarAnimator");
            Star.Raise();
        }
    }

    float ValueMultiplier()
    {
        float LocalMaximum = 0;
        foreach (Collectible obj in FindObjectsOfType<Collectible>())
        {
            switch (obj.type)
            {
                case (Collectible.CollectibleType.Hotdog):
                    LocalMaximum += 1;
                    break;
                case (Collectible.CollectibleType.Burger):
                    LocalMaximum += 2;
                    break;
                case (Collectible.CollectibleType.Pizza):
                    LocalMaximum += 5;
                    break;
            }
        }
        
        return maximum/LocalMaximum;
    }

    public void UpdateCurrentFillHotdog()
    {
        progress += (1 * multiplier) / 100;
    }

    public void UpdateCurrentFillBurger()
    {
        progress += (2 * multiplier) / 100;
    }

    public void UpdateCurrentFillPizza()
    {
        progress += (5 * multiplier) / 100;
    }
}
