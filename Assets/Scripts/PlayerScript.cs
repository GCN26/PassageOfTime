using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private Transform swapCheck;
    [SerializeField] private LayerMask swapLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            horizontal = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
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
                    manager.GetComponent<ManagerScript>().currentEra += 1;
                    manager.GetComponent<ManagerScript>().eraChange = true;
                }
            }
            if (InSwapZone())
            {
                Debug.Log("Player should be stuck");
                //use this to kill player
                Time.timeScale = 0;
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
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }
    private bool InSwapZone()
    {
        return Physics2D.OverlapCircle(swapCheck.position, .45f, groundLayer);
    }
}
