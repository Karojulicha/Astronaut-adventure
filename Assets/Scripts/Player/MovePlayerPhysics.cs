using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [Header("Configuración")]
    float horizontal, vertical;
    public float moveSpeed = 8f;
    public float rotationSpeed = 10f;
    public float jumpForce = 7f;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private Animator playerAnimControl;
    private Vector3 moveDirection;
    public bool isGrounded;

    void Start()
    {   
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimControl = GetComponent<Animator>();
        
    }
    void Update()
    {
        HandleInput();

        if (moveDirection != Vector3.zero)
        {
            RotateTowardsMovement();
            playerAnimControl.SetBool("isWalking", true);

        }
        else if (!isGrounded && !playerAnimControl.GetBool("isJumping"))
        {
            playerAnimControl.SetBool("isJumping", true);
            playerAnimControl.SetBool("isWalking", false);
        }
        else
        {
            playerAnimControl.SetBool("isWalking", false);
            playerAnimControl.SetBool("isJumping", false);
        }


    }
    void FixedUpdate()
    {
        // FixedUpdate funciona para agregar movimientos colisiones etc, tiene valores fijos
        ApplyPhysicsMovement();
    }
    private void HandleInput()
    {
        // Entrada básica de movimiento
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Salto si oprimimos Boton Jump (input manager) y está tocando el suelo.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            ApplyJump();
        }
    }
    private void ApplyPhysicsMovement()
    {

        // Movimiento con fuerzas físicas por medio de método MovePosition
        playerRigidbody.MovePosition(transform.localPosition + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
    private void ApplyJump()
    {
        //Usamos método AddForce en Rigidbody para aplicar una fuerza vertical con modo de Impulso
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision other)
    {
        //Esto nos comunica cuando deja de colisionar con un objeto que tenga Tag "Floor"
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {

        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
    private void RotateTowardsMovement()
    {
        // Rotación suave hacia la dirección de movimiento
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }
}
