using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 rotationToAdd = new Vector3(5, 5, 5);
        transform.Rotate(rotationToAdd);
    }
}
