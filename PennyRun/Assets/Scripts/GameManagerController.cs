using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InformalPenguins
{
    public class GameManagerController : MonoBehaviour
    {
        private static GameManagerController _instance = null;
        public static GameManagerController GetInstance() {
            return _instance;
        }
        public InputManager inputManager;
        public StartInputController startController;
        public GameObject[] disableObjects;
        public CarController carController;

        void Start()
        {
            if (GameManagerController._instance == null)
            {
                GameManagerController._instance = this;
            }
            Stop();
        }

        public void Run()
        {
            inputManager.enabled = true;
            startController.enabled = false;
            inputManager.Run();
            foreach (GameObject disabledObject in disableObjects) {
                disabledObject.SetActive(false);
            }
        }
        public void Stop()
        {
            inputManager.enabled = false;
            startController.enabled = true;
        }

        internal void HarmPlayer()
        {
            carController.pushedX += 1f;
        }
    }
}
