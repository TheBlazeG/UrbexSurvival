using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    Player inputActions;
    public int currentItem{get; private set;}
    public Image[] inventoryUI;
    public List<Item> inventory = new List<Item>(3);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.MouseAndKeyboard.InventorySlot1.performed += setInventorySlot1;
        inputActions.MouseAndKeyboard.InventorySlot2.performed += setInventorySlot2;
        inputActions.MouseAndKeyboard.InventorySlot3.performed += setInventorySlot3;

    }
    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.MouseAndKeyboard.InventorySlot1.performed -= setInventorySlot1;
        inputActions.MouseAndKeyboard.InventorySlot2.performed -= setInventorySlot2;
        inputActions.MouseAndKeyboard.InventorySlot3.performed -= setInventorySlot3;

    }

    public void UpdateInventoryUI() 
    {
    
    }

    void setInventorySlot1(InputAction.CallbackContext context)
    {
        
    }
    void setInventorySlot2(InputAction.CallbackContext context)
    {
        
    }
    void setInventorySlot3(InputAction.CallbackContext context)
    {
        
    }
}
