using System.Collections;
using UnityEngine;

public class FreezeField : MonoBehaviour
{
    [SerializeField] private float freezeDuration = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            UnityEngine.Rigidbody2D rb = other.GetComponent<UnityEngine.Rigidbody2D>();

            StartCoroutine(FreezeBall(other));
        }
    }

    private IEnumerator FreezeBall(Collider2D ballCollider)
    {
        UnityEngine.Rigidbody2D rb = ballCollider.GetComponent<UnityEngine.Rigidbody2D>();

        rb.linearVelocity = new UnityEngine.Vector2 (0f,0f);

        rb.gravityScale = 0f;

        yield return new WaitForSeconds(freezeDuration);

        rb.gravityScale = 1f;

        
    }


}
