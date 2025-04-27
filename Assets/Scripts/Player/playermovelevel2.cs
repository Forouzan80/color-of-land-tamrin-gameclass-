using UnityEngine;

public class playermovelevel2  : MonoBehaviour
{
    public float speed;
    private float Move;

    private Rigidbody2D rb;

    public float jump;
    private bool hasGreenPower = false;

    public GameObject greenAuraPrefab;
    private GameObject currentAura;
    public Transform startPoint; // نقطه شروع


    public bool isJumping;
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
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            Debug.Log("Grounded");
        }

         if (other.gameObject.CompareTag("enemy") && !hasGreenPower)
        {
            Die();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            Debug.Log("on the fly");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GreenElement"))
        {
            hasGreenPower = true;

            // هاله سبز رو اضافه کن به کاراکتر
            if (greenAuraPrefab != null && currentAura == null)
            {
                currentAura = Instantiate(greenAuraPrefab, transform);
                currentAura.transform.localPosition = Vector3.zero;
            }

            // می‌تونی اینجا درخت‌ها رو هم سبز کنی (مثلاً با GreenPowerManager)

            Destroy(other.gameObject);
            Debug.Log("قدرت سبز گرفته شد!");
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
        isJumping = false;
        hasGreenPower = false;

        // حذف هاله در صورت ریست شدن
        if (currentAura != null)
        {
            Destroy(currentAura);
        }
    }
}
