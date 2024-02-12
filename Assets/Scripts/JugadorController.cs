using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugadorController : MonoBehaviour
{
    private Rigidbody _rb;

    public float velocidad;

    private int contador;

    public Text textoganar, textocontador;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        contador = 0;
        textoganar.text = "";
        SetTextoContador();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float movimientoh = Input.GetAxis("Horizontal");
        float movimientov = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoh, 0.0f, movimientov);
        _rb.AddForce(movimiento * velocidad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collecionable"))
        {
            other.gameObject.SetActive(false);
            contador++;
            SetTextoContador();
        }
    }
    private void SetTextoContador()
    {
        textocontador.text = "Contador: " + contador.ToString();
        if (contador >= 12)
        {
            textoganar.text = "¡Ganaste!";
        }
    }

}
