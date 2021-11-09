using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoController : MonoBehaviour
{
    public int velocidad = 100;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * velocidad); // moves shot forward
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstaculo"))
        {
            other.gameObject.GetComponent<ObstaculoController>().DecreaseLife(); // reduces life of obstacle and disappears
            Destroy(gameObject);
        }
    }
}
