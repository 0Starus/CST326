using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totScore = 0;
    public int hiScore = 0;
    int enemiesLeft = 4;
    public TMP_Text scoreText;
    public TMP_Text hiScoreText;
    void Start()
    {
       // todo - sign up for notification about enemy death 
       hiScore = PlayerPrefs.GetInt("HiScore",0);
       string hiScoreString = hiScore.ToString("0000");
       hiScoreText.text = "HiScore: "+hiScoreString;
       Enemy.OnEnemyDied += OnEnemyDied;
    }

    void OnDestroy()
    {
        Enemy.OnEnemyDied -= OnEnemyDied;        
    }

    void OnEnemyDied(int score)
    {
        totScore += score;
        if(totScore > hiScore)
        {
            hiScore = totScore;
            string hiScoreString = hiScore.ToString("0000");
            hiScoreText.text = "HiScore: "+hiScoreString;
            PlayerPrefs.SetInt("HiScore",hiScore);
            PlayerPrefs.Save();
        }
        string newScore = totScore.ToString("0000");
        scoreText.text = "Score: "+newScore;
        enemiesLeft--;
        if(enemiesLeft == 0)
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
