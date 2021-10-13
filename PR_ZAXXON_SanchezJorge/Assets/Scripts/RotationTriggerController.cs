using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationTriggerController : MonoBehaviour
{
    public GameObject parent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            parent.GetComponent<NaveController>().Reload();
        }
    }
}
