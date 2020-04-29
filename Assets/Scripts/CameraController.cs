using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{

    #region Data
    [Space, Header("Data")]
    [SerializeField] private CameraInputData camInputData = null;

    #endregion

    public float rotateSpeed = 8f;
    public float deltaX = 0.0f, deltaY = 0.0f;
    private int invertedPith = -1;
    private bool aligning = false;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

	public void ResetCamera(float currentDeltaY)
	{
        deltaX = 0.0f;
        deltaY = currentDeltaY;
	}

	public void Awake()
	{
        ChangeCursorState();
	}
    void ChangeCursorState()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    public void alignTo(Transform cameraPosition, Sequence seq)
    {
        aligning = true;
        //Rotate Camera Holder
        //seq.Join(Camera.main.transform.DORotate(cameraPosition.rotation.eulerAngles, 0.75f));
        seq.Join(transform.DORotate(new Vector3(0f, cameraPosition.rotation.eulerAngles.y, 0f), 0.75f));

        //Rotate Camera 
        seq.Join(Camera.main.transform.DOLocalRotate(new Vector3(cameraPosition.rotation.eulerAngles.x, 0, 0), 0.75f))
           .OnComplete(() => { 
                aligning = false;
                deltaY = cameraPosition.rotation.eulerAngles.x;
            });
        //Debug.Log(Camera.main.transform.localEulerAngles.x);
        //ResetCamera(cameraPosition.rotation.eulerAngles.x);
    }

	public void alignTo(Transform cameraPosition)
    {
        
        Sequence seq = DOTween.Sequence();
        //Move character

        //seq.Append(transform.DOMove(cameraPosition.position, 0.75f));
        //Rotate Character 

        //seq.Join(transform.DORotate(new Vector3(0f, cameraPosition.rotation.eulerAngles.y, 0f), 0.75f));
        //Rotate Camera 
        //seq.Join(Camera.main.transform.DOLocalRotate(new Vector3(cameraPosition.rotation.eulerAngles.x, 0, 0), 0.75f));
        //ResetCamera(cameraPosition.rotation.eulerAngles.x);

    }

	void Update()
    {
        if (!aligning &&
            !GameManager.instance.iVCanvas.gameObject.activeInHierarchy &&
            !GameManager.instance.obsCamera.gameObject.activeInHierarchy)
        {
            Debug.Log("calling..");
            //Rotate camera holder
            transform.Rotate(0, camInputData.InputVectorX * rotateSpeed * Time.deltaTime * invertedPith, 0);

            //Rotate camera
            deltaY -= camInputData.InputVectorY * rotateSpeed * Time.deltaTime * invertedPith;
            deltaY = Mathf.Clamp(deltaY, minimumVert, maximumVert);
            float rotationY = Camera.main.transform.localEulerAngles.y;
            //Debug.Log("rotation in x " + Camera.main.transform.localEulerAngles.x);
            //Debug.Log("delta Y " + deltaY);
            Camera.main.transform.localEulerAngles = new Vector3(deltaY, rotationY, 0);
        }

    }


}
