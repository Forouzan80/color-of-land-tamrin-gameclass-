using UnityEngine;

public class LightChanger : MonoBehaviour
{
    public Sprite yellowSprite; 

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void TurnOn()
    {
        if (yellowSprite != null)
        {
            sr.sprite = yellowSprite;
        }
    }
}
