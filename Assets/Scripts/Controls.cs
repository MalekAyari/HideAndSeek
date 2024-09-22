using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Controls : MonoBehaviour
{

    [SerializeField] public VariableJoystick joyStick;
    [SerializeField] private Animator animator;
    [SerializeField] public GameObject Cam;
    [SerializeField] public float speed;
    [SerializeField] private Transform stomach;
    [SerializeField] private Transform Head;
    [SerializeField] private Transform LeftArm;
    [SerializeField] private Transform RightArm;
    [SerializeField] private GameObject StarEffect;
    [SerializeField] private GameObject SpecialStarEffect;
    [SerializeField] private GameObject cage;
    [SerializeField] private GameObject smoke;

    private bool spawned = false;
    private int starCounter = 0;

    private float maxSlow = 2;
    private float slowPerCollect;
    private Rigidbody rb;
    private bool playing = true;

    private float rescaleValue = 0.91f;

    float maxScale = 1.05f;
    float scale = 1f;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        slowPerCollect = SlowMultiplier();
        maxScale = 1.05f;
        scale = 1f;
    }
    
    private void FixedUpdate() {
        
        if (playing){
            rb.velocity = new Vector3(joyStick.Horizontal * speed, rb.velocity.y, joyStick.Vertical * speed);

            if (joyStick.Horizontal != 0 || joyStick.Vertical != 0)
            {
                animator.Play("Running");
                transform.rotation = Quaternion.LookRotation(rb.velocity);
            }
            else
            {
                animator.Play("Idle");
                transform.rotation = Quaternion.LookRotation(Vector3.zero);
            }

            Cam.transform.position = transform.position + new Vector3(0f,7.19999981f,-7.61999989f);
        }
        
    }

    public void CollectHotdog()
    {
        Transform rescale = stomach.GetChild(0);
        float maxScale = 1.05f;
        float scale = 1f;

        if (stomach.localScale.y < 3f)
        {
            stomach.localScale *= 1.05f;
            rescale.localScale *= 0.95f;

        }
        
        speed -= slowPerCollect;
    }

    public void CollectBurger()
    {
        Transform rescale = stomach.GetChild(0);
        
        if(stomach.localScale.y <= 3f)
        {
            stomach.localScale *= 1.05f;
            rescale.localScale *= 0.95f;
        }
        

        speed -= slowPerCollect;

    }

    public void CollectPizza()
    {
        
        Transform rescale = stomach.GetChild(0);
        float maxScale = 1.3f;
        float scale = 1f;

        if (stomach.localScale.y <= 3f)
        {
            stomach.localScale *= 1.05f;
            rescale.localScale *= 0.95f;

        }
        
        speed -= slowPerCollect;

    }

    public float SlowMultiplier()
    {
        float localSlow = 0;
        foreach (Collectible obj in FindObjectsOfType<Collectible>())
        {
            switch (obj.type)
            {
                case (Collectible.CollectibleType.Hotdog):
                    localSlow += 1.2f;
                    break;
                case (Collectible.CollectibleType.Burger):
                    localSlow += 2.4f;
                    break;
                case (Collectible.CollectibleType.Pizza):
                    localSlow += 6;
                    break;
            }
        }

        return maxSlow/localSlow;
    }

    public void SpawnStarVFX()
    {
        if (starCounter >= 2)
        {
            GameObject stars = Instantiate(SpecialStarEffect, transform);
            stars.transform.position += new Vector3(0f, 1f, 0f);
            stars.transform.parent = null;
        } else
        {
            GameObject stars = Instantiate(StarEffect, transform);
            stars.transform.position += new Vector3(0f, 1f, 0f);
            stars.transform.parent = null;
            starCounter++;
        }
    }
    public void GameOver(){
        if (!spawned)
        {
            Instantiate(cage, transform);
            Instantiate(smoke, transform);
            spawned = true;
        }
        
        playing = false;
        rb.velocity = Vector3.zero;
        rb.rotation = Quaternion.identity;
        animator.Play("Lose");
    }
}
