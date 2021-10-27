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
            NaveController playerScript = parent.GetComponent<NaveController>();
            playerScript.lifes--;
            if (playerScript.lifes == 0)
                parent.GetComponent<NaveController>().Reload();
        }

        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            StartCoroutine(disparador.PowerUp());
        }
    }
}
