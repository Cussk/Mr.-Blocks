using Sound;
using UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneManagement
{
    public class LevelManager
    {
        const int MainMenuIndex = 0;

        readonly SoundManager _soundManager;
        readonly LevelUI _levelUI;
        readonly Button _restartButton;
        readonly Button _mainMenuButton;
        readonly int _currentLevel;
    
        public LevelManager(LevelReferences levelReferences, SoundManager soundManager)
        {
            _soundManager = soundManager;
            _currentLevel = SceneManager.GetActiveScene().buildIndex;
            _levelUI = new LevelUI(levelReferences, _currentLevel);
            _restartButton = levelReferences.RestartButton;
            _mainMenuButton = levelReferences.MainMenuButton;
            ButtonAddListeners();
        }
    
        public void OnLevelComplete()
        {
            int nextLevel = _currentLevel + 1;
            int maxLevel = SceneManager.sceneCountInBuildSettings - 1;

            if (nextLevel <= maxLevel)
            {
                SceneManager.LoadScene(nextLevel);
            }
            else
            {
                _levelUI.ShowGameWinUI();
            }
        }
        
        public void OnPlayerDied() => _levelUI.ShowGameLoseUI();
        
        void ButtonAddListeners()
        {
            _restartButton.onClick.AddListener(RestartLevel);
            _mainMenuButton.onClick.AddListener(LoadMainMenu);
        }

        void LoadMainMenu()
        {
            _soundManager.PlayButtonClickAudio();
            _soundManager.DestroySoundManager();
            SceneManager.LoadScene(MainMenuIndex);
        }

        void RestartLevel()
        {
            _soundManager.PlayButtonClickAudio();
            SceneManager.LoadScene(_currentLevel);
        }
    }
}
