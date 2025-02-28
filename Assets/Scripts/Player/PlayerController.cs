using SceneManagement;
using Sound;
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
        SoundManager _soundManager;
        Vector2 _moveInput;

        void Awake()
        {
            _playerControls = new PlayerControls();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            _soundManager = FindFirstObjectByType<SoundManager>();
            _levelManager = new LevelManager(levelReferences, _soundManager);
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
                LevelCompleted();
            }
        }

        void MovePlayer()
        {
            Vector2 newVelocity = new Vector2(_moveInput.x, _moveInput.y).normalized * speed;
            _rigidbody2D.linearVelocity = newVelocity;
        }
        
        void LevelCompleted()
        {
            _soundManager.PlayLevelCompleteAudio();
            _levelManager.OnLevelComplete();
        }

        void PlayerDied()
        {
            _soundManager.PlayGameOverAudio();
            Destroy(gameObject);
            _levelManager.OnPlayerDied();
        }
    }
}
