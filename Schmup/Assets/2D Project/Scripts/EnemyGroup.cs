using Unity.VisualScripting;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject enemyPrefab;
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public Enemy enemy1;
    public Transform enemies;
    int timerMove = 50;
    //float direction = -2.56f;
    public float direction = -.5f;
    int speed = 1;
    void Start()
    {
        //Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
        Vector2 truePos = gameObject.transform.position;
        Transform newEnemy = Instantiate(enemyPrefab.transform, enemies);
        newEnemy.position = truePos;
        Transform newEnemy2 = Instantiate(enemy1Prefab.transform, enemies);
        newEnemy2.position = new Vector2(truePos.x-2.56f,truePos.y);
        Transform newEnemy3 = Instantiate(enemy2Prefab.transform, enemies);
        newEnemy3.position = new Vector2(truePos.x+2.56f,truePos.y);
        Transform newEnemy4 = Instantiate(enemy3Prefab.transform, enemies);
        newEnemy4.position = new Vector2(truePos.x+5.12f,truePos.y);
        Enemy.OnEnemyDied += OnEnemyDied;
    }

    // Update is called once per frame
    void Update()
    {
        timerMove--;
        if(timerMove == 0)
        {
            transform.position = new Vector2(transform.position.x+direction,transform.position.y);
            timerMove = 50;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("LBarrier"))
        {
            direction =.5f*speed;
            transform.position = new Vector2(transform.position.x+direction,transform.position.y-.5f);
        }
        if (collision.gameObject.CompareTag("RBarrier"))
        {
            direction=-.5f*speed;
            transform.position = new Vector2(transform.position.x+direction,transform.position.y-.5f);
        }
    }
    void OnEnemyDied(int score)
    {
        speed++;
    }
}
