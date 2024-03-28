using UnityEngine;
using UnityEngine.InputSystem;

namespace SOS.AndrewsAdventure.Character
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] float cameraRotateSpeed = 10;
        [SerializeField] float xBuffer = 100;
        public bool inbattle = false;
        private float rotation = 0;

        public void HorizontalMovement(InputAction.CallbackContext value)
        {
            float x = value.ReadValue<Vector2>().x - Screen.width / 2;
            rotation = Mathf.Abs(x) > xBuffer ? cameraRotateSpeed * x : 0;
        }

        private void Update()
        {
            transform.Rotate(Vector3.up, rotation / 360);
            if (inbattle == true)
            {
                Camera.main.transform.position = new Vector3(0f, 0f, 90);
            }
        }
    }
}
