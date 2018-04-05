using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    public Transform target;
    private Vector3 initial;
    private Vector3 difference;
    public float pushedX = 0f;
    void Start()
    {
        difference = transform.position - target.transform.position;
        initial = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3((target.position + difference).x + pushedX, initial.y, initial.z);
    }
}
