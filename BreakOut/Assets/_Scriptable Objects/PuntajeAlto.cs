using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PuntajeAlto", menuName = "Herramientas/Puntaje Alto", order = 2)]
public class PuntajeAlto : PuntajePersistente
{
    // Puntaje de la partida actual, se resetea a 0 al iniciar el nivel.
    public int puntaje = 0;

    // Record persistido, se guarda en disco cuando el puntaje actual lo supera.
    public int puntajeAlto = 0;
}

