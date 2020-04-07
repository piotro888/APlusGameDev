
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuGłowne : MonoBehaviour
{
    public Canvas kan;

    public void graj()
    {
        kan.enabled = false;
    }

    public void grajponownie(){
        Application.LoadLevel("MainScene");
    }

    public void loadMain(){
        Application.LoadLevel("StartMenu");
    }

    public void wyjdz()
    {
        Application.Quit();
        Debug.Log("aplikacja się zamknęła ale w edytorze nie widać");
    }

    public void tworcy(){
        Application.LoadLevel("Authors");
    }

    public void menu(){
        Application.LoadLevel("StartMenu");
    }


}

