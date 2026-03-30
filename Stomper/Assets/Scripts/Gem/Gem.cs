using UnityEngine;

public class Gem : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GemCollector.instance.AddGem();
            Destroy(gameObject);
        }
    }
}