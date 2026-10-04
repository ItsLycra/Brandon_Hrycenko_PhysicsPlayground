using System.Collections;
using UnityEngine;


public class DeathZone : MonoBehaviour
{
  [SerializeField] Transform respawnPoint;
  [SerializeField] float respawnDelay = 1f;

  private void OnTriggerEnter2D(Collider2D other )
    {
        if (other.CompareTag("Ball"))
        {
            StartCoroutine(RespawnBall(other.gameObject));
        }
    }
   private IEnumerator RespawnBall(GameObject ball)
    {
        ball.SetActive(false);

        yield return new WaitForSeconds(respawnDelay);

        ball.transform.position = respawnPoint.position;

        ball.SetActive(true);

        UnityEngine.Rigidbody2D rb = ball.GetComponent<UnityEngine.Rigidbody2D>();

        rb.linearVelocity = new UnityEngine.Vector2(0f,0f);

        BallLauncher launcher = FindAnyObjectByType<BallLauncher>();

        if (launcher !=null)
        {
            launcher.ResetLauncher();
        }
    } 
    
}
