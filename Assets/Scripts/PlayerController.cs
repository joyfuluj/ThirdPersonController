using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    private Rigidbody rb;
    public float playerSpeed = 2f;
    public float rotationSpeed = 20f;
    public float jumpHeight = 4f;
    public bool onGround = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        inputManager.OnMove.AddListener(MovePlayer);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, mouseX);

    }

    public void MovePlayer(Vector3 input)
    {
        Vector3 inputDirection = transform.forward * input.z + transform.right * input.x;
        rb.AddForce(inputDirection * playerSpeed,  ForceMode.Acceleration);

        // if (input.y > 0 && onGround)
        // {
        //     rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        // }
    }
}
