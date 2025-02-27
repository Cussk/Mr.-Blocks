using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SceneManagement
{
    public class LevelReferences : MonoBehaviour
    {
        [SerializeField] GameObject levelPanel;
        [SerializeField] GameObject gameOverPanel;
        [SerializeField] TextMeshProUGUI levelText;
        [SerializeField] TextMeshProUGUI gameOverText;
        [SerializeField] Button restartButton;
        [SerializeField] Button mainMenuButton;

        #region Properties

        public GameObject LevelPanel => levelPanel;
        public GameObject GameOverPanel => gameOverPanel;
        public TextMeshProUGUI LevelText => levelText;
        public TextMeshProUGUI GameOverText => gameOverText;
        public Button RestartButton => restartButton;
        public Button MainMenuButton => mainMenuButton;

        #endregion
    }
}
