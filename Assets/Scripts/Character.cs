using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour
{
    public float rotateSpeed = 8f;
    public float deltaX = 0.0f, deltaY = 0.0f;
    private int invertedPith = -1;



	/*
	 *     

    float smooth = 1.0f;
    Quaternion xAxis;
    protected override void OnDoubleTap()
    {
        //Debug.Log("handle double tap");
    }

   
    protected override void OnPinchOut(){
        this.transform.position = new Vector3(0f, 1f, -5f);
        this.transform.rotation = Quaternion.Euler(0f, -4.54f, 0f);
    }*/

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

	public void ResetCamera(float currentDeltaY)
	{
        deltaX = 0.0f;
        deltaY = currentDeltaY;
	}

    public void alignTo(Transform cameraPosition)
    {
        
        Sequence seq = DOTween.Sequence();
        //Move character
        //seq.Append(Camera.main.transform.DOMove(cameraPosition.position, 0.75f));
        seq.Append(transform.DOMove(cameraPosition.position, 0.75f));
        //Rotate Character 
        //seq.Join(Camera.main.transform.DORotate(cameraPosition.rotation.eulerAngles, 0.75f));
        seq.Join(transform.DORotate(new Vector3(0f, cameraPosition.rotation.eulerAngles.y, 0f), 0.75f));
        //Rotate Camera 
        seq.Join(Camera.main.transform.DOLocalRotate(new Vector3(cameraPosition.rotation.eulerAngles.x, 0, 0), 0.75f));
        ResetCamera(cameraPosition.rotation.eulerAngles.x);

    }

	void Update()
    {
        if (Input.touches.Length == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //Rotate Character
            transform.Rotate(0, Input.GetTouch(0).deltaPosition.x * rotateSpeed * Time.deltaTime * invertedPith, 0);

            //Rotate camera
            deltaY -= Input.GetTouch(0).deltaPosition.y * rotateSpeed * Time.deltaTime * invertedPith;
            deltaY = Mathf.Clamp(deltaY, minimumVert, maximumVert);
            float rotationY = Camera.main.transform.localEulerAngles.y;
            Debug.Log("rotation in x " + Camera.main.transform.localEulerAngles.x);
            Debug.Log("delta Y " + deltaY);
            Camera.main.transform.localEulerAngles = new Vector3(deltaY, rotationY, 0);
        }
    }


    /*
        following is the old logic

        transform.Rotate(Input.GetTouch(0).deltaPosition.y * rotateSpeed * Time.deltaTime,
                             Input.GetTouch(0).deltaPosition.x * rotateSpeed * Time.deltaTime * invertedPith , 0);



            deltaX += Input.GetTouch(0).deltaPosition.x * rotateSpeed * Time.deltaTime * invertedPith;
            deltaY -= Input.GetTouch(0).deltaPosition.y * rotateSpeed * Time.deltaTime * invertedPith;

            //this.transform.eulerAngles = new Vector3(deltaY, deltaX, 0f); //This was causing an issue.
            //Following worked upto certain extent
            Quaternion target = Quaternion.Euler(deltaY, deltaX , 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            

     */




}
