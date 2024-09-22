using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInit : MonoBehaviour
{
    public VariableJoystick joystick;
    public GameObject camera;
    public GameObject male;
    public GameObject female;
    public GameObject ninja;
    public GameObject chef;

    private void Start()
    {
        Navigation nav = chef.GetComponent<Navigation>();
        switch (GameManager.instance.modelName)
        {
            case "Male":
                GameObject player1 = Instantiate(male, transform);
                player1.transform.SetParent(null);
                player1.GetComponent<Controls>().Cam = camera;
                player1.GetComponent<Controls>().joyStick = joystick;
                nav.player = player1.transform;
                if (SceneManager.GetActiveScene().name == "Tutorial")
                {
                    Tutorial tut = FindObjectOfType<Tutorial>();
                    tut.player = player1;
                }
                break;

            case "Female":
                GameObject player2 = Instantiate(female, transform);
                player2.transform.SetParent(null);
                player2.GetComponent<Controls>().Cam = camera;
                player2.GetComponent<Controls>().joyStick = joystick;
                nav.player = player2.transform;
                if (SceneManager.GetActiveScene().name == "Tutorial")
                {
                    Tutorial tut = FindObjectOfType<Tutorial>();
                    tut.player = player2;
                }
                break;
            case "Ninja":
                GameObject player3 = Instantiate(ninja, transform);
                player3.transform.SetParent(null);
                player3.GetComponent<Controls>().Cam = camera;
                player3.GetComponent<Controls>().joyStick = joystick;
                nav.player = player3.transform;
                if (SceneManager.GetActiveScene().name == "Tutorial")
                {
                    Tutorial tut = FindObjectOfType<Tutorial>();
                    tut.player = player3;
                }
                break;
        }

        
    }
}
