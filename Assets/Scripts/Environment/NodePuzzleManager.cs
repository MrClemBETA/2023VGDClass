using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class TouchObjectManager : MonoBehaviour
{
    int nodesTouched;
    [SerializeField] int nodesNeeded = 3;
    [SerializeField] GameObject linkedObject;
    private void OnTriggerEnter(Collider other)
    {
        nodesTouched++;
    }
    void Update()
    {
        if (nodesTouched == nodesNeeded)
        {
            if (linkedObject.activeSelf == true)
            {
                linkedObject.SetActive(false);
            }
            else if (linkedObject.activeSelf == false)
            {
                linkedObject.SetActive(true);
            }
        }

    }
}
