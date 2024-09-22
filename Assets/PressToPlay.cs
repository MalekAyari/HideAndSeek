using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PressToPlay : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            // Determine the position of the click or touch
            Vector2 position;
            if (Input.touchCount > 0)
            {
                position = Input.GetTouch(0).position;
            }
            else
            {
                position = Input.mousePosition;
            }

            // Convert position to a raycast
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
            {
                position = position
            };

            // Raycast against the UI
            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, raycastResults);

            // Check if any UI element with tag "Button" was hit
            bool isButtonHit = false;
            foreach (RaycastResult r in raycastResults)
            {
                if (r.gameObject.CompareTag("Button"))
                {
                    isButtonHit = true;
                    break;
                }
            }

            // If no UI element with tag "Button" was hit, proceed with your action
            if (!isButtonHit)
            {
                PlayLatestLevel();
            }
        }
    }
    public void PlayLatestLevel()
    {
        if (GameManager.instance.Level == 0)
        {
            SceneManager.LoadScene("Tutorial");
        } else
        {
            SceneManager.LoadScene("Level " + GameManager.instance.Level.ToString());

        }
    }
}