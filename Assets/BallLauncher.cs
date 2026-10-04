using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ball;
    [SerializeField] private float launchSpeed = 15f;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private bool launched = false;
    private void Update()
    {
        if (!launched && UnityEngine.InputSystem.Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            LaunchBall();
        }
    }
    private void LaunchBall()
    {
        launched = true;
        ball.transform.position = transform.position;
        ball.linearVelocity = new UnityEngine.Vector2(0f,1f);
        ball.linearVelocity = new UnityEngine.Vector2(0f,1f) * launchSpeed;
        spriteRenderer.color = Color.red;
    } 

    public void ResetLauncher()
    {
        launched = false;

        spriteRenderer.color = Color.green;
    }
}
