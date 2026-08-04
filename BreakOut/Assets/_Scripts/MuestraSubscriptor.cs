using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MuestraSubscriptor : MonoBehaviour
{
    MuestraEventos subscriptor;
    // Start is called before the first frame update
    void Start()
    {
        subscriptor = GetComponent<MuestraEventos>();
        subscriptor.EnCasoDeEspacioPresionado += MensajeEscuchadoPorElSubscriptor;
    }
    private void MensajeEscuchadoPorElSubscriptor(object sender, EventArgs e)
    {
        Debug.Log("el evento ah sido escuchado desde otra clase ");
        subscriptor.EnCasoDeEspacioPresionado -= MensajeEscuchadoPorElSubscriptor;
    }
}
