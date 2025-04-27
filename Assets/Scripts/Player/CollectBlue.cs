using UnityEngine;

public class CollectBlue : MonoBehaviour
{
    public GameObject water; // آب را از Inspector وارد کن

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collected Blue!");

            // تغییر رنگ آب از خاکستری به آبی
            MeshRenderer mr = water.GetComponent<MeshRenderer>();
            if (mr != null)
            {
                mr.material.color = new Color(0.4f, 0.7f, 0.9f);
            }

            // امن کردن آب
            water.GetComponent<WaterHazard>().isWaterSafe = true;

            Destroy(gameObject); // حذف عنصر آب
        }
    }
}
