using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDiedFunc(float points);
    public static EnemyDiedFunc OnEnemyDied;
    private AudioSource audioSource;
    public AudioClip tic;
    public AudioClip tac;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
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
    public void moveLeft()
    {
        audioSource.PlayOneShot(tic);
    }
    public void moveRight()
    {
        audioSource.PlayOneShot(tac);
    }
}
