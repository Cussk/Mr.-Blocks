using Level;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        const string ObstacleTag = "Obstacle";
        const string FinishTag = "Finish";
        
        [SerializeField] LevelReferences levelReferences;
        [SerializeField] float speed = 5;
        
        LevelManager _levelManager;
        PlayerControls _playerControls;
        Rigidbody2D _rigidbody2D;
        Vector2 _moveInput;
    
        void Awake()
        {
            _levelManager = new LevelManager(levelReferences);
            _playerControls = new PlayerControls();
            _rigidbody2D = GetComponent<Rigidbody2D>();
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
    
        void FixedUpdate()
        {
            MovePlayer();
        }
        
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(ObstacleTag))
            {
                PlayerDied();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(FinishTag))
            {
                _levelManager.OnLevelComplete();
            }
        }

        void MovePlayer()
        {
            Vector2 newVelocity = new Vector2(_moveInput.x, _moveInput.y).normalized * speed;
            _rigidbody2D.linearVelocity = newVelocity;
        }

        void PlayerDied()
        {
            Destroy(gameObject);
            _levelManager.OnPlayerDied();
        }
    }
}
