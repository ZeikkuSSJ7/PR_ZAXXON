using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject obstaculo;
    private float timeOffset = 0.15f;
    private float timeCurrent= 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeOffset < timeCurrent)
        {
            timeCurrent = 0;
            Destroy(Instantiate(obstaculo, new Vector3(transform.position.x + Random.Range(-40, 40), transform.position.y + Random.Range(0, 20), transform.position.z), transform.rotation, transform), 2f);
        }
        timeCurrent += Time.deltaTime;
    }
}
