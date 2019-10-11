using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaCubo : MonoBehaviour
{
    public bool sePuedeVoltear;
    public bool sePuedeOcultar;
    public Material material;
    public bool seleccionado;
    public bool correcto;
    public GameObject esteCubo;
    public int contador = 0;

    void Awake()
    {
        //material = gameObject.GetComponentInChildren<Renderer>().material;
        esteCubo = this.gameObject;
    }

    void Update()
    {
        MostrarCubo();
        OcultarCubo();
    }

    private void OnMouseDown() // Selecciona y comprueba si se puede girar
    {
        if (gameObject.transform.rotation.eulerAngles.y >= 0 && gameObject.transform.rotation.eulerAngles.y < 180)
        {
            sePuedeVoltear = true;
        }
    }

    void MostrarCubo()
    {
        if (sePuedeVoltear) // Se muestra
        {
            gameObject.GetComponent<Transform>().Rotate(0f, 180f * Time.deltaTime * 0.9f, 0f);
            seleccionado = true;
        }
        if (gameObject.transform.rotation.eulerAngles.y >= 180f)
        {
            sePuedeVoltear = false;
        }
    }

    void OcultarCubo()
    {
        if (sePuedeOcultar && !correcto) // Se muestra
        {
            gameObject.transform.rotation = Quaternion.Euler(0f,0f,0f);
            seleccionado = false;
            sePuedeOcultar = false;
        }
    }
}
