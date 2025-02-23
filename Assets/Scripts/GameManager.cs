using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private Coins[] coins;

    private void Start()
    {
        coins = FindObjectsByType<Coins>(FindObjectsSortMode.None);

        foreach (Coins coin in coins)
        {
            coin.OnCoinCollected.AddListener(IncrementScore);
        }
    }
    private void IncrementScore()
    {
        score++;
        Debug.Log(score);
        scoreText.text = $"Score: {score}";
    }
}
