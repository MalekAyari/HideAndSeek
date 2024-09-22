using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int Coins = 0;
    public int Level = 1;
    public int Model;

    public RuntimeAnimatorController animController;
    public List<string> owned;
    public Shop shop;

    [SerializeField]
    private List<GameObject> Models = new List<GameObject>();
    public string modelName = "Male";

    [Header("Settings")]
    public List<float> audioVolumes = new List<float>();
    public AudioMixer mixer;
    public GameObject male;
    public GameObject female;
    public GameObject ninja;
    
    public GameObject maleMenu;
    public GameObject femaleMenu;
    public GameObject ninjaMenu;

    public GameObject spawn;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
        
        Load();
        
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        updateModel();
    }

    private void Start()
    {
        Debug.Log("Scene manager: " + SceneManager.GetActiveScene().name);

        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            Debug.Log("menu load: " + maleMenu.GetComponent<Animator>().runtimeAnimatorController);

            switch (modelName)
            {
                case "Male":
                    GameObject char1 = Instantiate(maleMenu, transform);
                    char1.GetComponent<Animator>().runtimeAnimatorController = animController;
                    char1.GetComponent<Animator>().Play("Look around");
                    break;
                case "Female":
                    GameObject char2 = Instantiate(femaleMenu, transform);
                    char2.GetComponent<Animator>().runtimeAnimatorController = animController;
                    char2.GetComponent<Animator>().Play("Look around");
                    break;
                case "Ninja":
                    GameObject char3 = Instantiate(ninjaMenu, transform);
                    char3.GetComponent<Animator>().runtimeAnimatorController = animController;
                    char3.GetComponent<Animator>().Play("Look around");
                    break;
            }
        }

        if (shop != null)
        {
            owned = shop.Owned;
        }

        if (audioVolumes.Count() == 0) {
            audioVolumes.Add(1f);
            audioVolumes.Add(1f);
            audioVolumes.Add(1f);
        } else {
            mixer.SetFloat("Master", audioVolumes[0]);
            mixer.SetFloat("Music", audioVolumes[1]);
            mixer.SetFloat("Effects", audioVolumes[2]);
        }

        updateModel();
    }

    
    public void updateModel()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        var i = 0;

        while (i<=Models.Count && Models[i].gameObject.name != modelName)
        {
            i++;
        }
        
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
        {
            Destroy(obj.gameObject);
        }

        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            switch (modelName)
            {
                case "Male":
                    GameObject char1 = Instantiate(maleMenu, transform);
                    char1.transform.parent = null;
                    break;
                case "Female":
                    GameObject char2 = Instantiate(femaleMenu, transform);
                    char2.transform.parent = null;
                    break;
                case "Ninja":
                    GameObject char3 = Instantiate(ninjaMenu, transform);
                    char3.transform.parent = null;
                    break;
            }
        }

    }

    public void IncreaseLevel()
    {
        Level++;
        Debug.Log("Level increased to: " + Level);
        Save();
    }

    public void Play()
    {
        SceneManager.LoadScene("Level " + Level.ToString());
        Save();
    }

    public void Save()
    {
        
        SaveSystem.SaveManager(this);
    }

    public void Load()
    {
        SaveFile file = SaveSystem.LoadManager();

        Coins= file.Coins;
        Level= file.Level;
        Model= file.Model;
        modelName = file.name;
        if ((shop != null) && (file.Owned != null))
        {
            owned = file.Owned;
            shop.Owned = owned;
        } else
        {
            Debug.Log("file.Owned is Null.");
        }

        GameObject settingsMenu = GameObject.Find("Settings");
        if (settingsMenu != null) {
            settingsMenu.transform.GetChild(0).transform.Find("Slider").GetComponent<Slider>().value = audioVolumes[0];
            settingsMenu.transform.GetChild(1).transform.Find("Slider").GetComponent<Slider>().value = audioVolumes[1];
            settingsMenu.transform.GetChild(2).transform.Find("Slider").GetComponent<Slider>().value = audioVolumes[2];
        }
        

    }


}
