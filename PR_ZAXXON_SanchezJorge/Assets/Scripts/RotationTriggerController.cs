using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationTriggerController : MonoBehaviour
{
    public GameObject parent;
    public DisparadorController disparador;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            parent.GetComponent<NaveController>().Reload();
        }

        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            StartCoroutine(disparador.PowerUp());
        }
    }
}
