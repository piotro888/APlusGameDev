using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds_Settings : MonoBehaviour
{
    public AudioSource zawalenie;
    public AudioSource podnoszenie;
    public AudioSource chodzenie;
    public AudioSource blok;
    public AudioSource wybuch;
    public AudioSource drabina;
    private GameObject gm;
    private GameObject opt;
    private float vol;

    private void Start()
    {
        gm = GameObject.Find("Music");
        opt = GameObject.Find("Options");
        opt.GetComponent<Options>().volume_music=gm.GetComponent<VolumeValueChange>().musicVolume;
        opt.GetComponent<Options>().volume_sounds=gm.GetComponent<VolumeValueChange>().soundsVolume;
        vol=gm.GetComponent<VolumeValueChange>().soundsVolume;
        chodzenie.volume=(vol/4f);
        zawalenie.volume=(vol/2f);
        podnoszenie.volume=vol;
        blok.volume=vol;
        wybuch.volume=vol;
        drabina.volume=vol;
    }

};
