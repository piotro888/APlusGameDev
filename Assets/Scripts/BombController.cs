﻿using UnityEngine;
using UnityEngine.UI; // this line works fine
using System.Diagnostics;

public class BombController : MonoBehaviour
{
    public Slider progressBar;

    GameObject buildingGeneratorObject;
    BuildingRenderrer buildingRenderrer;
    BuildingController buildingController;
    GameObject attachedObject;
    Stopwatch stopwatch = new Stopwatch();

    public void init(int x, int y){
        enabled = false;
        buildingGeneratorObject = GameObject.Find("BuildingGeneratorObject");
        buildingRenderrer = buildingGeneratorObject.GetComponent<BuildingRenderrer>();
        buildingController = buildingGeneratorObject.GetComponent<BuildingController>();        
        attachedObject = buildingController.attachBomb(gameObject, x, y);
        enabled = true;
        stopwatch.Start();
    }

    
    void FixedUpdate(){
        if(stopwatch.ElapsedMilliseconds > 3000){
            stopwatch.Stop();
            int x_pos = (int)Mathf.Floor(transform.position.x) - (int) Mathf.Floor(buildingGeneratorObject.transform.position.x);
            int y_attached_pos = buildingController.getYPosOfGameObject(attachedObject, x_pos);

            buildingRenderrer.deleteBlock(y_attached_pos+1, x_pos);
            buildingRenderrer.deleteBlock(y_attached_pos-1, x_pos);
            buildingRenderrer.deleteBlock(y_attached_pos, x_pos+1);
            buildingRenderrer.deleteBlock(y_attached_pos, x_pos-1);

            buildingRenderrer.addElement(7, y_attached_pos+1, x_pos);
            buildingRenderrer.addElement(7, y_attached_pos-1, x_pos);
            buildingRenderrer.addElement(7, y_attached_pos, x_pos+1);
            buildingRenderrer.addElement(7, y_attached_pos, x_pos-1);

            int delete_line_offset = -1;
            for(int i=0; i<3; i++){
                if(buildingController.checkIfLineValid(y_attached_pos - delete_line_offset)){
                   delete_line_offset++; 
                } else {
                    buildingController.destroyLine(y_attached_pos - delete_line_offset);
                }
            }

            buildingRenderrer.deleteBlock(y_attached_pos, x_pos);
            Destroy(gameObject);
        } else {
            float val = 1f - ( (float) stopwatch.ElapsedMilliseconds/3000);
            progressBar.value = val;
        }
    }
}
