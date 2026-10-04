using System.Collections;
using UnityEngine;

public class DropTarget : MonoBehaviour
{
    [SerializeField] private float resetDelay = 2f;

    [SerializeField] private float targetForce = 10f;
    
    private bool disabled = false;

    private void  OnCollisionEnter2D(Collision2D collision)
    {
        if (disabled)
        {
            return ;
        }

        if (collision.gameObject.CompareTag("Ball"))
        {
            UnityEngine.Rigidbody2D ball = collision.gameObject.GetComponent<UnityEngine.Rigidbody2D>();

            UnityEngine.Vector2 direction = (collision.transform.position - transform.position).normalized;

            ball.AddForce (direction * targetForce, ForceMode2D.Impulse);
            StartCoroutine(DisableTarget());
        }
    }

    private IEnumerator DisableTarget()
    {
        disabled = true;

        gameObject.SetActive(false);

        yield return new WaitForSeconds(resetDelay);

        gameObject.SetActive(true);

        disabled = false;
    }

 
}
