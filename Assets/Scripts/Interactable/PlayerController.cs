using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour {

    #region Data
    [Space, Header("Data")]
    [SerializeField] private PlayerInputData playerInputData = null;
    [SerializeField] private PlayerData playerData = null;
    #endregion

    public float MaxDubbleTapTime = 0.3f;

    private int touchCount = 0;
    private float NewTime;
    private Node selectedNode;
    private bool doubleClicked = false;

    private CameraController cameraController;


	private void Awake()
	{
        cameraController = GetComponentInChildren<CameraController>();
	}


	// Update is called once per frame
	void LateUpdate () {
        doubleClicked = false;
        CheckForPlayerInput();
        CheckForPlayerAction();
        //interactionInputData.ResetInput();
	}


    private void CheckForPlayerInput()
    {
        if (playerInputData.ClickReleased)
        {
            CheckForDoubleClickOnNode();
        }

    }

    private void CheckForDoubleClickOnNode()
    {
        Ray _ray = new Ray(playerInputData.ClickedPosition, playerInputData.ClickedDirection);
        Debug.DrawRay(playerInputData.ClickedPosition, playerInputData.ClickedDirection, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(_ray, out hit))
        {
            if (hit.transform.gameObject.GetComponent<Node>() != null)
            {
                touchCount++;
                if (touchCount == 1)
                {
                    NewTime = Time.time + MaxDubbleTapTime;
                    selectedNode = hit.transform.gameObject.GetComponent<Node>();
                }

                if (touchCount == 2)
                {
                    if (Time.time <= NewTime)
                    {
                        Node _secondTimeSelectedNode = hit.transform.gameObject.GetComponent<Node>();
                        if (_secondTimeSelectedNode == selectedNode)
                        {
                            playerData.SelectedNode = selectedNode;
                            doubleClicked = true;
                        }  
                    }

                    ResetDoubleClickNodeData();

                }
            }
        }

        if (Time.time > NewTime)
        {
            ResetDoubleClickNodeData();
        }
    }

    private void ResetDoubleClickNodeData()
    {
        touchCount = 0;
        selectedNode = null;
    }



    private void CheckForPlayerAction()
    {
        if(playerData.IsEmpty())
        {
            return;
        }

        if (doubleClicked)
        {
            Debug.Log("calling on arrival on selected Node");
            //move player to designated transform
            Transform playerTransform = playerData.SelectedNode.getOnArrivalTransform();

            Sequence seq = DOTween.Sequence();
            //Move player
            //seq.Append(Camera.main.transform.DOMove(cameraPosition.position, 0.75f));
            MovePlayer();
        } 
        else if(playerInputData.BackClicked)
        {
            Location locToBeCalled = playerData.SelectedNode.loc;
            playerData.SelectedNode.OnLeave();
            playerData.SelectedNode = locToBeCalled;
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        Transform playerTransform = playerData.SelectedNode.getOnArrivalTransform();

        Sequence seq = DOTween.Sequence();
        //Move player
        //seq.Append(Camera.main.transform.DOMove(cameraPosition.position, 0.75f));
        seq.Append(transform.DOMove(playerTransform.position, 0.75f));

        //Rotate Camera
        cameraController.alignTo(playerTransform, seq);
        //Let node know player has arrived
        playerData.SelectedNode.OnArrival();
    }
}
