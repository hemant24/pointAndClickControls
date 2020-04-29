using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    #region Data
    [Space, Header("Input Data")]
    [SerializeField]
    private CameraInputData cameraInputData = null;
    [SerializeField]
    private PlayerInputData playerInputData = null;

    private float totalPercentageChange = 0;
    private bool backEventFired = false;
    #endregion

    #region BuiltInMethods
    void Start()
    {
        cameraInputData.ResetInput();
        playerInputData.ResetInput();
    }

    void Update()
    {
        GetCameraInput();
        GetPlayerInput();
    }
    #endregion

    #region Custom Methods

    void GetCameraInput()
    {
        //Get Mobile Inpute
        if (Input.touches.Length == 1 &&
            Input.GetTouch(0).phase == TouchPhase.Moved) 
        {
            cameraInputData.InputVectorX = Input.GetTouch(0).deltaPosition.x;
            cameraInputData.InputVectorY = Input.GetTouch(0).deltaPosition.y;

        }else 
        {
            cameraInputData.InputVectorX = Input.GetAxis("Mouse X") * cameraInputData.mouseSensitivity;
            cameraInputData.InputVectorY = Input.GetAxis("Mouse Y") * cameraInputData.mouseSensitivity;
        }
    }

    void GetPlayerInput()
    {
        //Get Mobile Inputs
        GetMobileInput();
        GetMouseInput();
    }

    private void GetMobileInput()
    {
        if (Input.touches.Length == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                playerInputData.ClickReleased = true;
                Touch touch = Input.GetTouch(0);
                Vector3 mousePosFar = new Vector3(touch.position.x, touch.position.y, Camera.main.farClipPlane);
                Vector3 mousePosNear = new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane);

                Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
                Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

                playerInputData.ClickedPosition = mousePosN;
                playerInputData.ClickedDirection = mousePosF - mousePosN;
            }
            else
            {
                playerInputData.ClickReleased = false;
            }
        }
        else if (Input.touches.Length == 2) 
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
                ResetTwoFingerTouch();
                playerInputData.BackClicked = false;
            }

            if (totalPercentageChange < 0)
            {
                if (Mathf.Abs(totalPercentageChange) > 50 && backEventFired == false)
                {
                    backEventFired = true;
                    playerInputData.BackClicked = true;
                }
            }
        }
        
    }

    private void GetMouseInput()
    {
        playerInputData.ClickReleased = Input.GetMouseButtonUp(0);
        playerInputData.BackClicked = Input.GetMouseButtonUp(1);
        playerInputData.ClickedPosition = Camera.main.transform.position;
        playerInputData.ClickedDirection = Camera.main.transform.forward;


    }


    private void ResetTwoFingerTouch()
    {
        totalPercentageChange = 0;
        backEventFired = false;
    }

    #endregion
}
