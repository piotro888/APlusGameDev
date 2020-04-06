using UnityEngine;

public class MenuGłowne : MonoBehaviour
{
    public Canvas kan;

    public void graj()
    {
        kan.enabled = false;
    }

    public void grajponownie(){
        //Time.timeScale=1;
        Application.LoadLevel("MainScene");
    }

    public void wyjdz()
    {
        Application.Quit();
        Debug.Log("aplikacja się zamknęła ale w edytorze nie widać");
    }


}

