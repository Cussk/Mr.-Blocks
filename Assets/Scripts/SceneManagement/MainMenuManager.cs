using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneManagement
{
    public class MainMenuManager : MonoBehaviour
    {
        const int FirstLevelIndex = 1;
        
        [SerializeField] Button playButton;
        [SerializeField] Button quitButton;
        
        SoundManager _soundManager;

        void Awake()
        {
            AddButtonListeners();
        }

        void Start()
        {
            _soundManager = FindFirstObjectByType<SoundManager>();
        }

        void AddButtonListeners()
        {
            playButton.onClick.AddListener(PlayGame);
            quitButton.onClick.AddListener(QuitGame);
        }

        void PlayGame()
        {
            _soundManager.PlayButtonClickAudio();
            SceneManager.LoadScene(FirstLevelIndex);
        }

        void QuitGame()
        {
            _soundManager.PlayButtonClickAudio();
            Application.Quit();
        }
    }
}
