using UnityEngine;

public class Container : MonoBehaviour,Interactable
{
    bool empty = false;
    public Item itemContained;
    Sprite openContainer;

    public void Interact(PlayerMovement p)
    {
        if (empty== false)
        {
            foreach (Item item in p.playerInventory.inventory)
            {
                if (item==null)
                {
                    EmptyContainer(item);
                    p.playerInventory.UpdateInventoryUI();
                    return;
                }
            }
            SwapItem(p.playerInventory.inventory[p.playerInventory.currentItem]);
        }
        
    }

   void EmptyContainer(Item slot) 
    {
        slot = itemContained;
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = openContainer;
        empty = true;
    }

    void SwapItem(Item item) 
    { 
    Item t = itemContained;
        itemContained = item;
        item =t;
    
    }
}
