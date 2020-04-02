using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public BuildingRenderrer buildingRenderrer;

    void Start(){
        buildingRenderrer.render(); //render building on start
    }
}
