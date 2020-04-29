using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsCamera : MonoBehaviour {

    [HideInInspector]
    public Transform model;
    public Transform rig;

    private GameObject itemHolder;
    [SerializeField] private CameraInputData camInputData = null;

    public float rotateSpeed = 8f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float deltaY = 0.0f;
    private int invertedPith = -1;

    public void Close(){
        Destroy(itemHolder);
        model = null;
        //rig.localRotation = Quaternion.Euler(Vector3.zero); This does not work
        rig.rotation = Quaternion.identity;
        deltaY = 0;
        gameObject.SetActive(false);
    }

    public void Activate(GameObject gObject){
        
        Debug.Log("inside activate");
        //gameObject.SetActive(true);
        itemHolder = Instantiate(gObject);
        itemHolder.transform.SetParent(rig);
        itemHolder.transform.localPosition = Vector3.zero;
        itemHolder.transform.GetChild(0).localPosition = Vector3.zero;
        model = itemHolder.transform;
        gameObject.SetActive(true); //TODO: this is not working at very first time
    }

    void Start () {
        gameObject.SetActive(false);
    }

	private void Update()
	{
        if (model != null){

            //Rotate model

            model.Rotate(0, camInputData.InputVectorX * rotateSpeed * Time.deltaTime * invertedPith, 0);


            //Rotate rig
            //rig.Rotate(Input.GetTouch(0).deltaPosition.y * rotateSpeed * Time.deltaTime * invertedPith * -1, 0, 0);

            deltaY -= camInputData.InputVectorY * rotateSpeed * Time.deltaTime * invertedPith;
            deltaY = Mathf.Clamp(deltaY, minimumVert, maximumVert);
            float rotationY = rig.localEulerAngles.y;
            rig.localEulerAngles = new Vector3(deltaY, rotationY, 0);


        }
	}

}
