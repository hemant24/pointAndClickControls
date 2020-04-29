using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraInputData", menuName = "PersonController/Data/CameraInputData", order = 0)]
public class CameraInputData : ScriptableObject
{

    #region Data
    Vector2 m_inputVector;
    [Space, Header("Settings")] public float mouseSensitivity = 20f;

    #endregion



    #region Properties
    public Vector2 InputVector 
    { 
        get { return m_inputVector; } 
    }

    public float InputVectorX
    {
        get
        { 
            return m_inputVector.x ; 
        }
        set 
        { 
            m_inputVector.x = value ; 
        }
    }

    public float InputVectorY
    {
        get { return m_inputVector.y; }
        set { m_inputVector.y = value; }
    }
    #endregion

    #region Custom Methods
    public void ResetInput()
    {
        m_inputVector = Vector2.zero;
       
    }
    #endregion
}
