using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        PlayerControls _playerControls;
        Vector2 _moveInput;
        [SerializeField] float speed = 5;
    
        void Awake()
        {
            _playerControls = new PlayerControls();
        }

        void OnEnable()
        {
            _playerControls.Player.Move.performed += context => _moveInput = context.ReadValue<Vector2>();
            _playerControls.Player.Move.canceled += _ => _moveInput = Vector2.zero;
            _playerControls.Enable();
        }

        void OnDisable()
        {
            _playerControls.Disable();
        }
    
        void Update()
        {
            MovePlayer();
        }

        void MovePlayer()
        {
            Vector3 moveDirection = new Vector3(_moveInput.x, _moveInput.y, 0);
            Vector3 moveDelta = moveDirection * (speed * Time.deltaTime);
            transform.position += moveDelta;
        }
    }
}
