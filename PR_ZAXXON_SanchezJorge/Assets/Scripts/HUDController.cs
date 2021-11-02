using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public MeshRenderer playerMesh;
    public Text score;
    public NaveController playerScript;
    public Image[] lifeImages;

    // Update is called once per frame
    void Update()
    {
        if (playerMesh.enabled)
            score.text = "Score: " + Mathf.Round(ObstaculoController.velocidad * Time.timeSinceLevelLoad); // update distance
        if (playerScript.lifes < 3) 
            lifeImages[playerScript.lifes].enabled = false; // disable lifes
    }
}
