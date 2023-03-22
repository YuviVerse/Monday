using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void OnButtonStartPressed()
        {
            SceneManager.LoadScene("GamePlay");
        }

        public void OnQuitButtonPressed()
        {
            Application.Quit();
        }
    }
}