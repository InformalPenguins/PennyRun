using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InformalPenguins
{
    public class StartInputController : MonoBehaviour
    {
        public GameManagerController manager;
        void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                manager.Run();
            }
        }
    }
}
