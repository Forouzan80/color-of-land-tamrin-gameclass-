using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform pointA;
    public Transform pointB;

    private Transform target;

    void Start()
    {
        target = pointB;
    }

    void Update()
    {
        // حرکت بین نقطه A و B
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerPower playerPower = collision.collider.GetComponent<PlayerPower>();

            if (playerPower != null && playerPower.hasGreenPower)
            {
                // بازیکن عنصر سبز داره → آسیبی نمی‌بینه
                Debug.Log("بازیکن از دشمن عبور کرد (قدرت سبز فعال)");
                return;
            }

            // بازیکن عنصر نداره → بمیره
            playermovelevel2 player = collision.collider.GetComponent<playermovelevel2>();

            if (player != null)
            {
                player.Die();
            }
        }
    }
}
