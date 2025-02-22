using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LevelUI : MonoBehaviour
    {
        [SerializeField] GameObject levelPanel;
        [SerializeField] TextMeshProUGUI levelText;

        int _levelNumber;

        void Start()
        {
            UpdateLevelText();
        }

        public void HideLevelPanel()
        {
            levelPanel.SetActive(false);
        }

        void UpdateLevelText()
        {
            _levelNumber = SceneManager.GetActiveScene().buildIndex;
            levelText.text = $"Level: {_levelNumber}";
        }
    }
}
