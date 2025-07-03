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
        scoreText.text = "BLUE  " + gameManager.scoreP1 + " - " + gameManager.scoreP2 + "  RED";
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


    // appelé quand la balle entre en collision avec le but
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
                gameManager.scoreP1++;  // P1 marque si balle dans goal P2
            }

            Debug.Log("Score P1: " + scoreP1 + ",core P2: " + scoreP2);
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
