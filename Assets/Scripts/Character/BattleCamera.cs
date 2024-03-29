using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCamera : MonoBehaviour
{
    public CinemachineVirtualCamera Camera;
    public Transform battleLocation;
    public Transform Andrew;
    void Update()
    {
        if(Andrew.position == battleLocation.position)
        {
            Camera.Priority = 3;
        }
    }
}
