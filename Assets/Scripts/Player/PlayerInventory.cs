using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    Player inputActions;
    public int currentItem {get; private set;}
    public Sprite emptySprite;
    public Image[] inventoryUI;
    public Image[] inventoryUIBG;
    public List<Item> inventory = new List<Item>(3);


    private void Awake()
    {
        inputActions = new Player();
        currentItem= 0;
        inventoryUIBG[currentItem].enabled = true;

    }
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
        for (int i = 0; i < inventoryUI.Length; i++)
        {
            if (inventory[i]!=null)
            {
                inventoryUI[i].sprite = inventory[i].itemSprite;
            }
            else
            {
                inventoryUI[i].sprite = emptySprite;
            }
        }
    }

    void setInventorySlot1(InputAction.CallbackContext context)
    {
        currentItem = 0;
        for (int i = 0; i < inventoryUIBG.Length; i++)
        {
            if (i== currentItem)
            {
                
                inventoryUIBG[i].enabled = true;
            }
            else
            {
                inventoryUIBG[i].enabled = false;
            }
        }
    }
    void setInventorySlot2(InputAction.CallbackContext context)
    {
        currentItem = 1;
        for (int i = 0; i < inventoryUIBG.Length; i++)
        {
            if (i == currentItem)
            {

                inventoryUIBG[i].enabled = true;
            }
            else
            {
                inventoryUIBG[i].enabled = false;
            }
        }
    }
    void setInventorySlot3(InputAction.CallbackContext context)
    {
        currentItem = 2;
        for (int i = 0; i < inventoryUIBG.Length; i++)
        {
            if (i == currentItem)
            {

                inventoryUIBG[i].enabled = true;
            }
            else
            {
                inventoryUIBG[i].enabled = false;
            }
        }
    }
}
