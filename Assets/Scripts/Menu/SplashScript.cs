using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScript : MonoBehaviour
{
    Stopwatch stopwatch = new Stopwatch();
    void Start(){
        stopwatch.Start();
    }

    void Update(){
        if(stopwatch.ElapsedMilliseconds > 4000){
            stopwatch.Stop();
            Application.LoadLevelAsync("StartMenu");
        }
    }
}
