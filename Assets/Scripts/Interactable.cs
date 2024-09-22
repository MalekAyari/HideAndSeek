using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject Game;
    public bool isActive;
    public bool isComplete;
    
    private void OnMouseUpAsButton() {
        if(GetComponent<Outline>()){
            if(!isActive)
            {
                Instantiate(Game);
                isActive = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        var outline = gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 5f;
    }

    private void OnTriggerExit(Collider other) {
        Destroy(GetComponent<Outline>());
    }
}
