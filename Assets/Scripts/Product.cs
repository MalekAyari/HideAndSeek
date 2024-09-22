using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Product : MonoBehaviour
{
    public string Name;
    public int Price;
    public bool Owned;

    public void Start()
    {
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Name;
        transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = Price.ToString();
    }
}
