using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.CompareTag("Player"))
       {
            AudioManager.instance.PlayDoorSound();
            Invoke("LoadNextScene", 1f);
       }
   }

   void LoadNextScene()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
