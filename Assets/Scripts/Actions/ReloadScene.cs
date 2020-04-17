using UnityEngine;
using UnityEngine.SceneManagement;

namespace Actions
{
    [AddComponentMenu("Actions/Reload Scene")]
    public class ReloadScene : BaseAction
    {
        protected override void Act()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}