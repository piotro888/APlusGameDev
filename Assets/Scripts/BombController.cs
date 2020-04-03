using UnityEngine;
using System.Diagnostics;

public class BombController : MonoBehaviour
{
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
        UnityEngine.Debug.Log(attachedObject);
        enabled = true;
        stopwatch.Start();
    }

    
    void FixedUpdate(){
        if(stopwatch.ElapsedMilliseconds > 1000){
            stopwatch.Stop();
            UnityEngine.Debug.Log("BOOM");
            Destroy(gameObject);
        }
    }
}
