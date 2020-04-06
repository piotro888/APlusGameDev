using System;
using TMPro;
using System.Diagnostics;
using UnityEngine;

public class TimerControl : MonoBehaviour
{
    public TMPro.TextMeshProUGUI timerText;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI fpsText;
    public GameObject buildingGen;
    public int endTime = 180;
    Stopwatch stopwatch = new Stopwatch();

    void Start() {
        stopwatch.Start();
    }

    void Update() {
        int elapsedSeconds = (int) Mathf.Floor(stopwatch.ElapsedMilliseconds / 1000f);
        fpsText.text = Mathf.Ceil(1.0f / Time.smoothDeltaTime) + " FPS";
        string secstring = String.Format("{0:00}", (endTime - elapsedSeconds)%60);
        timerText.text = (endTime - elapsedSeconds)/60 + ":" + secstring;
        scoreText.text = ""+calcScore();
    }

    int calcScore(){
        int elapsedSeconds = (int) Mathf.Floor(stopwatch.ElapsedMilliseconds / 1000f);
        int timepart = elapsedSeconds*10;
        int floorpart = buildingGen.GetComponent<BuildingRenderrer>().buildingHeight * 100;
        return timepart + floorpart;
    }
}
