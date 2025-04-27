using UnityEngine;
// اگر PlayerController در فضای نام خاصی قرار دارد
// using YourNamespace;

public class WaterHazard : MonoBehaviour
{
    public bool isWaterSafe = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isWaterSafe)
        {
            // اگر هنوز عنصر نگرفته باشه، بمیره
            other.GetComponent<PlayerController>().ResetToStart();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isWaterSafe)
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0.1f;
            rb.velocity = new Vector2(rb.velocity.x, 0); // شناوری
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1f;
        }
    }
}
