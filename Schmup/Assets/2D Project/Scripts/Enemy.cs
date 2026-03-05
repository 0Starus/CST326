using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDiedFunc(int points);
    public static EnemyDiedFunc OnEnemyDied;
    public GameObject bulletPrefab;
    private AudioSource audioSource;
    public AudioClip tic;
    public AudioClip tac;
    public int worth = 10;
    int timerShoot = 70;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        timerShoot--;
        
        if (timerShoot == 0)
        {
            GameObject shot = Instantiate(bulletPrefab, new Vector2(transform.position.x,transform.position.y-2.56f), Quaternion.identity);
            Destroy(shot, 3f);
            timerShoot= 70;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
        
        if(collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            OnEnemyDied.Invoke(worth);
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
