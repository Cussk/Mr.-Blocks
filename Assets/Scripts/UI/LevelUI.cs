using Level;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LevelUI
    {
        readonly GameObject _levelPanel;
        readonly GameObject _gameOverPanel;
        readonly TextMeshProUGUI _levelText;
        readonly TextMeshProUGUI _gameOverText;
        

        int _levelNumber;

        public LevelUI(LevelReferences levelReference)
        {
            _levelPanel = levelReference.LevelPanel;
            _gameOverPanel = levelReference.GameOverPanel;
            _levelText = levelReference.LevelText;
            _gameOverText = levelReference.GameOverText;
            
            UpdateLevelText();
        }

        public void ShowGameWinUI()
        {
            ToggleGameOverPanel(true);
            _gameOverText.text = "Game Completed!!";
            _gameOverText.color = Color.green;
            ToggleLevelPanel(false);
        }

        public void ShowGameLoseUI()
        {
            ToggleGameOverPanel(true);
            _gameOverText.text = "Game Over!!";
            _gameOverText.color = Color.red;
            ToggleLevelPanel(false);
        }

        void ToggleLevelPanel(bool isActive)
        {
            _levelPanel.SetActive(isActive);
        }

        void ToggleGameOverPanel(bool isActive)
        {
            _gameOverPanel.SetActive(isActive);
        }

        void UpdateLevelText()
        {
            _levelNumber = SceneManager.GetActiveScene().buildIndex;
            _levelText.text = $"Level: {_levelNumber}";
            ToggleLevelPanel(true);
        }
    }
}
