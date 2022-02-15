using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenRotateController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Quaternion.Euler(0, 20 * Time.deltaTime, 0).eulerAngles, Space.World); // rotates spaceship on title screen
    }
}
