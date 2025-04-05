using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImagesController : MonoBehaviour
{
    private int Selector;

    public GameObject primero;
    public GameObject segundo;
    public GameObject tercero;
    public GameObject cuarto;
    public GameObject quinto;
    
    void Start()
    {
        MusicManager.Instance.PlayMusic("CinematicIntroAudio");
        Selector = 0;
    }

    //Llamar en el On click()
    public void Paso()
    {
        Selector++;

        switch (Selector)
        {
            case 1:
                primero.SetActive(false);
                segundo.SetActive(true);
                break;

            case 2:
                segundo.SetActive(false);
                tercero.SetActive(true);
                break;

            case 3:
                tercero.SetActive(false);
                cuarto.SetActive(true);
                break;

            case 4:
                cuarto.SetActive(false);
                quinto.SetActive(true);
                break;

            case 5:
                quinto.SetActive(false);
                SceneManager.LoadScene("Game");
                break;

        }
    }
}
