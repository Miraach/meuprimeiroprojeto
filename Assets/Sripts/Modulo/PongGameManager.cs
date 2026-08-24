using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PongGameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scorePlayerText;
    [SerializeField] private TextMeshProUGUI scoreEnemyText;
    [SerializeField] private GameObject ball;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private int scoreToWin = 5;
    [SerializeField] private GameObject endGameCanvas;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI recordText;

    private int scorePlayer = 0;
    private int scoreEnemy = 0;

    private void Start() {

    Time.timeScale = 1;
    restartButton.onClick.AddListener(RestartGame);
    menuButton.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene"));
    endGameCanvas.SetActive(false);

    GameData.LoadNames();
    GameData.LoadScores();   
}

    public void PlayerScores()
    {
        scorePlayer++;
        scorePlayerText.text = scorePlayer.ToString();

        if (scorePlayer >= scoreToWin)
        {
            EndGame(true);
        }
        else
        {
            ResetBall();
        }
    }

    public void EnemyScores()
    {
        scoreEnemy++;
        scoreEnemyText.text = scoreEnemy.ToString();

        if (scoreEnemy >= scoreToWin)
        {
            EndGame(false);
        }
        else
        {
            ResetBall();
        }
    }

    private void EndGame(bool playerWon) {
    string vencedor = playerWon ? GameData.PlayerName : GameData.EnemyName;
    resultText.text = "Vitória de " + vencedor;

    if (scorePlayer > GameData.HighScorePlayer) GameData.HighScorePlayer = scorePlayer;
    if (scoreEnemy > GameData.HighScoreEnemy) GameData.HighScoreEnemy = scoreEnemy;
    GameData.SaveScores();

    recordText.text = "Recorde: " + GameData.HighScorePlayer + " x " + GameData.HighScoreEnemy;

    endGameCanvas.SetActive(true);
    restartButton.gameObject.SetActive(true);
    menuButton.gameObject.SetActive(true);

    ball.SetActive(false);
    Time.timeScale = 0;
}

    private void RestartGame()
{
    scorePlayer = 0;
    scoreEnemy = 0;
    scorePlayerText.text = "0";
    scoreEnemyText.text = "0";

    winText.gameObject.SetActive(false);
    restartButton.gameObject.SetActive(false);
    menuButton.gameObject.SetActive(false);
    endGameCanvas.SetActive(false); 

    ball.SetActive(true);

    ball.transform.position = Vector3.zero;

    ball.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

    ball.GetComponent<PongBallController>().SendMessage("LaunchBall", SendMessageOptions.DontRequireReceiver);

    Time.timeScale = 1; 
}

    private void ResetBall()
    {
        ball.transform.position = Vector3.zero;
        ball.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }
}