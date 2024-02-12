using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jugador;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - jugador.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = jugador.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
