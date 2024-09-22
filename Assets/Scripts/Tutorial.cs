using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private bool sectionOneDone = false;
    private bool sectionTwoDone = false;

    private int triggers = 0;
    private float delay = 3f;
    
    [SerializeField] private GameObject canvas;
    [SerializeField] private TextMeshProUGUI textOne;
    [SerializeField] private TextMeshProUGUI textTwo;
    [SerializeField] private TextMeshProUGUI textThree;
    [SerializeField] private TextMeshProUGUI textFour;
    [SerializeField] private TextMeshProUGUI countdown;

    [SerializeField] private Transform sectionTwo;
    
    [SerializeField] public GameObject player;
    [SerializeField] private GameObject chef;

    private void Start()
    {
        StartCoroutine("stepOne");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggers++;
            if (triggers == 2)
            {
                StartCoroutine("stepTwo");
            }
            else if (triggers == 3)
            {
                StartCoroutine("stepThree");
            }
            else if (triggers == 4)
            {
                StartCoroutine("stepFour");
            }
        }
        
    }

    private IEnumerator stepOne()
    {
        bool done = false;
        while (!done)
        {
            textOne.gameObject.SetActive(true);
            textOne.text = "Collect Food!";
            textOne.GetComponent<Animator>().Play("Play");
            yield return new WaitForSeconds(delay);
            textOne.gameObject.SetActive(false);

            done = true;
        }
        
    }

    private IEnumerator stepTwo() {
        bool done = false;
        while (!done)
        {
            textTwo.gameObject.SetActive(true);

            textTwo.text = "Use Doors To Navigate & Escape!";
            textTwo.GetComponent<Animator>().Play("Play");
            yield return new WaitForSeconds(delay);
            textTwo.gameObject.SetActive(false);
            done = true;
        }

            
    }

    private IEnumerator stepThree()
    {
        bool done = false;
        while (!done)
        {

            textThree.text = "Unlock The Door By Collecting Enough Food While Escaping The Chef!";
            textThree.GetComponent<Animator>().Play("Play");
            yield return new WaitForSeconds(delay);
            textThree.gameObject.SetActive(true);
            yield return new WaitForSeconds(delay);
            textThree.gameObject.SetActive(false);
            done = true;
        }
        

    }

    private IEnumerator stepFour()
    {
        textFour.gameObject.SetActive(true);

        textFour.text = "Strive For A Full Clear By Collecting All Foods!";
        textFour.GetComponent<Animator>().Play("Play");
        yield return new WaitForSeconds(delay);
        textFour.gameObject.SetActive(false);

    }

    public void StartTeleportation()
    {
        StartCoroutine("Teleporting");
        triggers++;
        StartCoroutine("stepThree");
    }

    public IEnumerator Teleporting()
    {
        float t = delay;

        // Ensure the countdown object is active before starting the countdown
        countdown.gameObject.SetActive(true);

        // Set the countdown text color to fully visible
        countdown.color = new Color(countdown.color.r, countdown.color.g, countdown.color.b, 255);

        while (t > 0f)
        {

            // Update the countdown text based on the remaining time
            countdown.text =  "Teleporting in: " + Mathf.Ceil(t).ToString() + "...";

            // Decrement the timer
            t -= Time.deltaTime;

            // Yield to the next frame to allow other processes
            yield return null;
        }

        // Teleport the player after the countdown finishes
        player.transform.position = sectionTwo.transform.position;

        // Hide the countdown object
        countdown.gameObject.SetActive(false);
    }




}
