using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arena.UI
{
    public class MenuButton : MonoBehaviour
    {
        public void PauseOn()
        {
            Time.timeScale = 0;
        }

        public void PauseOff()
        {
            Time.timeScale = 1;
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    }
}