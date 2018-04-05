using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InformalPenguins
{
    public class FollowCamera : MonoBehaviour
    {
        public Transform target;
        private Vector3 difference;
        void Start()
        {
            difference = transform.position - target.transform.position;
        }

        void Update()
        {
            transform.position = target.position + difference;
        }
    }
}
