using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovelevel3 : MonoBehaviour
{
    public float speed;
    private float Move;

    private Rigidbody2D rb;
    private bool hasYellowPower = false;

    public float jump = 10f; // مقدار پرش اولیه
    private float defaultJump; // برای ریست کردن پرش
    public bool isJumping;

    private Vector3 startPos;
    public Transform startPoint; 

    // رفرنس به مدیریت چراغ
    private YellowElement yellowManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        defaultJump = jump;

        // پیدا کردن YellowElement داخل صحنه
        yellowManager = FindObjectOfType<YellowElement>();
    }

    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            Debug.Log("Jump!");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            Debug.Log("Grounded");
        }

          if (other.gameObject.CompareTag("enemy") && !hasYellowPower)
        {
            Die();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            Debug.Log("On the Fly");
        }
       
    }

    public void Die()
    {
        Debug.Log("آرو مُرد!");
        ResetToStart();
    }

    public void ResetToStart()
    {
        transform.position = startPos;
        rb.velocity = Vector2.zero;
        hasYellowPower = false;
        isJumping = false;
        jump = defaultJump; // ریست کردن قدرت پرش

    
    }
}
