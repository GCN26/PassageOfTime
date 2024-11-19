using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public bool died = false;
    public float deathTimer = 1;
    public bool victory = false;

    public bool deathSound = false;

    public float stuckTimer = 0;

    public string room;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //or if player has skipped time
        if (Time.timeScale != 0 && setFlash != true && died != true)
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
                    TrackJumps.timeJumps += 1;
                    setFlash = true;
                    aSource.PlayOneShot(timeJump);
                    GameObject flash = Instantiate(flashPrefab);
                    flash.transform.position = new Vector3(fcamera.transform.position.x, fcamera.transform.position.y, -1.1f);
                }
            }
            if (InSwapZone())
            {
                Debug.Log("Player should be stuck");
                stuckTimer += Time.deltaTime;
                if(stuckTimer > 2) MurderDeathKill();
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
        if (died)
        {
            manager.GetComponent<ManagerScript>().playerDead = true;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            deathTimer -= Time.deltaTime;
            if(deathSound == false)
            {
                deathSound = true;
                aSource.PlayOneShot(die);
            }
            Color tmp = this.GetComponent<SpriteRenderer>().color;
            tmp.a = deathTimer;
            this.GetComponent<SpriteRenderer>().color = tmp;
            if(deathTimer <= .45f && setFlash == false)
            {
                setFlash = true;
                aSource.PlayOneShot(timeJump);
                GameObject flash = Instantiate(flashPrefab);
                flash.transform.position = new Vector3(fcamera.transform.position.x, fcamera.transform.position.y, -1.1f);
            }
            if (deathTimer <= -.10f)
            {
                SceneManager.LoadScene(room);
            }
        }
        if (victory)
        {
            manager.GetComponent<ManagerScript>().playerDead = true;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            deathTimer -= Time.deltaTime*.75f;
            Color tmp = this.GetComponent<SpriteRenderer>().color;
            tmp.a = deathTimer;
            this.GetComponent<SpriteRenderer>().color = tmp;
            if (deathTimer <= .45f && setFlash == false)
            {
                setFlash = true;
                aSource.PlayOneShot(timeJump);
                GameObject flash = Instantiate(flashPrefab);
                flash.transform.position = new Vector3(fcamera.transform.position.x, fcamera.transform.position.y, -1.1f);
                flash.GetComponent<FlashScript>().polOff = true;
            }
            if (deathTimer <= -.1f)
            {
                TrackJumps.lastRoom = room;
                SceneManager.LoadScene("VictoryScreen");
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
    public void MurderDeathKill()
    {
        if (died != true)
        {
            TrackJumps.deathSlashReset += 1;
            died = true;
        }
    }
}
