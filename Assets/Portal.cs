using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform exitPortal;

    [SerializeField] private float exitSpeed = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ball"))
        {
            return;
        }
    

        UnityEngine.Rigidbody2D rb = other.GetComponent<UnityEngine.Rigidbody2D>();

        UnityEngine.Vector2 currentVelocity = rb.linearVelocity;

        //UnityEngine.Vector2 exitDirection = new UnityEngine.Vector2(-Mathf.Sin(exitPortal.eulerAngles.z * Mathf.Deg2Rad),Mathf.Cos(exitPortal.eulerAngles.z * Mathf.Deg2Rad));

        other.transform.position = exitPortal.position;

        rb.linearVelocity = currentVelocity;

    }
}
