using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] public int limiteX = 23;
    [SerializeField] public float VelocidadPaddle = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }
    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bola")
        {
            Vector3 direccion = collision.contacts[0].point - transform.position;
            direccion = direccion.normalized;
            collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().velocidadBola * direccion;
        }
    }
    // Update is called once per frame
    void Update()
    {
        float movimiento = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * movimiento * VelocidadPaddle * Time.deltaTime, Space.World);

        // Limitar el movimiento dentro del rango permitido
        Vector3 pos = transform.position;
        if (pos.x < -limiteX)
        {
            pos.x = -limiteX;
        }
        else if (pos.x > limiteX)
        {
            pos.x = limiteX;
        }
        transform.position = pos;
    }
}