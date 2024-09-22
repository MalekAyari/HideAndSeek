using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyGround : MonoBehaviour
{
    public PhysicMaterial state;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CapsuleCollider capsuleCollider = other.GetComponent<CapsuleCollider>();
            capsuleCollider.material = state;
            Debug.Log("Sliding");
        }
    }
}
