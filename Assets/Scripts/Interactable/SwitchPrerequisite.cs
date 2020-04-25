using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPrerequisite : Prerequisite {

    public Switcher switcher;

    public override bool IsCompleted()
    {
        return switcher.state;
    }
}
