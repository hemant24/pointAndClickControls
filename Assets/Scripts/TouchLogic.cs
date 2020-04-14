using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLogic : MonoBehaviour {


    private float totalPercentageChange = 0;
    private bool backEventFired = false;

    private int touchCount = 0;
    public float MaxDubbleTapTime = 0.3f;
    float NewTime;

    GameObject currentObjectClicked = null;

    RaycastHit hit;

	
	// Update is called once per frame
	void Update () {

        if (Input.touches.Length == 1)
        {
            //Debug.Log("yes touching Single finger");
            ResetDoubleTouch();
            //HandleSingleTouch();
            HandleDoubleTap();
        }

        if (Input.touches.Length == 2)
        {
            //Debug.Log("yes touching two fingers");
            HandleDoubleTouch();

        }
	}

    /*
    private void HandleSingleTouch()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {

            OnSingleMoved();
        }
    }*/
    protected virtual void OnSingleMoved(){
        //do nothing
    }

    protected virtual void OnPinchOut(){
        GameManager.instance.onPinchOut();
        //do nothing
    }

    protected virtual void OnDoubleTap(){
        //do nothing
    }


    private void HandleDoubleTouch()
    {

        Touch firstTouch = Input.GetTouch(0);
        Touch secondTouch = Input.GetTouch(1);

        Vector2 prevFirstTouchPosition = firstTouch.position - firstTouch.deltaPosition;
        Vector2 prevSecondTouchPosition = secondTouch.position - secondTouch.deltaPosition;


        float prevDistance = (prevFirstTouchPosition - prevSecondTouchPosition).magnitude;
        float currentDistance = (firstTouch.position - secondTouch.position).magnitude;


        float distanceDifferenceInPercentage = ((currentDistance - prevDistance) / prevDistance) * 100;
        totalPercentageChange += distanceDifferenceInPercentage;
        //Debug.Log("totalPercentageChange so far" + totalPercentageChange);

        if (firstTouch.phase == TouchPhase.Ended || secondTouch.phase == TouchPhase.Ended)
        {
            ResetDoubleTouch();

        }

        if (totalPercentageChange < 0)
        {
            if (Mathf.Abs(totalPercentageChange) > 50 && backEventFired == false)
            {
                backEventFired = true;
                OnPinchOut();
                //this.SendMessage("OnPinchOut");
                //Debug.Log("back " + totalPercentageChange);
            }
        }




    }


    public void HandleDoubleTap()
    {
 
        if(Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            
            touchCount = touchCount + 1;
            //this.SendMessage("OnSingleMoved");
            Touch touch = Input.GetTouch(0);

            Vector3 mousePosFar = new Vector3(touch.position.x, touch.position.y, Camera.main.farClipPlane);
            Vector3 mousePosNear = new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane);

            Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
            Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

            Debug.DrawRay(mousePosN, mousePosF - mousePosN, Color.green);

            //Debug.Log("touchCount " + touchCount);

            if (touchCount == 1)
            {
                NewTime = Time.time + MaxDubbleTapTime;
                if(Physics.Raycast(mousePosN, mousePosF - mousePosN, out hit)){
                    if(hit.transform.gameObject.GetComponent<Node>() != null){
                        currentObjectClicked = hit.transform.gameObject;
                    }
                }
                //Debug.Log("NewTime " + NewTime);
            }

            if (touchCount >= 2 && Time.time <= NewTime)
            {
                //Debug.Log("Time.time " + Time.time);
                //this.SendMessage("OnDoubleTap");
                if (Physics.Raycast(mousePosN, mousePosF - mousePosN, out hit))
                {
                    if (hit.transform.gameObject.GetComponent<Node>() != null)
                    {
                        GameObject secondTimeObjectClicked = hit.transform.gameObject;
                        if(secondTimeObjectClicked != null &&
                           currentObjectClicked != null &&
                           secondTimeObjectClicked.GetInstanceID() == currentObjectClicked.GetInstanceID())
                        {
                            GameManager.instance.onObjectSelected(currentObjectClicked);
                        }
                    }
                }

                //OnDoubleTap();
                touchCount = 0;
                //currentNodeClicked = null;
            }


        }

            
        if (Time.time > NewTime)
        {
            touchCount = 0;
            currentObjectClicked = null;
        }
        
      
    }



    private void ResetDoubleTouch()
    {
        totalPercentageChange = 0;
        backEventFired = false;
    }




    //old logic

    /*
         
        if (firstTouch.phase == TouchPhase.Moved || secondTouch.phase == TouchPhase.Moved)
        {
            Debug.Log("double finger moving"); 
        }else{
            Debug.Log("record initial touch position");
        }




        if(firstTouch.phase == TouchPhase.Began && secondTouch.phase == TouchPhase.Began){
            Debug.Log("Setting initial touch position");
            firstInitTouchPoint = firstTouch.position;
            secondInitTouchPoint = secondTouch.position;
            Debug.Log("firstInitTouchPoint " + firstInitTouchPoint.ToString());
            Debug.Log("secondInitTouchPoint " + secondInitTouchPoint.ToString());
        }


        if (firstTouch.phase == TouchPhase.Moved && secondTouch.phase == TouchPhase.Moved)
        {
            Vector3 firstCurrentTouchPoint = firstTouch.position;
            Vector3 secondCurrentTouchPoint = secondTouch.position;

            //initial distance
            float initialDistance = (firstInitTouchPoint - secondInitTouchPoint).magnitude;

            //current distance
            float currentDistance = (firstCurrentTouchPoint - secondCurrentTouchPoint).magnitude;

            float changeInPercentage = ((initialDistance - currentDistance) / initialDistance) * 100;

            if (changeInPercentage < 0)
            {
                //pinch in
                if (Mathf.Abs(changeInPercentage) > 50)
                {
                    Debug.Log("back " + changeInPercentage);
                }
            }
            else
            {
                //pinch out
            }

        }

        */


}
