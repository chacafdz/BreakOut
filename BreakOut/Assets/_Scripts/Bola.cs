using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bola : MonoBehaviour
{
    bool isGameStarted = false;
    [SerializeField] public float velocidadBola = 10.0f;

    [Tooltip("Asset de Opciones que define la velocidad base y la dificultad actual. Arrastralo desde el Project.")]
    public Opciones opciones;

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

        
        if (opciones != null)
        {
            velocidadBola = opciones.velocidadbola + (int)opciones.NivelDificultad * 2f;
        }

        Vector3 posicionInicial = GameObject.FindGameObjectWithTag("Jugador").transform.position;
        posicionInicial.y += 3;
        this.transform.position = posicionInicial;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Jugador").transform);
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
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

                // Empuja la bola un poco hacia adentro para que no se re-dispare
                // el mismo borde el siguiente frame, sin desactivar el resto de los chequeos.
                Vector3 pos = transform.position;
                pos.y -= control.radio * 0.5f;
                transform.position = pos;

                control.salioArriba = false;
            }

            if (control.salioDerecha)
            {
                Debug.Log("La bola toco el borde derecho");
                Vector3 v = rigidbody.velocity;
                v.x = -Mathf.Abs(v.x == 0 ? velocidadBola : v.x);
                rigidbody.velocity = v.normalized * velocidadBola;

                Vector3 pos = transform.position;
                pos.x -= control.radio * 0.5f;
                transform.position = pos;

                control.salioDerecha = false;
            }

            if (control.salioIzquierda)
            {
                Debug.Log("La bola toco el borde izquierdo");
                Vector3 v = rigidbody.velocity;
                v.x = Mathf.Abs(v.x == 0 ? velocidadBola : v.x);
                rigidbody.velocity = v.normalized * velocidadBola;

                Vector3 pos = transform.position;
                pos.x += control.radio * 0.5f;
                transform.position = pos;

                control.salioIzquierda = false;
            }
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
}