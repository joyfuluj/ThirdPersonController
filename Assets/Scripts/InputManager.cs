using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();
    public UnityEvent OnJump = new UnityEvent();
    public UnityEvent OnDash = new UnityEvent();

    void Update()
    {
        Vector3 inputVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            inputVector += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            OnDash?.Invoke();
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector += Vector3.back;
        }

        OnMove?.Invoke(inputVector);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
        }
    }
}
