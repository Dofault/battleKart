using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int scoreP1 = 0;
    public int scoreP2 = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); // Evite multiples instances
    }

    public void IncrementScore(bool isPlayer1)
    {
        if (isPlayer1)
            scoreP1++;
        else
            scoreP2++;

        Debug.Log("Score P1: " + scoreP1 + " | Score P2: " + scoreP2);
    }

    public void ResetScores()
    {
        scoreP1 = 0;
        scoreP2 = 0;
        Debug.Log("Scores reset to 0");
    }
}