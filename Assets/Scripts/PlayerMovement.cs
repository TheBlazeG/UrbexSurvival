using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Player inputActions;
    Rigidbody2D rb;
    [SerializeField] float speed;
    Interactable objectToInteract;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new Player();

    }
    private void OnEnable()
    {
        inputActions.Enable();

    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        rb.linearVelocity =inputActions.MouseAndKeyboard.Move.ReadValue<Vector2>().normalized*speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Interactable>(out Interactable interactable))
        {
            objectToInteract = interactable;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Interactable>(out Interactable interactable) && interactable==objectToInteract)
        {
            objectToInteract = null;
        }
    }
}
