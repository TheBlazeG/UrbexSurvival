using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Player inputActions;
    public string uiText;
    public PlayerInventory playerInventory {  get; private set; }
    public TextMeshProUGUI uiTextDisplay;
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
        inputActions.MouseAndKeyboard.UseItem.performed += useItem;

    }
    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.MouseAndKeyboard.Interact.performed -= interactWithObject;
        inputActions.MouseAndKeyboard.UseItem.performed -= useItem;

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
            StopCoroutine(SetUIText());
        objectToInteract.Interact(this);
        }
    }

    private void useItem(InputAction.CallbackContext ctx)
    {
        if (objectToInteract != null && playerInventory.inventory[playerInventory.currentItem]!=null) 
        {
            StopCoroutine(SetUIText());
            UseResponses response = objectToInteract.UseItem(this,playerInventory.inventory[playerInventory.currentItem]);
            if (response == UseResponses.incorrect)
            {
                uiText = "That didnt seem to work";
                StartCoroutine(SetUIText());
            }
            else if (response == UseResponses.correct)
            {
                playerInventory.inventory[playerInventory.currentItem] = null;
                playerInventory.UpdateInventoryUI();
            }
            else if (response==UseResponses.nonUsable)
            {
                uiText = "You can't use an item here";
                StartCoroutine(SetUIText());
            }

        }
        else if(objectToInteract== null)
        {
            StopCoroutine(SetUIText());
            uiText = "no place to use this";
            StartCoroutine(SetUIText());
        }
        else
        {
            StopCoroutine(SetUIText());
            uiText = "no item to use";
            StartCoroutine(SetUIText());
        }
    }
    public IEnumerator SetUIText()
    {
        Color fade = Color.white;
        uiTextDisplay.text = uiText;
        while(fade.a>0)
        {
                fade.a -=.166f * Time.deltaTime;
            uiTextDisplay.color = fade;
            yield return null;
        }

    }
}
