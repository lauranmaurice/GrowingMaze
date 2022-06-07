using UnityEngine;

namespace Assets.Scripts
{
    public class InputController : MonoBehaviour
    {
        private InputMaster _inputMaster;
        public PlayerController Player;

        private Vector3 _movement;

        private void Awake()
        {
            _inputMaster = new InputMaster();
            _inputMaster.Enable();

            _inputMaster.Player.Movement.performed += context =>
            {
                var mv = context.ReadValue<Vector2>();
                _movement = new Vector3(mv.x, 0.0f, mv.y);
            };
        }

        private void Update()
        {
            if (_inputMaster.Player.Movement.inProgress)
            {
                Player.Move(_movement * Time.deltaTime);
            }
        }
    }
}
