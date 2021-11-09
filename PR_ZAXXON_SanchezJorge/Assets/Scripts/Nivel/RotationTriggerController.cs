using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationTriggerController : MonoBehaviour
{
    public GameObject parent;
    public DisparadorController disparador;
    public AudioSource powerUp;
    private void OnTriggerEnter(Collider other)
    {
        // checks collision with obstacle and reduces life, kills if 0 life
        if (other.CompareTag("Obstaculo"))
        {
            NaveController playerScript = parent.GetComponent<NaveController>();
            playerScript.lifes--;
            Destroy(other.gameObject);
            if (playerScript.lifes == 0)
                parent.GetComponent<NaveController>().Reload();
        }

        // activates powerup with collision
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            GetComponent<AudioSource>().Play();
            StartCoroutine(disparador.PowerUp());
        }
    }
}
