using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour
{
    public delegate void EnemyDiedFunc(int points);
    public static EnemyDiedFunc OnEnemyDied;
    public GameObject bulletPrefab;
    private AudioSource audioSource;
    public AudioClip tic;
    public AudioClip tac;
    public AudioClip shoot;
    public AudioClip death;
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
            audioSource.PlayOneShot(shoot);
            Animator animator = GetComponent<Animator>();
            animator.SetTrigger("ShotTrigger");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
        
        if(collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            audioSource.PlayOneShot(death);
            Destroy(collision.gameObject);
            Animator animator = GetComponent<Animator>();
            animator.SetTrigger("IsDead");
            StartCoroutine(WaitForDeath());
            
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
    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(5f);
        OnEnemyDied.Invoke(worth);
        Destroy(gameObject);
    }
}
