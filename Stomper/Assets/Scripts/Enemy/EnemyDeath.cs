using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [Header("Death References")]
    [SerializeField] private Animator animator;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 0.5f);
    }
}