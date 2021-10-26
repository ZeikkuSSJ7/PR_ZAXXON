using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolilloController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Quaternion.Euler(1, 1, 1).eulerAngles);
    }
}
