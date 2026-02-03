using UnityEngine;

using UnityEngine.InputSystem;
public class PaddleScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float paddleSpeed = 1f;
    public float forceStrength = 10f;

    void FixedUpdate()
    {
	    if (Keyboard.current.aKey.isPressed)
	    {
		    Vector3 force = new Vector3(0f, 0f, forceStrength);
		    Rigidbody rBody = GetComponent<Rigidbody>();
		    rBody.AddForce(force, ForceMode.Force);
	    }
	    if (Keyboard.current.dKey.isPressed)
	    {
		    Vector3 force = new Vector3(0f, 0f, -forceStrength);
		    Rigidbody rBody = GetComponent<Rigidbody>();
		    rBody.AddForce(force, ForceMode.Force);
	    }
	
	    Vector3 up = Vector3.up;
	    Quaternion testRotation = Quaternion.Euler(60f, 0f, 0f);

	    Vector3 rotatedVector = testRotation * up;
    }
}
