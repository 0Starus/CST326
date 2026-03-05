using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5;

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * speed;
    }
}
