using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/**
 * 
 * Singletone implemetation got from : https://www.studica.com/blog/how-to-create-a-singleton-in-unity-3d
 */
public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public Character character = null;
    public Location startingLocation = null;

    [HideInInspector]
    public Node currentNode = null;

	private void Awake()
	{
        if(instance == null){
            instance = this;
        }else if (instance != this){
            Destroy(gameObject);// not sure what this will do 
        }
	}

	private void Start()
	{
        if(startingLocation != null){
            onObjectSelected(startingLocation.gameObject);
            //currentNode = startingLocation;
            //currentNode.OnArrival();
        }
	}


	public void onObjectSelected(GameObject obj){
        if (obj.GetComponent<Node>() != null){
            if(currentNode != null){
                currentNode.OnLeave();
            }
            currentNode = obj.GetComponent<Node>();
            currentNode.OnArrival();
        }
    }

    public void alignTo(Transform cameraPosition){
        character.alignTo(cameraPosition);
        /*
        Sequence seq = DOTween.Sequence();
        seq.Append(Camera.main.transform.DOMove(cameraPosition.position, 0.75f));
        seq.Join(Camera.main.transform.DORotate(cameraPosition.rotation.eulerAngles, 0.75f));
        //TODO: Improve on this, Not sure about it.
        Character mousePov = FindObjectOfType<Character>();
        mousePov.ResetCamera();
        */
    }

    //TODO: Move logic to somewhere else.
    public void onPinchOut(){
     
        if (currentNode != null && currentNode.GetComponent<Node>() != null)
        {
            Location locToBeCalled = currentNode.GetComponent<Node>().loc;
            currentNode.OnLeave();
            currentNode = currentNode.GetComponent<Node>().loc;
            locToBeCalled.OnArrival();
        }
        else
        {

            Debug.Log("Need to handle");
            /*
            Camera.main.transform.position = new Vector3(0f, 1f, -5f);
            Camera.main.transform.rotation = Quaternion.Euler(0f, -4.54f, 0f);
            */
        }
        
    }

}
