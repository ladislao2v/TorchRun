using UnityEngine.SceneManagement;

namespace Code.Services.SceneLoader
{
    public class SceneLoader
    {
        public void Restart()
        {
            var activeScene = SceneManager.GetActiveScene();

            SceneManager.LoadScene(activeScene.buildIndex);
        }
    }
}