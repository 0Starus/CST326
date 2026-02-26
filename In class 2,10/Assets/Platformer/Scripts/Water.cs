using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public delegate void WaterHitFunc();
    public static WaterHitFunc OnWaterHit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Water hit");
        OnWaterHit.Invoke();
    }
}
