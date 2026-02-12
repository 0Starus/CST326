using TMPro;
using Unity.Mathematics;
using UnityEngine;

using UnityEngine.InputSystem;
public class GameControllerScript : MonoBehaviour
{
	

    public float paddle1Speed = 10f;
	public float paddle2Speed = 10f;
	public Rigidbody Paddle1;
	public Rigidbody Paddle2;
	public Rigidbody Ball;
	public TMP_Text score;
	private Paddle _paddle;
	public int player1Score = 0;
	public int player2Score = 0;

	public bool p1hasStun =false;
	public bool p2hasStun =false;
	public bool p1Stunned = false;
	public bool p2Stunned = false;
	public AudioSource audioControl;
	public AudioClip hitSound;

	public GameObject SpeedBoostPrefab;
	public GameObject HyperSpeedPrefab;
	public GameObject StunnerPrefab;
	public BallScript BallScript;
	public int StunTimer = 250;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score.text=player1Score+":"+player2Score;
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
		_paddle.paddles.Stun.performed += OnStun;
		_paddle.paddles.Stun.Enable();
		
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
		_paddle.paddles.Stun.performed -= OnStun;
		_paddle.paddles.Stun.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
	public void SpeedUpCollected(int collector)
	{
		if (collector == 1)
		{
			paddle1Speed*=5f;
			Debug.Log("Player 1 collected a SpeedBoost!");
		}
		else
		{
			paddle2Speed*=5f;
			Debug.Log("Player 2 collected a SpeedBoost!");
		}
	}
	public void StunnerCollected(int collector)
	{
		if (collector == 1)
		{
			p1hasStun = true;
			Debug.Log("Player 1 collected a Stunner!");
		}
		else
		{
			p2hasStun = true;
			Debug.Log("Player 2 collected a Stunner!");
		}
	}
	public void HyperSpeedCollected()
	{
		BallScript.hyperSpeedPowerUp();
		Debug.Log("Ball going into HYPERSPEED!");
	}

	void Onp1Up(InputAction.CallbackContext context)
	{
		Vector3 force = new Vector3(0f, 0f, paddle1Speed);
		Paddle1.AddForce(force, ForceMode.Force);
	}
	void Onp1Down(InputAction.CallbackContext context)
	{
		Vector3 force = new Vector3(0f, 0f, -paddle1Speed);
		Paddle1.AddForce(force, ForceMode.Force);
	}
	void Onp2Up(InputAction.CallbackContext context)
	{
		Vector3 force = new Vector3(0f, 0f, paddle2Speed);
		Paddle2.AddForce(force, ForceMode.Force);
	}
	void Onp2Down(InputAction.CallbackContext context)
	{
		Vector3 force = new Vector3(0f, 0f, -paddle2Speed);
		Paddle2.AddForce(force, ForceMode.Force);
	}
	void OnStun(InputAction.CallbackContext context)
	{
		if (p1hasStun)
		{
			p1hasStun = false;
			Debug.Log("Player 2 is stunned!");
			_paddle.paddles.p2Up.performed -= Onp2Up;
			_paddle.paddles.p2Up.Disable();
			_paddle.paddles.p2Down.performed -= Onp2Down;
			_paddle.paddles.p2Down.Disable();
			p2Stunned = true;
		}
		if (p2hasStun)
		{
			p2hasStun = false;
			Debug.Log("Player 1 is stunned!");
			_paddle.paddles.p1Up.performed -= Onp2Up;
			_paddle.paddles.p1Up.Disable();
			_paddle.paddles.p1Down.performed -= Onp2Down;
			_paddle.paddles.p1Down.Disable();
			p2Stunned = true;
		}
	}
	void UnStun()
	{
		if (p1Stunned)
		{
			_paddle.paddles.p1Up.performed += Onp1Up;
        	_paddle.paddles.p1Up.Enable();
			_paddle.paddles.p1Down.performed += Onp1Down;
			_paddle.paddles.p1Down.Enable();
			Debug.Log("Player 1 is no longer stunned!");
		}
		else
		{
			_paddle.paddles.p2Up.performed += Onp2Up;
			_paddle.paddles.p2Up.Enable();
			_paddle.paddles.p2Down.performed += Onp2Down;
			_paddle.paddles.p2Down.Enable();
			Debug.Log("Player 2 is no longer stunned!");
		}
	}
    void FixedUpdate()
	{
		if (p1Stunned||p2Stunned)
		{
			StunTimer--;
			if(StunTimer == 0)
			{
				UnStun();
				p1Stunned = false;
				p2Stunned = false;
				StunTimer = 250;
			}
		}
	}
	
	public void hitPaddle()
	{
		audioControl.PlayOneShot(hitSound, 1.0f);
		audioControl.pitch*=1.2f;
	}
	void Reset()
    {
		player1Score = 0;
		player2Score = 0;
		p1hasStun = false;
		p2hasStun = false;
		paddle1Speed=10f;
		paddle2Speed=10f;
    }
	public void scorePlayer1()
	{
		audioControl.pitch = 1.0f;
		player1Score++;
		Debug.Log("Player 1 scored! Player 1's score is: "+player1Score);
		if (player1Score >= 11)
			{
				score.text = "PLAYER 1 WINS!";
				Reset();
			}
			else
			{ 
				score.text = player1Score+":"+player2Score;
				if(player1Score == 5)
				{
					spawnPowerUp(1,"SpeedBoost");
				} else if(player1Score == 7)
				{
					spawnPowerUp(1,"HyperSpeed");
				} else if(player1Score == 10)
				{
					spawnPowerUp(1,"Stunner");
				}
			}
	}
    public void scorePlayer2()
	{
		audioControl.pitch = 1.0f;
		player2Score++;
		Debug.Log("Player 2 scored! Player 2's score is: "+player2Score);
		if (player2Score >= 11)
		{
			score.text = "PLAYER 2 WINS!";
			Reset();
		}
		else
		{ 
			score.text = player1Score+":"+player2Score;
			if(player2Score == 5)
			{
				spawnPowerUp(2,"SpeedBoost");
			} else if(player2Score == 7)
			{
				spawnPowerUp(2,"HyperSpeed");
			} else if(player2Score == 10)
			{
				spawnPowerUp(2,"Stunner");
			}
		}
	}
	public void spawnPowerUp(int player, string powerUp)
	{
		bool isHyper =false;
		Vector3 newPosition = new Vector3(0f, 0f, 0f);
		GameObject item = Instantiate(StunnerPrefab);
		if(powerUp == "SpeedBoost")
		{
			item = Instantiate(SpeedBoostPrefab);
		} else if (powerUp == "HyperSpeed")
		{
			item = Instantiate(HyperSpeedPrefab);
			isHyper= true;
		} else if (powerUp == "Stunner")
		{
			item = Instantiate(StunnerPrefab);
		}
        Transform itemPos = item.transform;
		Rigidbody itemBody = item.GetComponent<Rigidbody>();
		Vector3 force = new Vector3(0f,0f,0f);
		if((player == 1&&!isHyper)||(player == 2&&isHyper))
		{
			force = new Vector3(20f,0f,0f);
			newPosition = new Vector3(25f, 0f, 0f);
		}
		else
		{
			force = new Vector3(-20f,0f,0f);
			newPosition = new Vector3(15f, 0f, 0f);
		}
		itemPos.position = newPosition;
    	itemBody.AddForce(force, ForceMode.Impulse);
	}
}
