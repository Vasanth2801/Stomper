using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 3f;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        speed = -speed;
        FlipEnemy();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            UIManager.instance.GameOver();
        }
    }

    void FlipEnemy()
    {
        transform.localScale = new Vector2(-Mathf.Sign(rb.linearVelocity.x), 1f);
    }
}