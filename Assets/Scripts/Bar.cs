using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public GameObject bar;
    public int time;
    public GameObject FinishBtn;

    [Header("Events")]
    public GameEvent onTaskFinished;

    // Start is called before the first frame update
    void Start()
    {
        AnimateBar();
    }

    public void CloseUI(){
        onTaskFinished.Raise();
        Destroy(gameObject);
    }

    public void ShowExit(){
        FinishBtn.SetActive(true);
    }

    public void AnimateBar(){
        LeanTween.scaleX(bar, 1, time).setEase(LeanTweenType.easeInQuad).setOnComplete(ShowExit);
    }
}
