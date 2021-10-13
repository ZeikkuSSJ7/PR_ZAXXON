using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    public float velocidad;
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
        transform.Translate(Vector3.back * Time.deltaTime * velocidad * tiempo);
    }

    IEnumerator AumentarVelocidad()
    {
        tiempo += tiempoOffset;
        yield return new WaitForSeconds(10f);
    }
}
