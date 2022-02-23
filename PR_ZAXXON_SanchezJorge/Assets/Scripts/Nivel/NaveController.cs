using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NaveController : MonoBehaviour
{
    public float velocidadHorizontal;
    public float velocidadVertical;
    public GameObject rotation;
    public ParticleSystem explosion;
    public int lifes = 3;

    private float barrelTime = 0;
    private bool barrelPressed = false;
    private bool rotateBarrel = false;
    private bool lastDirection = false;
    private bool zaWarudo = false;
    private int countBarrel = 0;
    private float boundsX = 50f;
    private float boundsY = 20f;
    private float rotateTime = 0f;
    private Quaternion rotationLimit = Quaternion.Euler(0f, 0f, 50f);
    private float rotationSettleSpeed = 2f;

    private void Start()
    {
        explosion.Stop();
        if (GameManager.selectedMaterial) rotation.GetComponent<Renderer>().material = GameManager.selectedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");
        bool bumpR = Input.GetButtonDown("BumpR");
        bool bumpL = Input.GetButtonDown("BumpL");

        Pause();

        if (!zaWarudo && SpawnerController.canSpawn)
        {
            // check button direction pressed
            if (bumpR && !bumpL)
                lastDirection = true;
            else if (!bumpR && bumpL)
                lastDirection = false;

            // do barrel in sight of last direction
            if (lastDirection)
                BarrelRoll(bumpR, -2f);
            else
                BarrelRoll(bumpL, 2f);

            // check bounds
            Bounds(movX, movY);

            // move right or left by movx - or +
            transform.Translate(Vector3.right * Time.deltaTime * velocidadHorizontal * movX);
            Rotate(movX);

            // same for up and down, - or +
            transform.Translate(Vector3.up * Time.deltaTime * velocidadVertical * movY);


            // do lerp to origin
            if ((movX < 0.01 && movX > -0.01) && !rotateBarrel)
            {
                if (rotation)
                    rotation.transform.rotation = Quaternion.Lerp(rotation.transform.rotation, Quaternion.identity, rotateTime * rotationSettleSpeed);
                rotateTime += Time.deltaTime;
            }
        }
    }

    void Rotate(float movX)
    {
        if (rotation && !rotateBarrel)
        {
            bool rotateCondition = false;

            // check for movement on x axis for limit condition
            if (movX > 0)
                rotateCondition = rotation.transform.rotation.z > -rotationLimit.z;
            else if (movX < 0)
                rotateCondition = rotation.transform.rotation.z < rotationLimit.z;
            if (rotateCondition)
            {
                rotation.transform.Rotate(Quaternion.Euler(0, 0, 360 * -movX * Time.deltaTime).eulerAngles);
                rotateTime = 0;
            }
        }
    }

    void Bounds(float movX, float movY)
    {
        Vector3 playerPos = transform.position;

        // removes speed if outside limits and movement onto that direction

        if (playerPos.x > boundsX && movX > 0)
            velocidadHorizontal = 0;
        else if (playerPos.x < -boundsX && movX < 0)
            velocidadHorizontal = 0;
        else
            velocidadHorizontal = 70;

        if (playerPos.y > boundsY && movY > 0)
            velocidadVertical = 0;
        else if (playerPos.y < boundsY - boundsY && movY < 0)
            velocidadVertical = 0;
        else
            velocidadVertical = 70;
    }
    float time;
    void BarrelRoll(bool inputPressed, float rotateValue)
    {
        // checks for input and not in time
        if (inputPressed && barrelTime <= 0)
        {
            barrelTime = 2f;
            barrelPressed = true;
            return;
        } 

        // if in time and done first input
        if (barrelPressed && barrelTime > 0)
        {
            // substract time for limit
            barrelTime -= Time.deltaTime;

            // if pressed again, rotate barrel
            if (inputPressed)
            {
                rotateBarrel = true;
            }
        } else
        { // not in time, resets
            barrelPressed = false;
            barrelTime = 0;
        }
        // if conditions for rotating are met
        if (rotateBarrel)
        {
            barrelTime = 0;
            barrelPressed = false;
            time += Mathf.Abs(rotateValue * 400 * Time.deltaTime);
            Debug.Log(time);
            // rotate 360 degrees
            if (time < 720)
            {
                // 2 degrees each time
                if (rotation)
                    rotation.transform.Rotate(Quaternion.Euler(0, 0, rotateValue * 400 * Time.deltaTime).eulerAngles);
            } else
            {
                // reset quaternion to origin
                time = 0;
                countBarrel = 0;
                rotateBarrel = false;
            }
        }
    }

    void Pause()
    {
        // pauses the game
        if (Input.GetButtonDown("Start"))
        {
            if (!zaWarudo)
            {
                Debug.Log("hola");
                Time.timeScale = 0;
                zaWarudo = true;
            }
            else
            {
                Time.timeScale = 1;
                zaWarudo = false;
            }
        }
    }

    public void Reload()
    {
        // stops obstacles, spawner, plays explosion and disables spaceship before reloading
        //ObstaculoController.velocidad = 0;
        SpawnerController.canSpawn = false;
        explosion.Play();
        rotation.GetComponent<MeshRenderer>().enabled = false;
        rotation.GetComponent<MeshCollider>().enabled = false;
        Invoke("Recarga", 2f);
    }

    void Recarga() {
        // resets speed, spawner and reloads
        ObstaculoController.velocidad = 50;
        SpawnerController.canSpawn = true;
        GameManager.level = 1;
        SocialCreditController.lastLevel = 1;
        SoundController.lastLevel = 1;
        SceneManager.LoadScene(3); 
    }
}
