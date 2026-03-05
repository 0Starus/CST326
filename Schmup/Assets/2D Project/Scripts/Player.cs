using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    public bool canShoot = true;
    public Bullet bullet;
    void Start()
    {
        // todo - get and cache animator
        Bullet.OnBulletHit += OnBulletHit;
    }
    
    void Update()
    {
        if (canShoot && Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {

            canShoot = false;
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            Debug.Log("Bang!");

            // todo - destroy the bullet after 3 seconds
            Destroy(shot, 3f);
            // todo - trigger shoot animation
            Animator animator = GetComponent<Animator>();
            animator.SetTrigger("Shot Trigger");

        }
        if (Keyboard.current != null && Keyboard.current.leftArrowKey.isPressed)
        {
            transform.position = new Vector2(transform.position.x-0.05f,transform.position.y);
        }
        if (Keyboard.current != null && Keyboard.current.rightArrowKey.isPressed)
        {
            transform.position = new Vector2(transform.position.x+0.05f,transform.position.y);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch! -Player");
        
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy_Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        // todo - destroy the bullet
        
        // todo - trigger death animation
        
    }

    void OnBulletHit()
    {
        canShoot = true;
    }
}
