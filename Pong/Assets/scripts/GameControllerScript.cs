using TMPro;
using Unity.Mathematics;
using UnityEngine;

using UnityEngine.InputSystem;
public class GameControllerScript : MonoBehaviour
{
	

    public float paddleSpeed = 1f;
    public float forceStrength = 10f;
	public Rigidbody Paddle1;
	public Rigidbody Paddle2;
	public Rigidbody Ball;
	public TMP_Text score;
	private Paddle _paddle;
	public int player1Score = 0;
	public int player2Score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score.text="0:0";
    }
    void Awake()
    {
		_paddle = new Paddle();
    }

    private void OnEnable()
    {
		_paddle.paddles.p1Up.performed += Onp1Up;
        _paddle.paddles.p1Up.Enable();
		_paddle.paddles.p1Down.performed += Onp1Down;
		_paddle.paddles.p1Down.Enable();
		_paddle.paddles.p2Up.performed += Onp2Up;
		_paddle.paddles.p2Up.Enable();
		_paddle.paddles.p2Down.performed += Onp2Down;
		_paddle.paddles.p2Down.Enable();
    }
	private void OnDisable()
    {
		_paddle.paddles.p1Up.performed -= Onp1Up;
        _paddle.paddles.p1Up.Disable();
		_paddle.paddles.p1Down.performed -= Onp1Down;
		_paddle.paddles.p1Down.Disable();
		_paddle.paddles.p2Up.performed -= Onp2Up;
		_paddle.paddles.p2Up.Disable();
		_paddle.paddles.p2Down.performed -= Onp2Down;
		_paddle.paddles.p2Down.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
	void Onp1Up(InputAction.CallbackContext context)
	{
		Vector3 force = new Vector3(0f, 0f, forceStrength);
		Paddle1.AddForce(force, ForceMode.Force);
	}
	void Onp1Down(InputAction.CallbackContext context)
	{
		Vector3 force = new Vector3(0f, 0f, -forceStrength);
		Paddle1.AddForce(force, ForceMode.Force);
	}
	void Onp2Up(InputAction.CallbackContext context)
	{
		Vector3 force = new Vector3(0f, 0f, forceStrength);
		Paddle2.AddForce(force, ForceMode.Force);
	}
	void Onp2Down(InputAction.CallbackContext context)
	{
		Vector3 force = new Vector3(0f, 0f, -forceStrength);
		Paddle2.AddForce(force, ForceMode.Force);
	}
    void FixedUpdate()
    {
		
	    // if (Keyboard.current.aKey.isPressed)
	    // {
		//     Vector3 force = new Vector3(0f, 0f, forceStrength);
		//     Paddle1.AddForce(force, ForceMode.Force);
	    // }
	    // if (Keyboard.current.dKey.isPressed)
	    // {
		//     Vector3 force = new Vector3(0f, 0f, -forceStrength);
		//     Paddle1.AddForce(force, ForceMode.Force);
	    // }
		// if (Keyboard.current.jKey.isPressed)
	    // {
		//     Vector3 force = new Vector3(0f, 0f, forceStrength);
		//     Paddle2.AddForce(force, ForceMode.Force);
	    // }
	    // if (Keyboard.current.lKey.isPressed)
	    // {
		//     Vector3 force = new Vector3(0f, 0f, -forceStrength);
		//     Paddle2.AddForce(force, ForceMode.Force);
	    // }
	
	    // Vector3 up = Vector3.up;
	    // Quaternion testRotation = Quaternion.Euler(60f, 0f, 0f);

	    // Vector3 rotatedVector = testRotation * up;
    }

	
	public void scorePlayer1()
	{
		player1Score++;
		Debug.Log("Player 1 scored! Player 1's score is: "+player1Score);
		if (player1Score >= 11)
			{
				score.text = "PLAYER 1 WINS!";
				player1Score = 0;
				player2Score = 0;
			}
			else
			{ 
				score.text = player1Score+":"+player2Score;
			}
	}
	public void scorePlayer2()
	{
		player2Score++;
		Debug.Log("Player 2 scored! Player 2's score is: "+player2Score);
		if (player2Score >= 11)
		{
			score.text = "PLAYER 2 WINS!";
			player1Score = 0;
			player2Score = 0;
		}
		else
		{ 
			score.text = player1Score+":"+player2Score;
		}
	}
}
