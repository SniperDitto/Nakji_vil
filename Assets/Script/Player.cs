using UnityEngine;
using UnityEngine.InputSystem; // Input System 사용

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        // InputActions 생성 및 이벤트 연결
        if (playerInput == null)
        {
            playerInput = new PlayerInputActions();
            playerInput.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
            playerInput.Player.Move.canceled += ctx => moveInput = Vector2.zero;
        }
        playerInput.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    // Input System용 변수
    private PlayerInputActions playerInput;
}
