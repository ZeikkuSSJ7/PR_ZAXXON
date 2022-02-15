using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    public static float velocidad = 50;
    public int vida;
    public GameObject particulasMuerte;
    private static float tiempoOffset = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * velocidad, Space.World); // moves obstacle forward as well as incrementing speed
        if (CompareTag("Obstaculo"))
            AumentarVelocidad();
    }

    void AumentarVelocidad()
    {
        tiempoOffset -= Time.deltaTime;
        if (tiempoOffset < 0)
        {
            velocidad += 2;
            tiempoOffset = 5; // ups speed every 5 seconds
        }
    }

    public void DecreaseLife()
    {
        // decreases obstacle life and destroys it if life == 0
        vida--;
        if (vida <= 0)
        {
            Instantiate(particulasMuerte, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
