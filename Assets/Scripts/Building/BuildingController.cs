using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public BuildingRenderrer buildingRenderrer;
    public int minInLine;

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
}
