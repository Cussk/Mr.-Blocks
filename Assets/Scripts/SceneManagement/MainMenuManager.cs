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

        void Awake()
        {
            AddButtonListeners();
        }

        void AddButtonListeners()
        {
            playButton.onClick.AddListener(PlayGame);
            quitButton.onClick.AddListener(QuitGame);
        }

        void PlayGame() => SceneManager.LoadScene(FirstLevelIndex);
        
        void QuitGame() => Application.Quit();
    }
}
