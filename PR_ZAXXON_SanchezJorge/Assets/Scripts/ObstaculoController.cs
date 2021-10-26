using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    public static float velocidad = 50;
    public int vida;
    private static float tiempo = 0.01f;
    private float tiempoOffset = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AumentarVelocidad());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * velocidad * tiempo, Space.World);
    }

    IEnumerator AumentarVelocidad()
    {
        tiempo += tiempoOffset;
        yield return new WaitForSeconds(10f);
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
