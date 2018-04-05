using UnityEngine;

namespace InformalPenguins
{
    public class PennyController : MonoBehaviour
    {

        private Animator _myAnimator;
        private Rigidbody _myRigidBody;
        public float RunningSpeed = 30f;
        public Vector3 JumpForce = new Vector3(0, 45, 0);
        private Vector3 ZERO = Vector3.zero;
        private Vector3 _selectedSpeed;
        private bool isGrounded = true;
        private bool isRunning = false;
        public Transform Mouth;
        [SerializeField]
        public LayerMask WhatIsGround;
        [SerializeField]
        public Transform GroundCheck;
        float groundCheckRadius = 1f;
        public int toyCounter = 0;
        private float toyPlayTimer = 2f;
        private float LastPlayTime = 0f;
        public Vector3 DEBUG_SPEED;
        private bool _hasPlayed = true;
        private void Start()
        {
            _myAnimator = GetComponent<Animator>();
            _myRigidBody = GetComponent<Rigidbody>();
            _myRigidBody.velocity = ZERO;
            _selectedSpeed = ZERO;
        }
        private float maxFallSpeed = -9.5f;
        private void ResetFall() {
            _myRigidBody.velocity = new Vector3(_myRigidBody.velocity.x, maxFallSpeed, _myRigidBody.velocity.z);
        }
        private void Harm()
        {
            GameManagerController.GetInstance().HarmPlayer();
        }
        public void TakeToy()
        {
            toyCounter--;
            if (Mouth.transform.childCount > 0) {
                Destroy(Mouth.transform.GetChild(0));
            }
            
        }
        public void AddToy()
        {
            toyCounter++;
            LastPlayTime = Time.time;
            _hasPlayed = false;
        }
        private void Update()
        {
            if (_myRigidBody.velocity.y < maxFallSpeed)
            {
                ResetFall();
            }
            if (isGrounded)
            {
                _myAnimator.SetBool("IsJumping", false);
                _myAnimator.SetBool("IsFalling", false);
                _myAnimator.SetBool("IsRunning", isRunning);
                if (isRunning)
                {
                    _myRigidBody.velocity = new Vector3(RunningSpeed, _myRigidBody.velocity.y, _myRigidBody.velocity.z);

                    if (!_hasPlayed && toyCounter > 0 && (Time.time - LastPlayTime > toyPlayTimer))
                    {
                        _hasPlayed = true;
                        LastPlayTime = Time.time;
                        _myAnimator.SetTrigger("PlayWithToy");
                    }
                }
            }
            else
            {
                if (_myRigidBody.velocity.y < 0)
                {
                    _myAnimator.SetBool("IsJumping", false);
                    _myAnimator.SetBool("IsFalling", true);
                }
                else
                {
                    _myAnimator.SetBool("IsJumping", true);
                    _myAnimator.SetBool("IsFalling", false);
                }
            }

            //isGrounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, WhatIsGround);
            isGrounded = Physics.OverlapSphere(GroundCheck.position, groundCheckRadius, WhatIsGround).Length > 0;
            _myAnimator.SetBool("IsGrounded", isGrounded);
        }
        public void Run()
        {
            isRunning = true;
            //_selectedSpeed = RunningSpeed;
            //_myRigidBody.AddForce(RunningSpeed, ForceMode.VelocityChange);
            //_myRigidBody.velocity = RunningSpeed;
            _myAnimator.SetBool("IsRunning", true);
        }
        public void Jump()
        {
            if (isGrounded) { 
                _myRigidBody.AddForce(JumpForce, ForceMode.Impulse);
                _myAnimator.SetBool("IsJumping", true);
            }
        }
        public void Walk()
        {
            _myAnimator.SetBool("IsRunning", false);
        }
        public void Fall()
        {
            //_myAnimator.SetBool("IsFalling", true);
        }
    }
}
