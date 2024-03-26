using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoaders
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
            //Added for reset timescale if loading the LoadingScene
            if (sceneIndex == 0)
                Time.timeScale = 1;
        }
    }
}