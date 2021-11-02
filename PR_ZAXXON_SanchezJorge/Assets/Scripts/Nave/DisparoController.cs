using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoController : MonoBehaviour
{
    public int velocidad = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
