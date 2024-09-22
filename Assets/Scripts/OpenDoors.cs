using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    [SerializeField] private GameObject Wall1;
    [SerializeField] private GameObject Wall2;

    private Animator wall1;
    private Animator wall2;

    private void Awake() {
        wall1 = Wall1.GetComponent<Animator>();
        wall2 = Wall2.GetComponent<Animator>();
    }
    
    public void Open(){
        wall1.SetBool("Open", true);
        wall2.SetBool("Open", true);
    }
}
