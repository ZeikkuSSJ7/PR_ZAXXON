using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    public float velocidadHorizontal;
    public float velocidadVertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");

        Bounds();

        if (movX > 0)
            transform.Translate(Vector3.right * Time.deltaTime * velocidadHorizontal * movX);
        else if (movX < 0)
            transform.Translate(Vector3.left * Time.deltaTime * velocidadHorizontal * -movX);
        if (movY > 0)
            transform.Translate(Vector3.up * Time.deltaTime * velocidadHorizontal * movY);
        else if (movY < 0)
            transform.Translate(Vector3.down * Time.deltaTime * velocidadHorizontal * -movY);
    }

    void Bounds()
    {
        Vector3 playerPos = transform.position;
        if (playerPos.x > 20)
            transform.position = new Vector3(20f, playerPos.y, playerPos.z);
        else if (playerPos.x < -20)
            transform.position = new Vector3(-20f, playerPos.y, playerPos.z);

        if (playerPos.y > 20)
            transform.position = new Vector3(playerPos.x, 20f, playerPos.z);
        else if (playerPos.y < 0)
            transform.position = new Vector3(playerPos.x, 0, playerPos.z);
    }
}
