using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public GameObject LeftDoor;
    public GameObject RightDoor;
    public EventBehavior DoorOpensEvent;
    public AnimationClip DoorOpenAnimationClip;
    public AnimationClip DoorCloseAnimationClip;
    public Animator DoorAnimation;
    private bool isOpen = false;
    
    void Start()
    {
        DoorAnimation.Play(DoorCloseAnimationClip.name);
        DoorOpensEvent.EventHandlers.Add(OpenDoor);
        Debug.Log("Started/Closed Door");
    }

    void OpenDoor(string triggerName)
    {
        if (isOpen)
        {
            return;
        }
        Debug.Log("opening door");
        isOpen = true;
        DoorAnimation.Play(DoorOpenAnimationClip.name);
    }

	// Update is called once per frame
	void Update () {
	    
	}
}
