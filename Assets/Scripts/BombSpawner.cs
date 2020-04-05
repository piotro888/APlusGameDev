using System.Diagnostics;
using System;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{  
    public GameObject bomb;
    public int gen_time = 20000;

    BuildingRenderrer buildingRenderrer;
    BuildingController buildingController;
    Stopwatch stopwatch;
    bool first_cycle = true;
    System.Random random = new System.Random();

    void Start() {
        stopwatch = new Stopwatch();
        stopwatch.Start();
        buildingRenderrer = GetComponent <BuildingRenderrer>();
        buildingController = GetComponent <BuildingController>();
    }

    void Update(){
        int tmp_gen_time = gen_time;
        if(first_cycle) tmp_gen_time = gen_time * 3;
        
        if(stopwatch.ElapsedMilliseconds > tmp_gen_time){
            
            int watchdog_cnt = 0;
            int spawn_x, spawn_y;
            do {
                if(watchdog_cnt >= buildingRenderrer.buildingHeight*buildingRenderrer.building.GetLength(1)+100){
                    enabled = false;
                    return;
                }
                watchdog_cnt++;

                spawn_y = random.Next(0, buildingRenderrer.buildingHeight);
                spawn_x = random.Next(0, buildingRenderrer.building.GetLength(1));
            } while(!buildingController.isSolidObject(spawn_y, spawn_x));

            GameObject spawn_bomb = Instantiate(bomb, new Vector3(spawn_x, spawn_y, 0), Quaternion.identity);
            spawn_bomb.GetComponent<BombController>().init(spawn_y, spawn_x);

            stopwatch.Restart();
        }
    }
}
