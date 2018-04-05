using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollideReset : MonoBehaviour {
    public Transform resetPoint;
    Vector3 startPos;
    private void Start()
    {
        startPos = resetPoint.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = startPos;
    }
}
