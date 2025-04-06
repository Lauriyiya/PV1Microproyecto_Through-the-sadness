using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("CinematicIntro");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
