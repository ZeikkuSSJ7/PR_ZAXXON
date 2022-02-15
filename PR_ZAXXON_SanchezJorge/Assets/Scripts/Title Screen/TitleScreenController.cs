using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public Button iniciar, config, salir;
    // Start is called before the first frame update
    void Start()
    {
        // sets listeners
        iniciar.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
        config.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(2);
        });
        salir.onClick.AddListener(() =>
        {
            Application.Quit(0);
        });
    }
 }
