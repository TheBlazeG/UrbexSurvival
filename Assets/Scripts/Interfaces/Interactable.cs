using UnityEngine;

public interface Interactable 
{

    void Interact(PlayerMovement player);

    UseResponses UseItem(PlayerMovement player,Item itemToUse)
    { 
        return UseResponses.nonUsable ;
    }

    
}
public enum UseResponses
    {
    correct,
    incorrect,
    nonUsable

    }