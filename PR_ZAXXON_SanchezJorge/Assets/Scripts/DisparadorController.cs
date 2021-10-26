using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorController : MonoBehaviour
{
    public GameObject disparo;

    private float currentTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime < 0)
            if (Input.GetButton("Fire1"))
            {
                Destroy(Instantiate(disparo, transform.position, transform.rotation), 3f);
                currentTime = 0.2f;
            }
        currentTime -= Time.deltaTime;
    }
}
