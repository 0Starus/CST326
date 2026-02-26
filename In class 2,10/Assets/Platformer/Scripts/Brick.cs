using UnityEngine;

public class Brick : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public delegate void BrickHitFunc();
    public static BrickHitFunc OnBrickHit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Brick hit");
        OnBrickHit.Invoke();
        Destroy(gameObject);
    }
}
