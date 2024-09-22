using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType{
        Burger,
        Hotdog,
        Pizza
    }

    [SerializeField] public CollectibleType type;    

    [SerializeField] private float FloatSpeed = 0.33f;
    [SerializeField] private float RotationSpeed = 1;

    [Header("Events")]
    [SerializeField] private GameEvent Hotdog;
    [SerializeField] private GameEvent Burger;
    [SerializeField] private GameEvent Pizza;


    private float position = 0;
    private bool rising = true;

    

    public void rotateAnimation(float speed){
        transform.Rotate(0f,Time.deltaTime%360f*speed,0f);
    }

    public void floatAnimation(float speed){       
        if (rising){
            transform.Translate(0f, Time.deltaTime*speed, 0f);
            if (position + Time.deltaTime*speed > 0.25f){
                rising = false;
            } else {
                position += Time.deltaTime;
            }
        } else {
            transform.Translate(0f, -Time.deltaTime*speed, 0f);
            if (position - Time.deltaTime*speed < -0.25f){
                rising = true;
            } else {
                position -= Time.deltaTime;            
            }
        }
    }

    private void FixedUpdate() {
        rotateAnimation(RotationSpeed);
        floatAnimation(FloatSpeed);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){
            Destroy(gameObject);
            if (type == CollectibleType.Burger)
            {
                Burger.Raise();
            } 
            else if (type == CollectibleType.Pizza)
            {
                Pizza.Raise();
            }
            else 
            {
                Hotdog.Raise();
            }
        }
    }
}
