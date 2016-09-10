using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class PlayerEntersTriggerEvent : EventBehavior
{
	void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object at front door.");
        if(other.gameObject == Player.Current.gameObject)
        {
            Debug.Log("player at front door.");
            TriggerEvent();
        }
    }
}
