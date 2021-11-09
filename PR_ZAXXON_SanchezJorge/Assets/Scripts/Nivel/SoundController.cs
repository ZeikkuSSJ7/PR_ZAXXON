using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip[] music;
    private AudioSource player;
    public static int lastLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastLevel != GameManager.level)
        {
            player.Stop();
            player.clip = music[lastLevel];
            player.Play();
            lastLevel = GameManager.level;
        }
    }
}
