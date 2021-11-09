using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorController : MonoBehaviour
{
    public GameObject disparo;
    public Camera camera;

    private float waitTime = 0.15f;
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
                Destroy(Instantiate(disparo, transform.position, transform.rotation), 2f);
                currentTime = waitTime;
            }
        }
        else 
            currentTime -= Time.deltaTime;
    }

    public IEnumerator PowerUp()
    {
        waitTime = 0.05f; // reduce shoot wait time
        yield return FOV(100); // puts fov to 100
        yield return new WaitForSeconds(10f); // waits
        yield return FOV(60); // returns fov
        waitTime = 0.2f; // returns shoot time

    }

    IEnumerator FOV(int fov)
    {
        int add = -1; // depending of returning or not, check if adding or substracting
        if (fov > 60) add = 1;
        while (camera.fieldOfView != fov)
        {
            camera.fieldOfView += add; 
            yield return new WaitForSeconds(0.05f);
        }
    }
}
