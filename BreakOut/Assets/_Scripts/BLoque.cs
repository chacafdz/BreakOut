using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class BLoque : MonoBehaviour
{
    [Tooltip("Resistencia base configurada para este tipo de bloque, antes de aplicar la dificultad.")]
    public int resistencia = 1;

    [Tooltip("Asset de Opciones que define la dificultad actual. Arrastralo desde el Project.")]
    public Opciones opciones;

    public UnityEvent AumentarPuntaje;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bola")
        {
            RebotarBola(collision);
        }
    }

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

    public virtual void RebotarBola()
    {
    }
}