using UnityEngine;

public class YellowElement : MonoBehaviour
{

    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collected) return;

        if (collision.CompareTag("Player"))
        {
            collected = true;
            YellowPowerManager.Instance.ActivateYellowLights();
            Destroy(gameObject);
        }
    }
}
