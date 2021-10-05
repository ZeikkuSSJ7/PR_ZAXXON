using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NaveController : MonoBehaviour
{
    public float velocidadHorizontal;
    public float velocidadVertical;
    public GameObject rotation;

    public float barrelTime = 0;
    public bool barrelPressed = false;
    public bool rotateBarrel = false;
    public int countBarrel = 0;
    private float boundsX = 50f;
    private float boundsY = 20f;
    private float rotateTime = 0f;
    private Quaternion rotationLimit = Quaternion.Euler(0f, 0f, 30f);

    // Update is called once per frame
    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");
        bool bumpR = Input.GetButtonDown("BumpR");
        bool bumpL = Input.GetButtonDown("BumpL");

        Bounds(movX, movY);
        BarrelRoll(bumpR, -2f);
        if (!bumpR && !rotateBarrel)
            BarrelRoll(bumpL, -2f);

        transform.Translate(Vector3.right * Time.deltaTime * velocidadHorizontal * movX);
        Rotate(movX);

        transform.Translate(Vector3.up * Time.deltaTime * velocidadVertical * movY);

        if (!Input.GetButton("Horizontal") && !rotateBarrel)
        {
            if (rotation) 
                rotation.transform.rotation = Quaternion.Lerp(rotation.transform.rotation, Quaternion.identity, rotateTime);
            rotateTime += Time.deltaTime;
        }
    }

    void Rotate(float movX)
    {
        if (rotation && !rotateBarrel)
        {
            bool rotateCondition = false;
            if (movX > 0)
                rotateCondition = rotation.transform.rotation.z > -rotationLimit.z;
            else if (movX < 0)
                rotateCondition = rotation.transform.rotation.z < rotationLimit.z;
            if (rotateCondition)
            {
                rotation.transform.Rotate(0f, 0f, 2f * -movX);
                rotateTime = 0;
            }
        }
    }

    void Bounds(float movX, float movY)
    {
        Vector3 playerPos = transform.position;

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

    void BarrelRoll(bool inputPressed, float rotateValue)
    {
        if (inputPressed && barrelTime <= 0)
        {
            barrelTime = 2f;
            barrelPressed = true;
            return;
        } 
        if (barrelPressed && barrelTime > 0)
        {
            barrelTime -= Time.deltaTime;
            if (inputPressed)
            {
                rotateBarrel = true;
            }
        } else
        {
            barrelPressed = false;
            barrelTime = 0;
        }
        
        if (rotateBarrel)
        {
            barrelTime = 0;
            barrelPressed = false;
            if (countBarrel < 180)
            {
                rotation.transform.Rotate(0f, 0f, rotateValue);
                countBarrel++;
            } else
            {
                rotation.transform.rotation = Quaternion.identity;
                countBarrel = 0;
                rotateBarrel = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            Destroy(rotation);
            Invoke("Reload", 2f);
        }
    }

    void Reload()
    {
        SceneManager.LoadScene("Nivel 1");
    }
}
