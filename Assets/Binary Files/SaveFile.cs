using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveFile
{

    public int Level;
    public int Coins;
    public int Model;
    public string name;
    public List<string> Owned;

    public SaveFile(GameManager manager)
    {
        Level = manager.Level;
        Coins = manager.Coins;
        Model = manager.Model;
        name = manager.modelName;
        Owned = manager.owned;
    }

}
