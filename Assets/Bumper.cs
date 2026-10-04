using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] private float bumperForce = 8f;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Ball"))
        {
            UnityEngine.Rigidbody2D ball = collision.gameObject.GetComponent<UnityEngine.Rigidbody2D>();

            UnityEngine.Vector2 direction = (collision.transform.position - transform.position).normalized;

            ball.AddForce( direction * bumperForce, ForceMode2D.Impulse);

        }
        spriteRenderer.color = Random.ColorHSV();
    }
  
}
