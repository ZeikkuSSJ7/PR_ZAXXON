using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreController : MonoBehaviour
{
    private float time = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
            transform.Rotate(Quaternion.Euler(-0.1f, 0, 0.1f).eulerAngles);
        time -= Time.deltaTime;
    }
}
