using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject[] obstaculos;
    public static bool canSpawn = true;

    private float timeOffset = 0.5f;
    private float timeCurrent= 0f;

    // Update is called once per frame
    void Update()
    {
        if (timeOffset < timeCurrent)
        {
            CheckLevel();
            timeCurrent = 0;
            float chance = Random.Range(0f, 1f); // gets a chance in between 0 and 1
            int level = GameManager.level;
            GameObject objectToSpawn = obstaculos[0]; // spawns block by default
            if (level > 1 && chance >= 0.3 && chance < 0.5)
                objectToSpawn = obstaculos[1]; // spawns cross
            else if (level > 2 && chance >= 0.5 && chance < 0.7)
                objectToSpawn = obstaculos[2]; // spawns tunnel
            else if (level > 3 && chance >= 0.7 && chance < 0.9)
                objectToSpawn = obstaculos[3]; // spawns bolillo
            else if (level > 4 && chance >= 0.9 && chance < 1)
                objectToSpawn = obstaculos[4]; // spawns boulder

            if (chance > 0.95)
                objectToSpawn = obstaculos[5]; // spawns powerup independent of obstacle
            if (canSpawn)
                Instantiate(objectToSpawn, new Vector3(transform.position.x + Random.Range(-40, 40), transform.position.y + Random.Range(0, 20), transform.position.z), transform.rotation, transform);
        }
        timeCurrent += Time.deltaTime;
    }

    void CheckLevel()
    {
        // gets time since reload and sets level
        float time = Time.timeSinceLevelLoad;
        GameManager.level = Mathf.FloorToInt(time / 60) + 1;

    }
}
