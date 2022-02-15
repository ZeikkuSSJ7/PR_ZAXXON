using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoresController : MonoBehaviour
{
    public Text[] textos;
    private int[] valores = new int[7];
    private string[] nombres = new string[7];
    private string[] textosConstruidos = new string[7];
    public Button btnVolver;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("saved"))
        {
            PlayerPrefs.SetInt("0Valor", 100000);
            PlayerPrefs.SetInt("1Valor", 80000);
            PlayerPrefs.SetInt("2Valor", 50000);
            PlayerPrefs.SetInt("3Valor", 40000);
            PlayerPrefs.SetInt("4Valor", 30000);
            PlayerPrefs.SetInt("5Valor", 20000);
            PlayerPrefs.SetString("0", "ZPH");
            PlayerPrefs.SetString("1", "AHG");
            PlayerPrefs.SetString("2", "MRG");
            PlayerPrefs.SetString("3", "AAH");
            PlayerPrefs.SetString("4", "GMC");
            PlayerPrefs.SetString("5", "AAA");
            PlayerPrefs.SetString("saved", "yes");
        }
        for (int i = 0; i < valores.Length; i++)
        {
            valores[i] = PlayerPrefs.GetInt(i + "Valor");
            nombres[i] = PlayerPrefs.GetString(i.ToString());
        }
        valores[6] = PlayerPrefs.GetInt("valorPropio");
        nombres[6] = PlayerPrefs.GetString("propio");

        for (int i = 0; i < textosConstruidos.Length; i++)
        {
            textosConstruidos[i] = nombres[i] + " " + valores[i];
            textos[i].text = i + 1 + "º " + textosConstruidos[i];
        }

        textos[6].text = "Tu: ZXX " + PlayerPrefs.GetInt("valorPropio");
        btnVolver.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
