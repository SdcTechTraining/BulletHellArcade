using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class PlayerEntersTriggerEvent : EventBehavior
{
    public string RequiredItem = "";
    public bool DestroyRequiredItem = false;

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player.Current.gameObject)
        {
            // if the player requires an item but does not have it, exit.  
            if (RequiredItem.Length > 0)
            {
                if (!Player.Current.Items.Contains(RequiredItem))
                {
                    return;
                }

                if (DestroyRequiredItem)
                {
                    Player.Current.Items.Remove(RequiredItem);
                }
            }

            TriggerEvent();
        }
    }
}
