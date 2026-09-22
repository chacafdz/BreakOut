using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

/// <summary>
/// Representa un bloque destructible del juego tipo Breakout.
/// Controla su resistencia a los golpes de la bola y notifica
/// cuando debe sumarse puntaje al ser destruido.
/// </summary>
public class BLoque : MonoBehaviour
{
    /// <summary>
    /// Resistencia base configurada para este tipo de bloque, antes de
    /// aplicar el ajuste por dificultad. Representa la cantidad de golpes
    /// que el bloque puede recibir antes de ser destruido.
    /// </summary>
    [Tooltip("Resistencia base configurada para este tipo de bloque, antes de aplicar la dificultad.")]
    public int resistencia = 1;

    /// <summary>
    /// Asset de Opciones que define la dificultad actual del juego.
    /// Se utiliza para ajustar dinámicamente la resistencia del bloque
    /// según el nivel de dificultad seleccionado. Debe arrastrarse desde el Project.
    /// </summary>
    [Tooltip("Asset de Opciones que define la dificultad actual. Arrastralo desde el Project.")]
    public Opciones opciones;

    /// <summary>
    /// Evento que se invoca cuando el bloque es destruido, permitiendo
    /// que otros sistemas (como el administrador de puntaje) reaccionen
    /// y aumenten el puntaje del jugador.
    /// </summary>
    public UnityEvent AumentarPuntaje;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bola")
        {
            RebotarBola(collision);
        }
    }

    /// <summary>
    /// Rebota la bola que colisiona con este bloque, calculando la dirección
    /// de rebote en base al punto de contacto, y reduce la resistencia del
    /// bloque en 1 al recibir el golpe.
    /// </summary>
    /// <param name="collision">Información de la colisión generada por Unity, incluye el punto de contacto y el rigidbody de la bola.</param>
    public virtual void RebotarBola(Collision collision)
    {
        Vector3 direccion = collision.contacts[0].point - transform.position;
        direccion = direccion.normalized;
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().velocidadBola * direccion;
        resistencia--;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        // La dificultad ajusta la resistencia base: facil=0, normal=1, dificil=2 golpes extra.
        if (opciones != null)
        {
            resistencia += (int)opciones.NivelDificultad;
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (resistencia <= 0)
        {
            AumentarPuntaje.Invoke();
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Sobrecarga vacía de RebotarBola pensada para ser sobreescrita
    /// por clases hijas que necesiten un comportamiento de rebote
    /// sin depender de un objeto Collision.
    /// </summary>
    public virtual void RebotarBola()
    {
    }
}