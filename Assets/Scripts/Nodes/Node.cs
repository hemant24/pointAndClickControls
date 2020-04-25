using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node : MonoBehaviour {

    public Transform cameraPosition;
    public Location loc;

    public List<Node> reachableNodes = new List<Node>();

    [HideInInspector]
    public Collider coll;


	private void Awake()
	{
        coll = GetComponent<Collider>();
        if(coll != null){
            coll.enabled = false;
        }
       

	}

    public virtual void OnLeave()
    {
        SetReachableNodesCollider(false);

    }

    public virtual void OnArrival()
    {
        //Debug.Log("Yes mouse down");
        //Camera.main.transform.position = cameraPosition.position;
        //Camera.main.transform.rotation = cameraPosition.rotation;
        if (coll != null)
        {
            this.coll.enabled = false;
        }

        SetReachableNodesCollider(true);
        GameManager.instance.alignTo(cameraPosition);
    }

    public void SetReachableNodesCollider(bool set){
        foreach (Node n in reachableNodes)
        {
            if(n.GetComponent<Prerequisite>() != null && 
               !n.GetComponent<Prerequisite>().IsCompleted() &&
               !n.GetComponent<Prerequisite>().nodeAccess ){
                return;
            }
                
            if (n.coll != null)
            {
                n.coll.enabled = set;
            }
        }

    }



}
