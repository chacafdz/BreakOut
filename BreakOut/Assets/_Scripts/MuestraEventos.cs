using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuestraEventos : MonoBehaviour {

    public event EventHandler EnCasoDeEspacioPresionado;

    // Start is called before the first frame update
    void Start()
    {
        EnCasoDeEspacioPresionado += EventoEscuchado;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnCasoDeEspacioPresionado?.Invoke(this, EventArgs.Empty);
        }
    }

    public void EventoEscuchado(object sender, EventArgs e)
    {
        Debug.Log("el evento se escucho correctamente");
    }
}