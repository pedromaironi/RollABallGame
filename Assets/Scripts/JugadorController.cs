using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JugadorController : MonoBehaviour
{
    private Rigidbody rb;

    public float velocidad;

    private int contador;

    public Text textoganar, textocontador, textoTemporizador, textoNivel;
    private float temporizador = 60f; // tiempo en segundos;

    private bool juegoPausado = false;

    //public GestorDeNiveles gestorDeNiveles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        textoganar.text = "";
        SetTextoContador();
    }

    // Update is called once per frame
    void Update()
    {
        int siguienteNivel = SceneManager.GetActiveScene().buildIndex;
        textoNivel.text = "Nivel " + siguienteNivel;
        if (textoTemporizador != null)
        {
            if (temporizador > 0f)
            {
                temporizador -= Time.deltaTime;
                textoTemporizador.text = "Tiempo: " + Mathf.Round(temporizador).ToString();
            }
            else
            {
                PerderJuego();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            juegoPausado = !juegoPausado;
            Time.timeScale = juegoPausado ? 0 : 1;
        }
    }

    void PerderJuego()
    {
        textoganar.text = "¡Perdiste!";
        PausarJuego();
    }

    private void PausarJuego()
    {
        juegoPausado = true;
        Time.timeScale = 0; 
    }

    private void ReanudarJuego()
    {
        juegoPausado = false;
        Time.timeScale = 1; 
    }

private void FixedUpdate()
    {
        float movimientoh = Input.GetAxis("Horizontal");
        float movimientov = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoh, 0.0f, movimientov);
        rb.AddForce(movimiento * velocidad);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("collecionable"))
        {
            other.gameObject.SetActive(false);
            contador++;
            SetTextoContador();

            if (contador >= 12)
            {
                //gestorDeNiveles.CargarSiguienteNivel();
                CargarSiguienteNivel();


            }
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

    public void CargarSiguienteNivel()
    {
        int siguienteNivel = SceneManager.GetActiveScene().buildIndex + 1;
        if (siguienteNivel > SceneManager.GetActiveScene().buildIndex)
        {
            if (siguienteNivel < 5)
            {
                SceneManager.LoadScene(siguienteNivel);

            } else
            {
                textoganar.text = "¡Terminaste el juego!";
                SceneManager.LoadScene(0);
            }
        }
    }

}
