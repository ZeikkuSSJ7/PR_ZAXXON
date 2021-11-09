using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoresController : MonoBehaviour
{
    public Text[] textos;
    public Button btnVolver;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("saved"))
        {
            PlayerPrefs.SetInt("primeroValor", 100000);
            PlayerPrefs.SetInt("segundoValor", 80000);
            PlayerPrefs.SetInt("terceroValor", 50000);
            PlayerPrefs.SetInt("cuartoValor", 40000);
            PlayerPrefs.SetInt("quintoValor", 30000);
            PlayerPrefs.SetInt("sextoValor", 20000);
            PlayerPrefs.SetString("primero", "ZPH");
            PlayerPrefs.SetString("segundo", "AHG");
            PlayerPrefs.SetString("tercero", "MRG");
            PlayerPrefs.SetString("cuarto", "AAH");
            PlayerPrefs.SetString("quinto", "GMC");
            PlayerPrefs.SetString("sexto", "AAA");
            PlayerPrefs.SetString("saved", "yes");
        }

        textos[0].text = "1º " + PlayerPrefs.GetString("primero") + " " + PlayerPrefs.GetInt("primeroValor");
        textos[1].text = "2º " + PlayerPrefs.GetString("segundo") + " " + PlayerPrefs.GetInt("segundoValor");
        textos[2].text = "3º " + PlayerPrefs.GetString("tercero") + " " + PlayerPrefs.GetInt("terceroValor");
        textos[3].text = "4º " + PlayerPrefs.GetString("cuarto") + " " + PlayerPrefs.GetInt("cuartoValor");
        textos[4].text = "5º " + PlayerPrefs.GetString("quinto") + " " + PlayerPrefs.GetInt("quintoValor");
        textos[5].text = "6º " + PlayerPrefs.GetString("sexto") + " " + PlayerPrefs.GetInt("sextoValor");
        textos[6].text = "Tu: " + PlayerPrefs.GetInt("valorPropio");
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
