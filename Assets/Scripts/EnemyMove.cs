using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool faceRight = true;
    public float horizontal = -2f;

    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (HitsWall())
        {
            flip();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
    }
    private bool HitsWall()
    {
        bool boool;
        if (Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer))
        {
            boool = true;
        }
        else boool = false;
        return boool;
    }
    private void flip()
    {
        if (faceRight && horizontal < 0f || !faceRight && horizontal > 0f)
        {
            faceRight = !faceRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            horizontal = horizontal * -1;
        }
    }
}
