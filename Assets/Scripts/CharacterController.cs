using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public GameObject playerCharacter;
    private float horizontal;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpForce = 1.5f;
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private AudioSource slimeJump;
    //[SerializeField] private AudioClip slimeJump;


    // Start is called before the first frame update
    void Start()
    {
        rb = playerCharacter.GetComponent<Rigidbody2D>();
        animator = playerCharacter.GetComponent<Animator>();
        slimeJump = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0) animator.SetBool("slimeMoving", true);
        else animator.SetBool("slimeMoving", false);

        if(horizontal > 0f)
        {
            playerCharacter.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (horizontal < 0f)
        {
            playerCharacter.GetComponent<SpriteRenderer>().flipX = true;
        }

        //implement game pad directions
        if (Input.GetButtonDown("Jump") && OnGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            slimeJump.Play();
        }
        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            //slimeJump.Play();

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level0");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public bool OnGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
