using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InformalPenguins
{
    public class ToyCollider : MonoBehaviour
    {
        private Vector3 Zero = Vector3.zero;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Player"))
            {
                PennyController controller = other.GetComponentInParent<PennyController>();
                Transform newParent= controller.Mouth.transform;
                transform.position = newParent.position;
                transform.SetParent(newParent);
                controller.AddToy();
            }
        }
    }
}