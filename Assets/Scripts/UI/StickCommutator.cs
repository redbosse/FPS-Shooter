using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StickCommutator : MonoBehaviour
{
    [SerializeField]
    private Stick leftStick;

    [SerializeField]
    private Stick rigthStick;

    public Stick LeftStick { get => leftStick; set => leftStick = value; }
    public Stick RigthStick { get => rigthStick; set => rigthStick = value; }

    public void Clear()
    {
        if (Application.isPlaying)
        {
            Destroy(this);
        }
        else
        {
            DestroyImmediate(this);
        }
    }
}