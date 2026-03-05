using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public delegate void BulletHitFunc();
    public static BulletHitFunc OnBulletHit;
    public float speed = 5;
    public Player player;

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * speed;
        Debug.Log("Wwweeeeee");
    }
    void OnDestroy()
    {
        OnBulletHit.Invoke();
    }
}
