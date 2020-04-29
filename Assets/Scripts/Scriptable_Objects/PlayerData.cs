using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PersonController/Data/PlayerData", order = 0)]
public class PlayerData : ScriptableObject
{
    #region Data
    private Node m_clickedNode;
    private Node m_selectedNode;
    #endregion


    public Node SelectedNode
    {
        get
        {
            return m_selectedNode;
        }
        set
        {
            m_selectedNode = value;
        }
    }

    public void ResetData()
    {
        m_selectedNode = null;
    }

    public bool IsEmpty()
    {
        return m_selectedNode == null;
    }

    public bool IsSameNode(Node selectedNode)
    {
        return m_selectedNode == selectedNode;
    }
}
