using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Opciones", menuName = "Herramientas/Opciones", order = 1)]
public class Opciones : PuntajePersistente
{
    public float velocidadbola = 30;

    public enum dificultad
    {
        facil,
        normal,
        dificil
    }

    public dificultad NivelDificultad;

    public void CambiarVelocidad(float nuevaVelocidad)
    {
        velocidadbola += nuevaVelocidad;
    }

    public void CambiarDificultad(int nuevaDificultad)
    {
        NivelDificultad = (dificultad)nuevaDificultad;
    }
}