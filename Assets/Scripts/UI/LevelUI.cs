using SceneManagement;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LevelUI
    {
        readonly GameObject _levelPanel;
        readonly GameObject _gameOverPanel;
        readonly TextMeshProUGUI _levelText;
        readonly TextMeshProUGUI _gameOverText;

        public LevelUI(LevelReferences levelReference, int currentLevel)
        {
            _levelPanel = levelReference.LevelPanel;
            _gameOverPanel = levelReference.GameOverPanel;
            _levelText = levelReference.LevelText;
            _gameOverText = levelReference.GameOverText;
            
            UpdateLevelText(currentLevel);
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

        void UpdateLevelText(int levelNumber)
        {
            _levelText.text = $"Level: {levelNumber}";
            ToggleLevelPanel(true);
        }
    }
}
