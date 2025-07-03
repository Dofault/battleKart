using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int scoreP1 = 0;
    public int scoreP2 = 0;

    public bool isPaused = false;

    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI timerText;

    public float gameTime = 40f; // secondes
    private bool gameEnded = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        timerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameEnded)
        {
            TogglePause();
        }

        if (!isPaused && !gameEnded)
        {
            gameTime -= Time.deltaTime; // delta time indépendant du framerate
            timerText.text = Mathf.Ceil(gameTime).ToString(); // donne l'entier supérieur 

            if (gameTime <= 0f)
            {
                EndGame();
            }
        }

        if (gameEnded && Input.anyKeyDown)
        {
            ReturnToMenu();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // vitesse du jeu 
            scoreText.text = "BLUE  " + scoreP1 + " - " + scoreP2 + "  RED\n<size=60%>Appuyez sur Echap pour reprendre le jeu</size>";
        }
        else
        {
            scoreText.text = "BLUE  " + scoreP1 + " - " + scoreP2 + "  RED";
            Time.timeScale = 1f;
        }
    }

    void EndGame()
    {
        gameEnded = true;
        Time.timeScale = 0f;

        string winner = scoreP1 > scoreP2 ? "Victoire du bles !" : (scoreP2 > scoreP1 ? "Victoire du rouge !" : "MATCH NUL !");
        scoreText.text = winner + "\n<size=60%>Appuyez sur une touche pour revenir au menu</size>";
    }

    void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene"); // il faut ajouter la scène aux scenes public dans les parametres du build
    }

    public void IncrementScore(bool isPlayer1)
    {
        if (isPlayer1)
            scoreP1++;
        else
            scoreP2++;

        Debug.Log("Score P1: " + scoreP1 + " P2: " + scoreP2);
    }

    public void ResetScores()
    {
        scoreP1 = 0;
        scoreP2 = 0;
        Debug.Log("Scores reset à 0");
    }
}
