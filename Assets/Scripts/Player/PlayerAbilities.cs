using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public bool hasGreenElement = false;
    public GameObject greenAuraPrefab;

    private GameObject currentAura;

    public void ActivateGreenPower()
    {
        hasGreenElement = true;

        if (greenAuraPrefab != null && currentAura == null)
        {
            currentAura = Instantiate(greenAuraPrefab, transform.position, Quaternion.identity, transform);
        }
    }

    public void DeactivateGreenPower()
    {
        hasGreenElement = false;

        if (currentAura != null)
        {
            Destroy(currentAura);
        }
    }
}
