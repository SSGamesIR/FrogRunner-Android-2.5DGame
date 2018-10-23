using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed = 5f;
    public float jumpPower = 10f;
    public float secondJumpPower = 10f;
    public Transform groundCheckPosition;
    public float radius = 0.3f;
    public LayerMask layerGround;


    private Rigidbody myBody;
    private bool isGrounded;
    private bool playerJumped;
    private bool canDoubleJump;

    private PlayerAnimation playerAnim;

    public GameObject smokePosition;
     
    private bool gameStarted;

    private BGScroller bgScroller;

    private PlayerHealthDamageShoot playerShoot;

    private Button jumpBtn;


	void Awake () {
        myBody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<PlayerAnimation>();
        bgScroller = GameObject.Find(Tags.BACKGROUND_GAME_OBJ).GetComponent<BGScroller>();
        playerShoot = GetComponent<PlayerHealthDamageShoot>();

        jumpBtn = GameObject.Find(Tags.JUMP_BUTTON_OBJ).GetComponent<Button>();
        jumpBtn.onClick.AddListener(() => Jump());

    }

    void Start()
    {
        StartCoroutine(StartGame());   
    }

    void FixedUpdate () {
        if (gameStarted)
        {
            PlayerMove();
            PlayerGrounded();
            PlayerJump();
        }
	}

    void PlayerMove()
    {
        myBody.velocity = new Vector3(movementSpeed,myBody.velocity.y,0f);

    }

    void PlayerGrounded()
    {
        isGrounded = Physics.OverlapSphere(groundCheckPosition.position, radius, layerGround).Length > 0;
        //Debug.Log("is grounded" + isGrounded);
        
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded & canDoubleJump)
        {
            canDoubleJump = false;
            myBody.AddForce(new Vector3(0, secondJumpPower, 0));
            //Debug.Log("jump twice");

        }
        else if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            playerAnim.DidJump();
            myBody.AddForce(new Vector3(0, jumpPower, 0));
            playerJumped = true;
            canDoubleJump = true;
            //Debug.Log("jump once");
        }

        
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerAnim.DidJump();
            myBody.AddForce(new Vector3(0, jumpPower, 0));
            playerJumped = true;
            canDoubleJump = true;
            //Debug.Log("jump once");
        }

        if (!isGrounded & canDoubleJump)
        {
            canDoubleJump = false;
            myBody.AddForce(new Vector3(0, secondJumpPower, 0));
            //Debug.Log("jump twice");

        }
        
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2f);
        gameStarted = true;
        bgScroller.canScroll = true;
        playerShoot.canShoot = true;
        GameplayController.instance.canCountScore = true;
        smokePosition.SetActive(true);
        playerAnim.PlayerRun();
    }

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == Tags.PLATFORM_TAG)
        {
            if (playerJumped)
            {
                playerJumped = false;
                playerAnim.DidLand();
            }
        }
    }

}// class


















