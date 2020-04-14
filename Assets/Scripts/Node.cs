using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node : MonoBehaviour {

    public Transform cameraPosition;
    public Location loc;

    public List<Node> reachableNodes = new List<Node>();

    [HideInInspector]
    public Collider coll;


	private void Start()
	{
        coll = GetComponent<Collider>();
	}

    public void OnLeave()
    {

        foreach (Node n in reachableNodes)
        {
            if (n.coll != null)
            {
                n.coll.enabled = false;
            }
        }

    }

	public void OnArrival()
	{
        //Debug.Log("Yes mouse down");
        //Camera.main.transform.position = cameraPosition.position;
        //Camera.main.transform.rotation = cameraPosition.rotation;
        if(coll != null )
        {
          this.coll.enabled = false;
        }
       

        foreach(Node n in reachableNodes)
        {
            if(n.coll != null)
            {
                n.coll.enabled = true;
            }
        }
        GameManager.instance.alignTo(cameraPosition);
	}



}
