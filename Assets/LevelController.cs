using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies;
    private static int _nextLevelIndex = 1;

    private void OnEnable()
    {
        // Save all enemies when scene starts
        _enemies = FindObjectsOfType<Enemy>();
    }
    // Update is called once per frame
    void Update()
    {
        // check if all enemies are dead
        foreach(Enemy enemy in _enemies)
        {
            if( enemy != null)
            {
                // still have one alive
                return;
            }

            // Increase level number
            _nextLevelIndex++;
            string nextLevelName = "Level" + _nextLevelIndex;
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
