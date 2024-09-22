using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    public void SaveAndApply(){

    }

    public void RestoreDefaults(){

    }

    public void Open(){
        gameObject.SetActive(true);
    }

    public void Close(){
        gameObject.SetActive(false);
    }
}
