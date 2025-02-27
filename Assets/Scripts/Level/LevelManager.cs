using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Level
{
    public class LevelManager
    {
        readonly int _currentLevel;
        LevelUI _levelUI;
        Button _restartButton;
        Button _mainMenuButton;
    
        public LevelManager(LevelReferences levelReferences)
        {
            _currentLevel = SceneManager.GetActiveScene().buildIndex;
            _levelUI = new LevelUI(levelReferences);
            _restartButton = levelReferences.RestartButton;
            _mainMenuButton = levelReferences.MainMenuButton;
            ButtonAddListeners();
        }
    
        public void OnLevelComplete()
        {
            int nextLevel = _currentLevel + 1;
            int maxLevel = SceneManager.sceneCountInBuildSettings;

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
        }

        public void RestartLevel() => SceneManager.LoadScene(_currentLevel);
    }
}
