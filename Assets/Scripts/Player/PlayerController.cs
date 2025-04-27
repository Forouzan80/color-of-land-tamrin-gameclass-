using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private float Move;
    private Rigidbody2D rb;
    public float jump = 10f;
    public bool isJumping;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isSwimming = false;
    public float floatHeight = 0.5f; // ارتفاع شناور ماندن
    public float floatStrength = 5f; // قدرت برگشت به سطح
    private float waterSurfaceY;
    public Transform startPoint; // نقطه شروع

    private bool hasWaterPower = false; // آیا آرو شعله آبی را گرفته است؟

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce (new Vector2(rb.velocity.x, jump));
            Debug.Log("salam");
        }

        if (isSwimming)
        {
            // شناور بودن روی آب
            float targetY = waterSurfaceY + floatHeight;
            float newY = Mathf.Lerp(rb.position.y, targetY, Time.fixedDeltaTime * floatStrength);
            rb.position = new Vector2(rb.position.x, newY);
            rb.velocity = new Vector2(rb.velocity.x, 0f); // حذف سرعت عمودی
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    { 
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            Debug.Log("Grounded");
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            // برخورد با دشمن
            Die();
        }

       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("water"))
        {
            // اگر شعله آبی گرفته نشده باشد، آرو می‌میرد
            if (!hasWaterPower)
            {
                Die();
                return; // آرو در این حالت دیگر به سطح آب نمی‌رسد
            }

            isSwimming = true;
            waterSurfaceY = other.bounds.max.y; // بالای سطح آب
            rb.gravityScale = 0f; // حذف جاذبه برای شنا
        }

        if (other.CompareTag("WaterElement"))
        {
            // آرو شعله آبی را گرفت
            hasWaterPower = true;
            Destroy(other.gameObject); // حذف شعله آبی
            Debug.Log("Sholhe abi gireft!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("water"))
        {
            isSwimming = false;
            rb.gravityScale = 1f; // بازگرداندن جاذبه
        }
    }

    public void Die()
    {
        Debug.Log("آرو مُرد!");
        ResetToStart();
    }

    public void ResetToStart()
    {
         transform.position = startPoint.position;
        rb.velocity = Vector2.zero;
        isSwimming = false;
        rb.gravityScale = 1f;
        hasWaterPower = false; // ریست کردن وضعیت شعله آبی
    }
}
