using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoaders
{
    public class SceneLoader
    {
        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}