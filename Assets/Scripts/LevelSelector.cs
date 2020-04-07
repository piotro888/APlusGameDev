using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public void selectLevel(int lvl){
        if(lvl == 1){

            GetComponent<BombSpawner>().gen_time = 3000;
            GetComponent<GeneratingItems>().time_generating_for = 5;
            GetComponent<GeneratingItems>().time_generating_for = 15;
            GetComponent<GeneratingItems>().setLadders = 5;
            GetComponent<GeneratingItems>().setConstructionElements = 5;
            GameObject.Find("TimerObject").GetComponent<TimerControl>().endTime = 280;
            GameObject.Find("mid").GetComponent<Movement>().Ladders = 4;
            GameObject.Find("mid").GetComponent<Movement>().ContructionElements = 2;

        } else if(lvl == 2){

            GetComponent<BombSpawner>().gen_time = 2000;
            GetComponent<GeneratingItems>().time_generating_for = 5;
            GetComponent<GeneratingItems>().time_generating_for = 15;
            GetComponent<GeneratingItems>().setLadders = 3;
            GetComponent<GeneratingItems>().setConstructionElements = 5;
            GameObject.Find("TimerObject").GetComponent<TimerControl>().endTime = 300;
            GameObject.Find("mid").GetComponent<Movement>().Ladders = 1;
            GameObject.Find("mid").GetComponent<Movement>().ContructionElements = 0;

        } else if(lvl == 3){

            GetComponent<BombSpawner>().gen_time = 2000;
            GetComponent<GeneratingItems>().time_generating_for = 10;
            GetComponent<GeneratingItems>().time_generating_for = 20;
            GetComponent<GeneratingItems>().setLadders = 3;
            GetComponent<GeneratingItems>().setConstructionElements = 5;
            GameObject.Find("TimerObject").GetComponent<TimerControl>().endTime = 310;
            GameObject.Find("mid").GetComponent<Movement>().Ladders = 0;
            GameObject.Find("mid").GetComponent<Movement>().ContructionElements = 0;

        } else if(lvl == 4){

            GetComponent<BombSpawner>().gen_time = 1000;
            GetComponent<GeneratingItems>().time_generating_for = 5;
            GetComponent<GeneratingItems>().time_generating_for = 15;
            GetComponent<GeneratingItems>().setLadders = 3;
            GetComponent<GeneratingItems>().setConstructionElements = 5;
            GameObject.Find("TimerObject").GetComponent<TimerControl>().endTime = 200;
            GameObject.Find("mid").GetComponent<Movement>().Ladders = 5;
            GameObject.Find("mid").GetComponent<Movement>().ContructionElements = 5;

        }
    }
}
