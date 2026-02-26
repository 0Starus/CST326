using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Mario : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float groundAcceleration = 15f;
    public float apexHeight = 4.5f;
    public float apexTime = .5f;
    public LevelParser level;
    Vector2 _velocity;
    CharacterController _controller;
    Animator _animator;
    Quaternion facingRight;
    Quaternion facingLeft;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        facingRight = Quaternion.Euler(0f,90f,0f);
        facingLeft = Quaternion.Euler(0f,270f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        float direction = 0f;
        if(Keyboard.current.dKey.isPressed) direction += 1f;
        if(Keyboard.current.aKey.isPressed) direction -= 1f;
        bool jumpPressedThisFrame = Keyboard.current.spaceKey.wasPressedThisFrame;
        bool jumpHeld = Keyboard.current.spaceKey.isPressed;
        bool runHeld = Keyboard.current.shiftKey.isPressed;

        float gravityMod = 1f;

        if (_controller.isGrounded)
        {
            if (direction!= 0f)
            {
                if (Mathf.Sign(direction) != Mathf.Sign(_velocity.x))
                {
                    _velocity.x = 0f;
                }
                _velocity.x += direction*groundAcceleration * Time.deltaTime;
                if (runHeld)
                {
                    _velocity.x = Mathf.Clamp(_velocity.x,-walkSpeed*5,walkSpeed*5);
                }
                else
                {
                    _velocity.x = Mathf.Clamp(_velocity.x,-walkSpeed,walkSpeed);
                }

                transform.rotation = (direction >0f) ? facingRight : facingLeft;
            }
            else
            {
                _velocity.x = Mathf.MoveTowards(_velocity.x,0f,groundAcceleration*Time.deltaTime);
            }
            if (jumpPressedThisFrame)
            {
                _velocity.y = 2f*apexHeight/apexTime;
            }
        }
        else
        {
            if (!jumpHeld)
            {
                gravityMod = 2f;
            }
        }

        float gravity = 2f*apexHeight/(apexTime*apexTime);
        _velocity.y -= gravity*gravityMod*Time.deltaTime;
       
        float deltaX = _velocity.x*Time.deltaTime;
        float deltaY = _velocity.y*Time.deltaTime;
        Vector3 deltaPosition = new Vector3(deltaX,deltaY,0f);
        CollisionFlags collisions = _controller.Move(deltaPosition);
        if((collisions&CollisionFlags.CollidedAbove) != 0)
        {
            _velocity.y = -1f;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.up,out hit, 2f))
            {
                if (hit.collider.gameObject.CompareTag("brick"))
                {
                    Destroy(hit.collider.gameObject);
                    level.gainScore(100);
                }else if (hit.collider.gameObject.CompareTag("gold_brick"))
                {
                    level.gainCoin();
                }
            }
        }
        if((collisions&CollisionFlags.CollidedSides) != 0)
        {
            _velocity.x = 0f;
            RaycastHit hit;
            if(Physics.Raycast(transform.position, Vector3.right,out hit, 2f))
            {
                if (hit.collider.gameObject.CompareTag("goal"))
                {
                    level.loadNextLevel();
                }
            }
            
            
        }
        _animator.SetBool("Grounded", _controller.isGrounded);
        if (_controller.isGrounded)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, -Vector3.up,out hit, 2f))
            {
                if (hit.collider.gameObject.CompareTag("water"))
                {
                    level.OnWaterHit();
                }
            }
            
        }
        _animator.SetFloat("speed",Mathf.Abs(_velocity.x));
    }
}
