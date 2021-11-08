using UnityEngine;

public class PlayerKontrol : MonoBehaviour

{
    Rigidbody2D playerRB;
    public float moveSpeed = 1f;
    public float JumpSpeed = 1f, JumpFrequency = 1f, nextJumptime;
    public float hInput = 0;
    Animator playerAnimator;

    bool facingRight = true;
    public bool isGrounded = false;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    bool canjump;
    public static PlayerKontrol Instance;
    Transform Groundcheck;


    // Start is called before the first frame update
    void Start()
    {
        canjump = true;
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        Instance = this;
        Groundcheck = GameObject.Find(this.name+"/GroundCheck").transform;


    }

    // Update is called once per frame
    void Update()
    {
        isGrounded=Physics2D.Linecast(this.transform.position, Groundcheck.position, groundCheckLayer);
        Move(hInput);
        OnGroundCheck();
        //HorizontalMove();
       // Jumper();          //PC Kontrol SpeedJump=365 yap
        Leftway();
        Rightway();


    }
    

    public void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 templocalScale = transform.localScale;
        templocalScale.x *= -1;
        transform.localScale = templocalScale;
    }


    void OnGroundCheck()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("PlatformSmallHareket"))
        {
            this.transform.parent = collision.transform;
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            canjump = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("PlatformSmallHareket"))
        {
            this.transform.parent = null;


        }
        
    }
    //PC KONTROL
    void HorizontalMove()   

    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);

        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }

    public void Jumper()
    {
        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumptime < Time.timeSinceLevelLoad))
        {
            nextJumptime = Time.timeSinceLevelLoad + JumpFrequency;
            Jump();
        }
    }
    public void Jump()
    {
        if (canjump)
        {
            canjump = false;
            playerRB.AddForce(new Vector2(0f, JumpSpeed));
        }

    }

    public void Leftway()
    {
        if (playerRB.velocity.x < 0 && facingRight)

        {
            FlipFace();
        }
    }

    public void Rightway()
    {
        if (playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }
    }
    //Mobil KONTROL
    private void Move(float Horizontal)
    {
        Vector2 vel = playerRB.velocity;
        vel.x = Horizontal * moveSpeed;
        playerRB.velocity = vel;
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }
    public void MobileMove(float input)
    {
        hInput = input;
    }
    public void JumpMobil()
    {
        if (isGrounded)
        {
            playerRB.velocity += Vector2.up * JumpSpeed;
        }
    }

















}