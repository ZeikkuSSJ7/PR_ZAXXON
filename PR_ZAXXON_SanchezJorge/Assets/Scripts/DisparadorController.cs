using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorController : MonoBehaviour
{
    public GameObject disparo;

    private float waitTime = 0.2f;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime < 0)
        {
            if (Input.GetButton("Fire1"))
            {
                Destroy(Instantiate(disparo, transform.position, transform.rotation), 3f);
                currentTime = waitTime;
            }
        }
        else 
            currentTime -= Time.deltaTime;
    }

    public IEnumerator PowerUp()
    {
        waitTime = 0.05f;
        yield return new WaitForSeconds(10f);
        waitTime = 0.2f;

    }
}
