using UnityEngine;

using UnityEngine.InputSystem;

public class BallSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject ballPrefab;
    public int timer;
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
                Transform myTransform = GetComponent<Transform>();
                Instantiate(ballPrefab,myTransform.position, Quaternion.identity);
                timer = 100;
            }
        }
    }
}

