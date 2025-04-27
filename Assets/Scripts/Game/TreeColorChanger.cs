using UnityEngine;

public class TreeColorChanger : MonoBehaviour
{
    public Sprite greenSprite; // تصویر درخت سبز

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void TurnGreen()
    {
        if (greenSprite != null)
        {
            sr.sprite = greenSprite;
        }
    }
}
