using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{

    private GameManager gameManager;

    private int scoreP1 = 0;
    private int scoreP2 = 0;

    public Transform player1;
    public Transform player2;
    public Transform ball;

    private Vector3 player1StartPos;
    private Vector3 player2StartPos;
    private Vector3 ballStartPos;

    public TextMeshProUGUI scoreText;

    void UpdateScoreUI()
    {
        scoreText.text = "P1: " + gameManager.scoreP1 + " - " + gameManager.scoreP2 + " :P2";
    }

    void Start()
    {

        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        gameManager = GameManager.Instance;  //  singleton 

        UpdateScoreUI();
    }

    void Awake()
    {
        player1StartPos = player1.position;
        player2StartPos = player2.position;
        ballStartPos = ball.position;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ball"))
        {
            if (this.CompareTag("Goal1")) 
            {
                gameManager.scoreP2++;  
            }
            else if (this.CompareTag("Goal2")) 
            {
                gameManager.scoreP1++;  // Si la balle rentre dans le goal de P2, P1 marque
            }

            Debug.Log("Score P1: " + scoreP1 + " | Score P2: " + scoreP2);
            UpdateScoreUI();
            ResetPositions();
        }
    }

    void ResetPositions()
    {
        player1.position = player1StartPos;
        player2.position = player2StartPos;
        ball.position = ballStartPos;

        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        if (ballRb != null)
        {
            ballRb.linearVelocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
        }
    }
}
