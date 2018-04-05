using UnityEngine;

namespace InformalPenguins
{
    public class InputManager : MonoBehaviour
    {
        public PennyController player;

        public void Run()
        {
            player.Run();
        }

        void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                player.Jump();
            }
        }
    }
}