using UnityEngine;
using UnityEngine.SceneManagement;

public class Endinglevel : MonoBehaviour
{
   void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("LevelSelect");
            Debug.Log("You Win!");
        }
    }
}
