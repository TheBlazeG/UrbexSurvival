using UnityEngine;

public class Container : MonoBehaviour,Interactable
{
    bool empty = false;
    public Item itemContained;
    public Sprite openContainer;

    public void Interact(PlayerMovement p)
    {
        if (empty== false)
        {
            for (int i = 0; i < p.playerInventory.inventory.Count; i++)
            {

            
            
                if (p.playerInventory.inventory[i] ==null)
                {
                    p.playerInventory.inventory[i] = itemContained;
                    p.playerInventory.UpdateInventoryUI();
                    EmptyContainer();
                    p.uiText = "you got a" + itemContained.name;
                    StartCoroutine( p.SetUIText());
                    return;
                }
            }
            Item t = p.playerInventory.inventory[p.playerInventory.currentItem];
            p.uiText="you swapped"+t.name+" for " + itemContained.name;
           StartCoroutine( p.SetUIText());
            p.playerInventory.inventory[p.playerInventory.currentItem] = itemContained;
        itemContained = t;
        }
        
    }

   void EmptyContainer() 
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = openContainer;
        empty = true;
    }

    
     
    
    
}
