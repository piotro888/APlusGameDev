using UnityEngine;
using UnityEngine.UI; // this line works fine
using System.Diagnostics;

public class BombController : MonoBehaviour
{
    public Slider progressBar;
    public AudioSource bomba;
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
         UnityEngine.Debug.Log(y_attached_pos);

            if(y_attached_pos+1 < buildingRenderrer.buildingHeight){
                if(buildingController.isReinforcedObject(y_attached_pos+1, x_pos))
                    buildingRenderrer.deleteElement(5, y_attached_pos+1, x_pos);
                else if(buildingRenderrer.building[y_attached_pos+1, x_pos] != 0 ){
                    buildingRenderrer.deleteBlock(y_attached_pos+1, x_pos);
                    buildingRenderrer.destroyedObjectsScore-=10;
                }
            }

            if(y_attached_pos-1 >= 0){
                if(buildingController.isReinforcedObject(y_attached_pos-1, x_pos))
                    buildingRenderrer.deleteElement(5, y_attached_pos-1, x_pos);
                else if(buildingRenderrer.building[y_attached_pos-1, x_pos] != 0 ){
                    buildingRenderrer.deleteBlock(y_attached_pos-1, x_pos);
                    buildingRenderrer.destroyedObjectsScore-=10;
                }
            }

            if(x_pos+1 < buildingRenderrer.building.GetLength(1)){
                if(buildingController.isReinforcedObject(y_attached_pos, x_pos+1))
                    buildingRenderrer.deleteElement(5, y_attached_pos, x_pos+1);
                else if(buildingRenderrer.building[y_attached_pos, x_pos+1] != 0){
                    buildingRenderrer.deleteBlock(y_attached_pos, x_pos+1);
                    buildingRenderrer.destroyedObjectsScore-=10;
                }
            }

            if(x_pos-1 >= 0){
                if(buildingController.isReinforcedObject(y_attached_pos, x_pos-1))
                    buildingRenderrer.deleteElement(5, y_attached_pos, x_pos-1);
                else if(buildingRenderrer.building[y_attached_pos, x_pos-1] != 0){
                    buildingRenderrer.deleteBlock(y_attached_pos, x_pos-1);
                    buildingRenderrer.destroyedObjectsScore-=10;
                }
            }

            int delete_line_offset = -1;
            for(int i=0; i<3; i++){
                if(y_attached_pos - delete_line_offset < 0 ||
                    y_attached_pos - delete_line_offset >= buildingRenderrer.buildingHeight ||
                    buildingController.checkIfLineValid(y_attached_pos - delete_line_offset))
                {
                    delete_line_offset++; 
                } else {
                    buildingController.destroyLine(y_attached_pos - delete_line_offset);
                }
            }

            if(buildingController.isReinforcedObject(y_attached_pos, x_pos)){
                buildingRenderrer.deleteElement(5, y_attached_pos, x_pos);
            } else {
                buildingRenderrer.deleteBlock(y_attached_pos, x_pos);
                buildingRenderrer.destroyedObjectsScore-=10;
            }
            StartCoroutine(
            buildingGeneratorObject.GetComponent<BombSpawner>().bombSound());
            Destroy(gameObject);

        } else {
            float val = 1f - ( (float) stopwatch.ElapsedMilliseconds/3000);
            progressBar.value = val;
        }
    }
}
