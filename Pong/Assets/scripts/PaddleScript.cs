using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public int playerNum;
    public GameControllerScript gameSctipt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SpeedBoost")
        {
            gameSctipt.SpeedUpCollected(playerNum);
            Destroy(collision.gameObject);
        } else if (collision.gameObject.tag == "HyperSpeed")
        {
            gameSctipt.HyperSpeedCollected();
            Destroy(collision.gameObject);
        } else if (collision.gameObject.tag == "Stunner")
        {
            gameSctipt.StunnerCollected(playerNum);
            Destroy(collision.gameObject);
        }
    }
}
