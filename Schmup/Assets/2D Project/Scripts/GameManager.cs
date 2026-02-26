using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float totScore = 0;
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
    }
}
