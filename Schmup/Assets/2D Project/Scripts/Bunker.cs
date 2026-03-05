using UnityEngine;

public class Bunker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Bullet")||collision.gameObject.layer == LayerMask.NameToLayer("Enemy_Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        // todo - destroy the bullet
        
        // todo - trigger death animation
        
    }
}
