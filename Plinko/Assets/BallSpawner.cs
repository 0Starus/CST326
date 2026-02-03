using UnityEngine;

using UnityEngine.InputSystem;

public class BallSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject ballPrefab;
    public int timer;
    public int score;
    public Transform spawner;
    void Start() 
    {
        Instantiate(ballPrefab);
        timer = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer--;
        }
        if (Keyboard.current.spaceKey.isPressed)
        {
            if(timer == 0)
            {
                float randomizer = Random.Range(-1f, 1f); 
                Transform myTransform = GetComponent<Transform>();
                myTransform.position += Vector3.right*randomizer;
                Instantiate(ballPrefab,myTransform.position, Quaternion.identity);
                myTransform.position -= Vector3.right*randomizer;
                timer = 100;
            }
        }
    }
}

