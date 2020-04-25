using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Prerequisite : MonoBehaviour {


    public bool nodeAccess;

    public abstract bool IsCompleted();


}
