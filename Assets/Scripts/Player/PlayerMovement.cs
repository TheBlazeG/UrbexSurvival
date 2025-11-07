using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Player inputActions;
    public PlayerInventory playerInventory {  get; private set; }
    Rigidbody2D rb;
    [SerializeField] float speed;
    Interactable objectToInteract;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInventory = GetComponent<PlayerInventory>();
        inputActions = new Player();

    }
    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.MouseAndKeyboard.Interact.performed += interactWithObject;

    }
    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.MouseAndKeyboard.Interact.performed -= interactWithObject;

    }

    private void Update()
    {
        rb.linearVelocity =inputActions.MouseAndKeyboard.Move.ReadValue<Vector2>().normalized*speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entered");
        if (other.TryGetComponent<Interactable>(out Interactable interactable))
        {
            objectToInteract = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Interactable>(out Interactable interactable) && interactable==objectToInteract)
        {
            objectToInteract = null;
        }
    }

    private void interactWithObject(InputAction.CallbackContext ctx) 
    {
        if (objectToInteract!=null)
        {
            
        objectToInteract.Interact(this);
        }
    }
}
