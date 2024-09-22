using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public GameObject coins;
    public GameObject hotdogs;
    public GameObject burgers;
    public GameObject pizzas;

    private void Start()
    {
        TextMeshProUGUI coinsText = coins.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI hotdogsText = coins.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI burgersText = coins.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI pizzasText = coins.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }
}
