using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinConverter : MonoBehaviour
{
    private int score;
    public int coins;
    private float barFill;
    
    [Header("Settings")]
    public float animationDuration = 2f;
    public float waitDuration = 1f;

    [Header("Assignments")]
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI coinsText;
    [SerializeField]
    private Image barMask;

    public void CollectData()
    {
        score = int.Parse(scoreText.text);
        coins = GameManager.instance.Coins;
        coinsText.text = coins.ToString();
        barFill = barMask.fillAmount;
    }

    public void StartScoreToCoinsConversion()
    {
        StartCoroutine(AnimateScoreToCoins());
    }

    IEnumerator AnimateScoreToCoins()
    {
        Debug.Log("began coroutine");
        float elapsedTime = 0;
        int startingCoins = coins;
        int startingScore = score;
        float startingBarFill = barFill;

        yield return new WaitForSeconds(waitDuration);

        Debug.Log("waited");

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / animationDuration;
                
            score = (int)Mathf.Lerp(startingScore, 0, t);
            coins = (int)Mathf.Lerp(startingCoins, startingCoins+startingScore, t);
            barFill = Mathf.Lerp(startingBarFill, 0f, t);
            if (Time.frameCount % 5 == 0)
            {
                UpdateUI();
            }

            yield return new WaitForEndOfFrame();
        }

        Debug.Log("finished");
        score = 0;
        coins = startingCoins + startingScore;
        barMask.fillAmount = 0f;
        UpdateUI();

        GameManager.instance.Coins = coins;
    }

    void UpdateUI()
    {
        scoreText.text = score.ToString();
        coinsText.text = coins.ToString();
        barMask.fillAmount = barFill;
    }
}
