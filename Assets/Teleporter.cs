using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private GameEvent onTeleporting;

    private void OnTriggerEnter(Collider other)
    {
        onTeleporting.Raise();
    }
}
