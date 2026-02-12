using UnityEngine;
using Unity.Mathematics;

public class BallScript : MonoBehaviour
{
    public float ballSpeed = 20f;

	public Vector3 ballVector;

	public GameControllerScript GameController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody Ball = GetComponent<Rigidbody>();
        Vector3 force = new Vector3(math.sqrt(ballSpeed/2),0f,math.sqrt(ballSpeed/2));
		Ball.AddForce(force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody Ball = GetComponent<Rigidbody>();
		ballVector = Ball.linearVelocity;
    }

    void OnCollisionEnter(Collision collision)
    {
		//get reference
        Rigidbody Ball = GetComponent<Rigidbody>();
		Vector3 force = new Vector3(0f,0f,0f);
		if (collision.gameObject.tag == "paddle")
		{
			ballSpeed= ballSpeed*5f;
			force = new Vector3(-ballVector.x*5f,0f,ballVector.z*5f);
			Debug.Log("hit paddle");
			GameController.hitPaddle();
		}
		else
		{
			force = new Vector3(ballVector.x,0f,-ballVector.z);
			Debug.Log("hit wall");
		}
		// force.Normalize();
		// Debug.Log(force);
		Ball.linearVelocity = force;
		
    }

	public void hyperSpeedPowerUp()
	{
		ballSpeed = ballSpeed*5;
		Rigidbody Ball = GetComponent<Rigidbody>();
		Ball.linearVelocity*=ballSpeed;
		
	}
    void OnTriggerEnter(Collider collider)
    {
    	if (collider.gameObject.tag=="paddle 1 zone")
    	{
    		GameController.scorePlayer2();
    		ballSpeed = 10f;
    		Rigidbody Ball = GetComponent<Rigidbody>();
    		Ball.angularVelocity = Vector3.zero;
    		Ball.linearVelocity = Vector3.zero;
    		Ball.transform.position = new Vector3(20f,0f,0f);
    		Vector3 force = new Vector3(-math.sqrt(ballSpeed/2),0f,math.sqrt(ballSpeed/2));
    		Ball.AddForce(force, ForceMode.Impulse);
			
    	}
    	else if (collider.gameObject.tag=="paddle 2 zone")
    	{
    		GameController.scorePlayer1();
    		ballSpeed = 10f;
    		Rigidbody Ball = GetComponent<Rigidbody>();
    		Ball.angularVelocity = Vector3.zero;
    		Ball.linearVelocity = Vector3.zero;
    		Ball.transform.position = new Vector3(20f,0f,0f);
    		Vector3 force = new Vector3(math.sqrt(ballSpeed/2),0f,math.sqrt(ballSpeed/2));
    		Ball.AddForce(force, ForceMode.Impulse);
    	}
    }
}
