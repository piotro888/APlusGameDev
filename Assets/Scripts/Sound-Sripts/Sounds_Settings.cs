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

    private void Start(){
        gm = GameObject.Find("Music");
        opt = GameObject.Find("Options");
        if(gm.GetComponent<VolumeValueChange>().musicVolume!=0f && gm.GetComponent<VolumeValueChange>().soundsVolume!=0f){
        opt.GetComponent<Options>().volume_music=gm.GetComponent<VolumeValueChange>().musicVolume;
        opt.GetComponent<Options>().volume_sounds=gm.GetComponent<VolumeValueChange>().soundsVolume;}
        else{
            this.GetComponent<MenuGłowne>().image_button.image.sprite=this.GetComponent<MenuGłowne>().sprites[1];
            this.GetComponent<MenuGłowne>().off=false;
        }
        SetSounds();
    }

    public void SetSounds()
    {
        //gm.GetComponent<VolumeValueChange>().musicVolume=opt.GetComponent<Options>().volume_music;
        //gm.GetComponent<VolumeValueChange>().soundsVolume=opt.GetComponent<Options>().volume_sounds;
        vol=gm.GetComponent<VolumeValueChange>().soundsVolume;
        chodzenie.volume=(vol/4f);
        zawalenie.volume=(vol/2f);
        podnoszenie.volume=vol;
        blok.volume=vol;
        wybuch.volume=vol;
        drabina.volume=vol;
    }

};
