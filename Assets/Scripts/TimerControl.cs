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
    public TMPro.TextMeshProUGUI end_Text;
    public TMPro.TextMeshProUGUI score_Text;
    public int endTime = 180;
    Stopwatch stopwatch = new Stopwatch();
    public Canvas EndGame;
    
    void Start() {
        stopwatch.Start();
        EndGame.enabled=false;
    }

    void Update() {
        int elapsedSeconds = (int) Mathf.Floor(stopwatch.ElapsedMilliseconds / 1000f);
        fpsText.text = Mathf.Ceil(1.0f / Time.smoothDeltaTime) + " FPS";
        string secstring = String.Format("{0:00}", (endTime - elapsedSeconds)%60);
        timerText.text = (endTime - elapsedSeconds)/60 + ":" + secstring;
        //if((endTime - elapsedSeconds)<=0) EndMenu(true);
        if( buildingGen.GetComponent<BuildingRenderrer>().buildingHeight==0) EndMenu(false);
        scoreText.text = ""+calcScore();
    }

    int calcScore(){
        int elapsedSeconds = (int) Mathf.Floor(stopwatch.ElapsedMilliseconds / 1000f);
        int timepart = elapsedSeconds*10;
        int floorpart = buildingGen.GetComponent<BuildingRenderrer>().buildingHeight * 100;
        return timepart + floorpart;
    }

    public void EndMenu(bool win){
        stopwatch.Stop();
        //buildingGen.enabled = false;
        //Time.timeScale=0;
        if(win==true) end_Text.text= "You Won!";
        else end_Text.text = "Przegrales Synu !!!";
        score_Text.text = "Score: " + calcScore();
        EndGame.enabled=true;

    }
}
