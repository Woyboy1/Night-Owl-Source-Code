using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class LocalPosition : MonoBehaviour
{
    public string localPositionName;
    [HideInInspector] public Vector3 localPosVector;

    private void Start()
    {
        localPosVector = transform.position;
    }
}
