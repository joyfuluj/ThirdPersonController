using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    private Rigidbody rb;
    public float playerSpeed = 2f;
    public float jumpHeight = 4f;
    private int jumpCount = 0;
    private int maxJumps = 2; 
    private float dashMultiplier = 1.0005f;
    private float dashDuration = 0.5f;
    public Transform cameraTransform;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();

        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnJump.AddListener(Jump);
        inputManager.OnDash.AddListener(Dash);
    }

    void Dash()
    {
        StartCoroutine(DashCoroutine());
    }

    IEnumerator DashCoroutine()
    {
        float originalSpeed = playerSpeed;
        playerSpeed *= dashMultiplier;
        yield return new WaitForSeconds(dashDuration);
        playerSpeed = originalSpeed;
    }

    void Jump()
    {
        if (jumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box"))
        {
            jumpCount = 0;
        }
    }

    public void MovePlayer(Vector3 input)
    {
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;

        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0;

        Vector3 inputDirection = cameraForward * input.z + cameraRight * input.x;
        rb.AddForce(inputDirection.normalized * playerSpeed, ForceMode.Acceleration);
    }
}
