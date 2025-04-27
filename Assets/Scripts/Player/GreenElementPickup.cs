using UnityEngine;

public class GreenElementPickup : MonoBehaviour
{
    public GameObject greenAuraPrefab;
    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collected) return;

        if (collision.CompareTag("Player"))
        {
            collected = true;

            // فعال‌سازی قدرت سبز
            PlayerPower power = collision.GetComponent<PlayerPower>();
            if (power != null)
            {
                power.hasGreenPower = true;
            }

            // سبز کردن درخت‌ها
            GreenPowerManager.Instance.ActivateGreenTrees();

            // اضافه کردن هاله به بازیکن
            if (greenAuraPrefab != null)
            {
                GameObject aura = Instantiate(greenAuraPrefab, collision.transform);
                aura.transform.localPosition = Vector3.zero;
            }

            // حذف آیتم سبز
            Destroy(gameObject);
        }
    }
}
