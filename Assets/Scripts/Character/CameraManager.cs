using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SOS.AndrewsAdventure.Character
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] float cameraRotateSpeed = 10;
        [SerializeField] float xBuffer = 100;
        [SerializeField] CinemachineVirtualCamera BattleCamera;
        [SerializeField] Transform battlePlayerLocation;
        [SerializeField] Transform player;  
        private float rotation = 0;

        public void HorizontalMovement(InputAction.CallbackContext value)
        {
            float x = value.ReadValue<Vector2>().x - Screen.width / 2;
            rotation = Mathf.Abs(x) > xBuffer ? cameraRotateSpeed * x : 0;
        }

        private void Update()
        {
            if (player.position == battlePlayerLocation.position) 
            {
                Camera.main.transform.position = new Vector3(0f, 0f, 90);
                BattleCamera.Priority = 3;
            }
        }
    }
}
