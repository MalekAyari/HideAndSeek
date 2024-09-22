using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private GameEvent OnExit;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("You Win");

        if (other.gameObject.tag == "Player")
        {
            OnExit.Raise();
        }
    }

}
