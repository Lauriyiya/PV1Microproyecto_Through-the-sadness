using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImagesController2 : MonoBehaviour
{
    public GameObject primero;
    public GameObject segundo;
    public GameObject tercero;
    public GameObject cuarto;
    public GameObject quinto;
    /*public GameObject sexto;
    public GameObject septimo;
    public GameObject octavo;
    public GameObject noveno;
    public GameObject decimo;
    public GameObject once;
    public GameObject doce;
    public GameObject trece;
    public GameObject catorce;*/
    private int Selector;

    void start()
    {
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
                SceneManager.LoadScene("Victory");
                break;

                /*case 6:
                    sexto.SetActive(false);
                    septimo.SetActive(true);
                    break;

                case 7:
                    septimo.SetActive(false);
                    octavo.SetActive(true);
                    break;

                case 8:
                    octavo.SetActive(false);
                    noveno.SetActive(true);
                    break;

                case 9:
                    noveno.SetActive(false);
                    decimo.SetActive(true);
                    break;

                case 10:
                    decimo.SetActive(false);
                    once.SetActive(true);
                    break;

                case 11:
                    once.SetActive(false);
                    doce.SetActive(true);
                    break;

                case 12:
                    doce.SetActive(false);
                    trece.SetActive(true);
                    break;

                case 13:
                    trece.SetActive(false);
                    catorce.SetActive(true);
                    break;*/

        }
    }
}

