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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMesh.enabled)
        {
            score.text = "Score: " + Mathf.Round(ObstaculoController.velocidad * Time.timeSinceLevelLoad);
            switch (playerScript.lifes)
            {
                case 2:
                    lifeImages[2].enabled = false;
                    break;
                case 1:
                    lifeImages[1].enabled = false;
                    break;
            }
        }
        else
            lifeImages[0].enabled = false;
    }
}
