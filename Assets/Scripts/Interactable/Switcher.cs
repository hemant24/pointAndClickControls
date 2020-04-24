using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : Interactable {

    public delegate void OnStateChange();

    public event OnStateChange Change;

    public bool state;

	public override void Interact()
	{
        state = !state;
        if(Change != null){
            Change();            
        }
        /*
        StateReactor reactor = GetComponent<StateReactor>();
        if(reactor != null){
            reactor.React();
        }
        */
	}
}
