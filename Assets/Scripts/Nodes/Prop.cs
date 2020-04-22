using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : Node
{

    Interactable interactable;

	private void Start()
	{
        interactable = GetComponent<Interactable>();
	}

    void OnMouseUp()
    {
        if (interactable != null && interactable.enabled)
        {
            interactable.Interact();
        }

    }

	public override void OnArrival()
	{
		base.OnArrival();
        if(interactable != null){
            coll.enabled = true;
            interactable.enabled = true;
        }

	}

	public override void OnLeave()
	{
        Debug.Log("on leaving");
        base.OnLeave();
        if (interactable != null)
        {
            Debug.Log("disabling the interactable");
            interactable.enabled = false;
        }

	}


}
