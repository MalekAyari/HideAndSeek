using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchMeter : MonoBehaviour
{
    [SerializeField] private GameObject bar;

    [Header("Events")]
    [SerializeField] private GameEvent OnLose;

    private Controls controls;
    private Vector3 scale;

    private float currentFillProgress = 0;
    private bool free = true;
    public float fillRate;
    
    // Start is called before the first frame update
    void Start()
    {
        controls = GetComponent<Controls>();
        scale = bar.transform.localScale;
    }

    void FixedUpdate() {

        if (currentFillProgress >= 0 && currentFillProgress < 1 && free == false){
            currentFillProgress += Mathf.Clamp01(Time.deltaTime * fillRate);
        }
        if (currentFillProgress > 0 && currentFillProgress < 1 && free == true){
            currentFillProgress -= Mathf.Clamp01(Time.deltaTime * fillRate);
        }

        scale.x = currentFillProgress;
        bar.transform.localScale = scale;

        if ((currentFillProgress + Mathf.Clamp01(Time.deltaTime * fillRate)) >= 1 && (free == false)){
            Debug.Log("CAUGHT!!!");
            OnLose.Raise();
        }
    }

    public void Catching(){
        free = false;
        controls.speed = 3;
    }

    public void Releasing(){
        free = true;
        controls.speed = 5;
    }
}
