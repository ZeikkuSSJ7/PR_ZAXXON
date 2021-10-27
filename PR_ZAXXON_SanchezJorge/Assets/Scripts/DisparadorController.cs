using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorController : MonoBehaviour
{
    public GameObject disparo;
    public Camera camera;

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
                Destroy(Instantiate(disparo, transform.position, transform.rotation), 1f);
                currentTime = waitTime;
            }
        }
        else 
            currentTime -= Time.deltaTime;
    }

    public IEnumerator PowerUp()
    {
        waitTime = 0.05f;
        yield return FOV(100);
        yield return new WaitForSeconds(10f);
        yield return FOV(60);
        waitTime = 0.2f;

    }

    IEnumerator FOV(int fov)
    {
        int add = -1;
        if (fov > 60) add = 1;
        while (camera.fieldOfView != fov)
        {
            camera.fieldOfView += add; 
            yield return new WaitForSeconds(0.05f);
        }
    }
}
