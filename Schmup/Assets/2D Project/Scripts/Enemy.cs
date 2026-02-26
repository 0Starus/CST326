using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDiedFunc(float points);
    public static EnemyDiedFunc OnEnemyDied;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
        
        if(collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            OnEnemyDied.Invoke(10f);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        // todo - destroy the bullet
        
        // todo - trigger death animation
        
    }
}
