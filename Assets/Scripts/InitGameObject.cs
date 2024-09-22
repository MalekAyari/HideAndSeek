using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitGameObject : MonoBehaviour
{
    public GameObject Content;

    // Start is called before the first frame update
    void Start()
    {

        for (var i = 0; i< Content.transform.childCount; i++)
        {
            Content.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(GameManager.instance.updateModel);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
