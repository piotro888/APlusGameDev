using UnityEngine;
using UnityEngine.UI;

public class VolumeValueChange : MonoBehaviour {
    private AudioSource audioSrc;
    public float musicVolume = 1f;
    public float soundsVolume = 1f;
    private GameObject opt;
    public Slider sl_sounds;
    public Slider sl_music;


    private void Awake()
{
  DontDestroyOnLoad(gameObject);
}

	void Start () {
        audioSrc = GetComponent<AudioSource>();
        opt=GameObject.Find("Options");
        musicVolume=opt.GetComponent<Options>().volume_music; 
        soundsVolume=opt.GetComponent<Options>().volume_sounds;
        sl_sounds.value=soundsVolume;
        sl_music.value=musicVolume; 
        }
	

	void Update () {

        audioSrc.volume = musicVolume;
	}

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
    public void SetVolumeSounds(float sou)
    {
        soundsVolume = sou;
    }
}
