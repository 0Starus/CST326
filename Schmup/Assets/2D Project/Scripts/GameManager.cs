using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float totScore = 0;
    int enemiesLeft = 1;
    void Start()
    {
       // todo - sign up for notification about enemy death 
       Enemy.OnEnemyDied += OnEnemyDied;
    }

    void OnDestroy()
    {
        Enemy.OnEnemyDied -= OnEnemyDied;        
    }

    void OnEnemyDied(float score)
    {
        totScore += score;
        enemiesLeft--;
        if(enemiesLeft == 0)
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
