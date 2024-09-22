using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public List<string> Owned = new List<string>();
    public List<Button> Buttons = new List<Button>();
    public GameObject buttonsParent;
    public Sprite activeSelection;
    public Sprite inactiveSelection;
    public TextMeshProUGUI coins;
    public GameObject SelectedModel;

    public void OpenShop(GameObject shop)
    {
        shop.SetActive(true);
        coins.text = GameManager.instance.Coins.ToString();
        Transform child = buttonsParent.transform.Find(GameManager.instance.modelName);
        SelectedModel = child.gameObject;
        SelectedModel.GetComponent<Image>().sprite = activeSelection;
    }

    public void CloseShop(GameObject shop) 
    {
        shop.SetActive(false);
    }

    public void SelectModel(GameObject p)
    {

        if (!Owned.Contains(p.gameObject.name) && GameManager.instance.Coins >= p.GetComponent<Product>().Price) 
        { 
            Owned.Add(p.gameObject.name);
            coins.text = (GameManager.instance.Coins - p.GetComponent<Product>().Price).ToString();
            GameManager.instance.Coins -= p.GetComponent<Product>().Price;
        }

        if (p != SelectedModel)
        {
            p.GetComponent<Image>().sprite = activeSelection;
            SelectedModel.GetComponent<Image>().sprite = inactiveSelection;
            SelectedModel = p;
        }
            
        GameManager.instance.modelName = p.gameObject.name;

        UpdateShop();
    }

    private void Start()
    {
        Owned = GameManager.instance.owned;

        UpdateShop();
    }

    private void UpdateShop()
    {
        Buttons.Clear();

        Button[] buttons = buttonsParent.GetComponentsInChildren<Button>();
        Buttons.AddRange(buttons);

        foreach (Button button in Buttons)
        {
            if (Owned.Contains(button.gameObject.name))
            {
                button.transform.Find("CostIcon").gameObject.SetActive(false);
                button.transform.Find("CheckMark").gameObject.SetActive(true);
    
            }
            
        }

        GameManager.instance.owned = Owned;
        GameManager.instance.Save();
    }
}
