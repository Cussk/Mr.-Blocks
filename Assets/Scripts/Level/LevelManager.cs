using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class LevelManager
    {
        readonly int _currentLevel;
    
        public LevelManager()
        {
            _currentLevel = SceneManager.GetActiveScene().buildIndex;
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
                Debug.Log("You've beaten all the levels");
            }
        }

        public void RestartLevel() => SceneManager.LoadScene(_currentLevel);
    }
}
