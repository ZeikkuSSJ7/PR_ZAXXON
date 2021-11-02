using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.color = Color.Lerp(Color.blue, Color.red, Mathf.PingPong(Time.time, 1)); // lerp between colors
    }
}
