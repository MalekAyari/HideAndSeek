using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnlockLevels : MonoBehaviour
{
    public GameObject content;

    public void OpenLevelSelect(GameObject obj){
        obj.SetActive(true);
        Debug.Log("opened menu");
        List<Button> buttons = new List<Button>();
        
        for (int i=0; i<content.transform.childCount; i++) {

            buttons.Add(content.transform.GetChild(i).GetComponent<Button>());

            if (GameManager.instance.Level > i) {
                UnlockBtn(content.transform.GetChild(i));
            }

        }

        foreach (Button btn in buttons) {
            btn.onClick.AddListener(
                delegate {
                    PlayLevel(int.Parse(btn.gameObject.name));
                });
        }
    }

    public void CloseLevelSelect(GameObject obj){
        obj.SetActive(false);
    }

    public void PlayLevel(int i){
        SceneManager.LoadScene("Level " + i.ToString().Substring(0, 1));
    }

    public void UnlockBtn(Transform obj){
        obj.GetChild(1).gameObject.SetActive(false);
    }
}
