using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SOS.AndrewsAdventure.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float sprintMultiplier = 2f;
        [SerializeField] public float walkSpeed = 5f;
        [SerializeField] float jumpSpeed = 3f;
        [SerializeField] CinemachineVirtualCamera vCamera3rdPerson;

        public bool CanMove { get; set; }

        CharacterController controller;

        private const float gravityValue = -9.8f;
        private float speedMultiplier = 1f;
        private Vector3 movementComposite = Vector3.zero;

        void Start()
        {
            CanMove = true;
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            if (CanMove)
            {
                if (vCamera3rdPerson.Priority == 10)
                {
                    float facing = Camera.main.transform.eulerAngles.y;
                    Vector3 turnedMovement = Quaternion.Euler(0, facing, 0) * movementComposite;
                    controller.Move(turnedMovement * walkSpeed * speedMultiplier * Time.deltaTime);
                    movementComposite.y += gravityValue * Time.deltaTime;
                }
            }
        }

        public void OnMovement(InputAction.CallbackContext value)
        {
            movementComposite = value.ReadValue<Vector3>();
        }

        public void OnJump(InputAction.CallbackContext value)
        {
            if (Input.GetKeyDown("space") && controller.isGrounded)
            {
                movementComposite.y = jumpSpeed; ;
            }
        }

        public void OnSprint(InputAction.CallbackContext value)
        {
            if (value.started) speedMultiplier = sprintMultiplier;
            else if(value.canceled) speedMultiplier = 1f;
        }
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if(controller.isGrounded == true && hit.transform.CompareTag("Movable"))
            {
                Rigidbody boxBody = hit.collider.attachedRigidbody;
                if(boxBody == null || boxBody.isKinematic) 
                {
                    return;
                }
                Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
                boxBody.velocity = pushDir * 2;
            }
        }
    }
}
