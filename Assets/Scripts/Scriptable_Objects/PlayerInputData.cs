using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInputData", menuName = "PersonController/Data/PlayerInputData", order = 0)]
public class PlayerInputData : ScriptableObject 
{

    #region Data
        private bool m_clickReleased;
        private Vector3 m_clickedPosition;
        private Vector3 m_clickedDirection;
        private bool m_backClickedReleased;
        private bool m_doubleClickedReleased;

    #endregion

    public bool DoubleClickedOnNode
    {
        get
        {
            return m_doubleClickedReleased;
        }
        set
        {

            m_doubleClickedReleased = value;
        }
    }

    public bool ClickReleased
    {
        get
        {
            return m_clickReleased;
        }
        set
        {

            m_clickReleased = value;
        }
    }
    public bool BackClicked
    {
        get
        {
            return m_backClickedReleased;
        }
        set
        {

            m_backClickedReleased = value;
        }
    }

    public Vector3 ClickedPosition
    {
        get
        {
            return m_clickedPosition;
        }
        set 
        {
            m_clickedPosition = value;  
        } 
    }

    public Vector3 ClickedDirection
    {
        get 
        {
            return m_clickedDirection;  
        } 
        set {
            m_clickedDirection = value;
        } 
    }




    public void ResetInput()
    {
        m_clickReleased = false;
        m_clickedPosition = Vector3.zero;
        m_clickedDirection = Vector3.zero;
    }
}
