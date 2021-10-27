using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    public static float velocidad = 50;
    public int vida;
    private static float tiempoOffset = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * velocidad, Space.World);
        AumentarVelocidad();
    }

    void AumentarVelocidad()
    {
        tiempoOffset -= Time.deltaTime;
        if (tiempoOffset < 0)
        {
            velocidad += 5;
            tiempoOffset = 5;
        }
    }

    public void DecreaseLife()
    {
        vida--;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
