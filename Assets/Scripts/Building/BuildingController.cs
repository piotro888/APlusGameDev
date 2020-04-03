using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public BuildingRenderrer buildingRenderrer;
    public float frameLineShift = -2.0f;

    int minInLine = 4;

    List <int> lines_to_delete = new List<int>();
    List <float> lines_to_shift = new List<float>();

    void Start(){
        buildingRenderrer.render(); //render building on start
    }

    public bool checkIfLineValid(int line){
        int count = 0;
        for(int i=0; i<buildingRenderrer.building.GetLength(1); i++){
            if(buildingRenderrer.building[line, i] != 0)
                count++;
        }
        return (count >= minInLine ? true : false);
    }

    public void destroyLine(int l){
        //destroy elements first
        for(int i=0; i<buildingRenderrer.building.GetLength(1); i++){
            buildingRenderrer.deleteBlock(l, i);
        }

        buildingRenderrer.shiftArrayVertical(l);
        lines_to_delete.Add(l);
        lines_to_shift.Add(1);
    }

    void FixedUpdate(){
        for(int k=0; k<lines_to_delete.Count; k++){
            if(lines_to_shift[k]>0.001f){
                for(int i=lines_to_delete[k]; i<buildingRenderrer.building.GetLength(0); i++){
                    for(int j=0; j<buildingRenderrer.building.GetLength(1); j++){ 
                        buildingRenderrer.moveBlock(i, j, frameLineShift*Time.fixedDeltaTime);
                    }
                }
                lines_to_shift[k]+=frameLineShift*Time.fixedDeltaTime;
            } else {
                buildingRenderrer.roundPos(lines_to_delete[k]);
                lines_to_delete.RemoveAt(k);
                lines_to_shift.RemoveAt(k);
                break;
            }
        }
    }
}
