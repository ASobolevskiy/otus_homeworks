using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoaders
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}