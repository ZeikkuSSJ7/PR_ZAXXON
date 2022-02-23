using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public MeshRenderer playerMesh;
    public Text score, level;
    public Button salir;
    public NaveController playerScript;
    public Image[] lifeImages;
    public static int scoreValue;

    private void Start()
    {
        salir.onClick.AddListener(() => Application.Quit());
    }

    // Update is called once per frame
    void Update()
    {
        level.text = "Level: " + GameManager.level;
        if (playerMesh.enabled)
        {
            scoreValue = Mathf.RoundToInt(ObstaculoController.velocidad * Time.timeSinceLevelLoad);
            score.text = "Score: " + scoreValue;// update distance
        }
        if (playerScript.lifes < 3)
        {
            lifeImages[playerScript.lifes].enabled = false; // disable lifes
            int currentScore = PlayerPrefs.GetInt("valorPropio", scoreValue);
            if (scoreValue > currentScore)
                PlayerPrefs.SetInt("valorPropio", scoreValue);
        }
    }
}
