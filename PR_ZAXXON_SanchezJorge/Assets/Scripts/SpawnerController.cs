using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject[] obstaculos;
    public static bool canSpawn = true;
    private float timeOffset = 0.5f;
    private float timeCurrent= 0f;
    private int level;
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
            GameObject objectToSpawn = obstaculos[0];
            if (level > 1 && chance >= 0.3 && chance < 0.5)
                objectToSpawn = obstaculos[1];
            else if (level > 2 && chance >= 0.5 && chance < 0.7)
                objectToSpawn = obstaculos[2];
            else if (level > 3 && chance >= 0.7 && chance < 0.9)
                objectToSpawn = obstaculos[3];
            else if (level > 4 && chance >= 0.9 && chance < 1)
                objectToSpawn = obstaculos[4];
            if (canSpawn)
                Instantiate(objectToSpawn, new Vector3(transform.position.x + Random.Range(-40, 40), transform.position.y + Random.Range(0, 20), transform.position.z), transform.rotation, transform);
        }
        timeCurrent += Time.deltaTime;
        CheckLevel();
    }

    void CheckLevel()
    {
        if (Time.time < 20)
            level = 1;
        else if (Time.time < 40)
            level = 2;
        else if (Time.time < 60)
            level = 3;
        else if (Time.time < 80)
            level = 4;
        else if (Time.time < 100)
            level = 5;
    }
}
