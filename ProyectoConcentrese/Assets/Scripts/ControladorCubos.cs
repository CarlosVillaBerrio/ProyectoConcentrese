using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCubos : MonoBehaviour
{

    void Update()
    {
        DeterminaParecido();
    }

    void DeterminaParecido()
    {
        GameObject cubo_1 = null;
        GameObject cubo_2 = null;
        foreach (var item in FindObjectsOfType<LogicaCubo>())
        {
            if(item.seleccionado == true && cubo_1 == null)
            {
                cubo_1 = item.esteCubo;
            }
            if(item.seleccionado == true && cubo_1 != item.esteCubo && cubo_2 == null)
            {
                cubo_2 = item.esteCubo;
            }

            if (cubo_1 != null && cubo_2 != null && cubo_1.transform.rotation.eulerAngles.y > -180f && cubo_2.transform.rotation.eulerAngles.y > -180f)
            {
                if (cubo_1 != null && cubo_2 != null && cubo_1.GetComponent<LogicaCubo>().material == cubo_2.GetComponent<LogicaCubo>().material)
                {
                    cubo_1.GetComponent<LogicaCubo>().correcto = true;
                    cubo_2.GetComponent<LogicaCubo>().correcto = true;
                    cubo_1.GetComponent<LogicaCubo>().seleccionado = false;
                    cubo_2.GetComponent<LogicaCubo>().seleccionado = false;
                }
            }
        }
        if (cubo_1 != null && cubo_2 != null && cubo_1.GetComponent<LogicaCubo>().correcto == false && cubo_2.GetComponent<LogicaCubo>().correcto == false)
        {
            cubo_1.GetComponent<LogicaCubo>().sePuedeOcultar = true;
            cubo_2.GetComponent<LogicaCubo>().sePuedeOcultar = true;
            cubo_1 = null;
            cubo_2 = null;
        }
    }
}
