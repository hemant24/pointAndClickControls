using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prerequisite : MonoBehaviour {

    public Switcher switcher;
    public bool nodeAccess;

    public bool Complete {
        get {return switcher.state;}
    }


}
