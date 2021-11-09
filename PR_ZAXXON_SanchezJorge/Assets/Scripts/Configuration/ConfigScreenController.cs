using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfigScreenController : MonoBehaviour
{
    public Text nombreMaterial;
    public Slider volumeBGM, volumeSFX;
    public Button btnIzq, btnDer, btnVolver;
    public Material[] materials;
    public AudioMixer mixer;
    public GameObject nave;

    private int selectedMaterial = 0;
    // Start is called before the first frame update
    void Start()
    {
        volumeBGM.onValueChanged.AddListener(delegate { SetSound("BGMVolume", volumeBGM.value); });
        volumeSFX.onValueChanged.AddListener(delegate { SetSound("SFXVolume", volumeSFX.value); });
        btnIzq.onClick.AddListener(delegate { SetMaterial(-1); });
        btnDer.onClick.AddListener(delegate { SetMaterial(1); });
        btnVolver.onClick.AddListener(delegate { SceneManager.LoadScene(0); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSound(string param, float soundLevel)
    {
        mixer.SetFloat(param, soundLevel);
    }

    public void SetMaterial(int direction)
    {
        this.selectedMaterial += direction;
        if (selectedMaterial == -1)
        {
            selectedMaterial = 5;
        }
        if (selectedMaterial == 6)
        {
            selectedMaterial = 0;
        }
        nombreMaterial.text = materials[selectedMaterial].name;
        nave.GetComponent<Renderer>().material = materials[selectedMaterial];
        GameManager.selectedMaterial = materials[selectedMaterial];
    }
}
