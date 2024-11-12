using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float speed = 8f;
    public Rigidbody2D rb;
    private float jumpSpeed = 16f;
    private bool faceRight = true;
    private float horizontal;

    public GameObject manager;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask groundLayer2;

    [SerializeField] private Transform swapCheck;
    [SerializeField] private LayerMask swapLayer;

    public float flashTimer;
    public bool setFlash;
    public bool spawnFlash;

    public GameObject fcamera;
    public GameObject flashPrefab;

    public AudioSource aSource;
    public AudioClip jump;
    public AudioClip timeJump;
    public AudioClip die;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //or if player has skipped time
        if (Time.timeScale != 0 && setFlash != true)
        {
            horizontal = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                aSource.PlayOneShot(jump);
            }
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
            }
            flip();
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (manager.GetComponent<ManagerScript>().currentEra < 3)
                {
                    setFlash = true;
                    aSource.PlayOneShot(timeJump);
                    GameObject flash = Instantiate(flashPrefab);
                    flash.transform.position = new Vector3(fcamera.transform.position.x, fcamera.transform.position.y, -1);
                }
            }
            if (InSwapZone())
            {
                Debug.Log("Player should be stuck");
                //use this to kill player
                Time.timeScale = 0;
            }
            
        }
        if (setFlash)
        {
            
            //freeze constraints, play animation here
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            flashTimer += Time.deltaTime;
            if (flashTimer > .55)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                changeTime();
                flashTimer = 0;
                setFlash = false;
            }
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void flip()
    {
        if (faceRight && horizontal < 0f || !faceRight && horizontal > 0f)
        {
            faceRight = !faceRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private bool IsGrounded()
    {
        bool boool;
        if (Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer) || Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer2)) boool = true;
        else boool = false;
        return boool;
    }
    private bool InSwapZone()
    {
        return Physics2D.OverlapCircle(swapCheck.position, .45f, groundLayer);
    }
    public void changeTime()
    {
        manager.GetComponent<ManagerScript>().currentEra += 1;
        manager.GetComponent<ManagerScript>().eraChange = true;
    }
}
