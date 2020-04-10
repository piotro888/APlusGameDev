
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MenuGłowne : MonoBehaviour
{
    public Canvas kan;
    private GameObject gm;
    private GameObject opt;
    public bool off=true;
    public Button[] levele;
    public Toggle fullscreen_toggle;
    public Button image_button;
    public Sprite[] sprites; 

    void Start(){
        gm = GameObject.Find("Music");
        opt = GameObject.Find("Options");
        fullscreen_toggle.isOn=opt.GetComponent<Options>().fullscreen;
        levele[opt.GetComponent<Options>().levels].GetComponent<Image>().color = Color.red;
        for(int i=1;i<=4;i++) if(i!=opt.GetComponent<Options>().levels){
            levele[i].GetComponent<Image>().color = Color.white;
        }

    }

    public void graj()
    {
        if(opt.GetComponent<Options>().first==true) {
            Application.LoadLevel("Instructions");
            opt.GetComponent<Options>().first=false;
        }
        else grajponownie();
    }

    public void grajponownie(){
        Application.LoadLevel("MainScene");
    }

    public void wyjdz()
    {
        Application.Quit();
        Debug.Log("aplikacja się zamknęła ale w edytorze nie widać");
    }

    public void menu(){
        opt.GetComponent<Options>().volume_music=gm.GetComponent<VolumeValueChange>().musicVolume;
        opt.GetComponent<Options>().volume_sounds=gm.GetComponent<VolumeValueChange>().soundsVolume;
        Application.LoadLevel("StartMenu");
        Destroy(gm);
    }

    public void musicoff(){
        if(off==true){
        EventSystem.current.SetSelectedGameObject(null);
        gm.GetComponent<VolumeValueChange>().musicVolume=0f;
        gm.GetComponent<VolumeValueChange>().soundsVolume=0f;
        this.GetComponent<Sounds_Settings>().SetSounds();
        image_button.image.sprite=sprites[1];
        off=false;
        }
        else{
            EventSystem.current.SetSelectedGameObject(null);
           gm.GetComponent<VolumeValueChange>().musicVolume=opt.GetComponent<Options>().volume_music;
        gm.GetComponent<VolumeValueChange>().soundsVolume=opt.GetComponent<Options>().volume_sounds;
        this.GetComponent<Sounds_Settings>().SetSounds();
        image_button.image.sprite=sprites[0]; 
        off=true;
        }

    }
    public void level(int nr){
        levele[nr].GetComponent<Image>().color = Color.red;
        for(int i=1;i<=4;i++) if(i!=nr){
            levele[i].GetComponent<Image>().color = Color.white;
        }
        opt.GetComponent<Options>().levels=nr;
        
    }

    public void FullScreen_Change(){
        opt.GetComponent<Options>().fullscreen=fullscreen_toggle.isOn;
        Screen.fullScreen = !Screen.fullScreen;
    }


}

