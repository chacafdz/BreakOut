using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bola : MonoBehaviour
{
    bool isGameStarted = false;
    [SerializeField] public float velocidadBola = 10.0f;
    Rigidbody rigidbody;
    private ControlBordes control;
    public UnityEvent BolaDestruida;

    private void Awake()
    {
        control = GetComponent<ControlBordes>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
        Vector3 posicionInicial = GameObject.FindGameObjectWithTag("Jugador").transform.position;
        posicionInicial.y += 3;
        this.transform.position = posicionInicial;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Jugador").transform);
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (control.salioAbajo)
        {
            BolaDestruida.Invoke();
            Destroy(this.gameObject);
            return;
        }

        if (control.salioArriba)
        {
            Debug.Log("La bola toco el borde superior");
            Vector3 v = rigidbody.velocity;
            v.y = -Mathf.Abs(v.y == 0 ? velocidadBola : v.y);
            rigidbody.velocity = v.normalized * velocidadBola;

            control.salioArriba = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.2f);
        }

        if (control.salioDerecha)
        {
            Debug.Log("La bola toco el borde derecho");
            Vector3 v = rigidbody.velocity;
            v.x = -Mathf.Abs(v.x == 0 ? velocidadBola : v.x);
            rigidbody.velocity = v.normalized * velocidadBola;

            control.salioDerecha = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.2f);
        }

        if (control.salioIzquierda)
        {
            Debug.Log("La bola toco el borde izquierdo");
            Vector3 v = rigidbody.velocity;
            v.x = Mathf.Abs(v.x == 0 ? velocidadBola : v.x);
            rigidbody.velocity = v.normalized * velocidadBola;

            control.salioIzquierda = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.2f);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (!isGameStarted)
            {
                isGameStarted = true;
                this.transform.SetParent(null);
                rigidbody.velocity = velocidadBola * Vector3.up;
            }
        }
    }

    private void HabilitarControl()
    {
        control.enabled = true;
    }
}