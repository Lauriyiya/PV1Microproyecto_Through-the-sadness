using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{

    public GameObject pausePanel;
    //Static sirve para que podamos acceder a esta variable sin tener que acceder al objeto
    //Ideal para variables que se comunican entre scripts
    public static bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        //Para asegurarse colocar que el tiempo va a uno para que cuando salgamos del menú de pausa no de errores raros
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Si venimos del juego isPaused es falso
            if (!isPaused) //isPaused == false;
            {
                isPaused = true;

                //hacer que aparezca el panel
                pausePanel.SetActive(true);

                //Que se pare el juego mientras estamos en el menu de pausa
                Time.timeScale = 0;
            }
            else
            {
                isPaused = false;
                pausePanel.SetActive(false);
                Time.timeScale = 1;
            }
        }   
    }

    public void StartButton()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
