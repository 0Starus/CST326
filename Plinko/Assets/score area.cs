using UnityEngine;

public class scorearea : MonoBehaviour
{
    public int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter (Collider other)
    {
        other.gameObject.SetActive(false);    
    }
}
