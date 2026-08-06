using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject MenuOpciones;
    public GameObject MenuInicial;

    public void Iniciarjuego()
    {
        SceneManager.LoadScene(1);

    }

    public void finalizarJuego()
    {
        Application.Quit();

    }

    public void MostrarOpciones()
    {
        MenuInicial.SetActive(false);
        MenuOpciones.SetActive(true);
    }

    public void MostrarMenuInicial()
    {
        MenuOpciones.SetActive(false);
        MenuInicial.SetActive(true);

    }

}