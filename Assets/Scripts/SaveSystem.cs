using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    
    public static void SaveManager(GameManager manager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Manager.save";

        FileStream stream = new FileStream(path, FileMode.Create);

        SaveFile file = new SaveFile(manager);

        formatter.Serialize(stream, file);
        stream.Close();
        Debug.Log("saved");
    }


    public static SaveFile LoadManager()
    {
        string path = Application.persistentDataPath + "/Manager.save";

        if (File.Exists(path))
        {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveFile file = formatter.Deserialize(stream) as SaveFile;
            stream.Close();


            return file;
        } else
        {
            Debug.LogError("Save file not found in: " + path);
            return null;
        }
    }
}
