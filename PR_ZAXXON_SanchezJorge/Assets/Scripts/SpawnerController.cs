using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject[] obstaculos;
    public static bool canSpawn = true;
    private float timeOffset = 0.5f;
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
            float chance = Random.Range(0f, 1f);
            GameObject objectToSpawn = null;
            if (chance < 0.3)
                objectToSpawn = obstaculos[0];
            if (chance < 0.5 && chance >= 0.3)
                objectToSpawn = obstaculos[1];
            if (chance < 0.7 && chance >= 0.5)
                objectToSpawn = obstaculos[2];
            if (chance < 0.9 && chance >= 0.7)
                objectToSpawn = obstaculos[3];
            if (chance < 1 && chance >= 0.9)
                objectToSpawn = obstaculos[4];
            if (canSpawn)
                Instantiate(objectToSpawn, new Vector3(transform.position.x + Random.Range(-40, 40), transform.position.y + Random.Range(0, 20), transform.position.z), transform.rotation, transform);
        }
        timeCurrent += Time.deltaTime;
    }
}
