﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingItems : MonoBehaviour
{

    public float left; // lewy punkt spawnu boxa
    public float bot; // dolny punkt

    public int distance; // odleglosc od punktow generowania poszczegolnych boxow
    public int time_generating_for; // losowanie
    public int time_generating_to; // czasu miedzy pojawieniami sie boxow for-to

    private int width, height,pos; 
    private float time=0,current_time;

    public GameObject Box;


    void Start()
    {
       width = this.GetComponent<BuildingRenderrer>().building.GetLength(1);
       height = this.GetComponent<BuildingRenderrer>().building.GetLength(0);;
       Debug.Log(width + " " + height);
    }

    void Update()
    {
       if(time<=current_time){
            pos=Random.Range(1,(width*height));
            Debug.Log(pos);
            for(int i=0;i<height;i++)
                for(int j=0;j<width&&pos>0;j++){
                    pos--;
                    if(pos==0)
                    Instantiate(Box,new Vector3(left+j*distance,bot+i*distance,0f),Quaternion.identity);
                }

           current_time=Time.deltaTime;
           time=Random.Range(time_generating_for,time_generating_to)+current_time;
       }
       time-=Time.deltaTime;
    }
}