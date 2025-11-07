using UnityEngine;

public class ItemUsable : MonoBehaviour, Interactable
{
    public string interactTip= "it looks like you could use x here";
    public string solvedTip= "the x seems x now";
    public string correctItemText = "it worked, you x the x";
    public Item neededItem;
    bool solved = false;
    public void Interact(PlayerMovement player)
    {
        if (solved==false)
        {
        player.uiText = interactTip;
       StartCoroutine( player.SetUIText());
        }
        else
        {
            player.uiText = solvedTip;
           StartCoroutine( player.SetUIText());
        }
    }
    public UseResponses UseItem(PlayerMovement player,Item itemToUse) 
    {
        if (itemToUse.itemName==neededItem.itemName)
        {
            player.uiText = correctItemText;
           StartCoroutine( player.SetUIText());
            return UseResponses.correct;
        }
        else
        { 
        return UseResponses.incorrect;
        }
    }
}
