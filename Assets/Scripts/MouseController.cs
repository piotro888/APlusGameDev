using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject hlOK;
    public GameObject hlWA;
    public GameObject player;

    GameObject lastObj;
    BuildingController buildingController;
    BuildingRenderrer buildingRenderrer;

    void Start(){
        buildingController = GetComponent<BuildingController>();
        buildingRenderrer = GetComponent<BuildingRenderrer>();
    }

    void Update(){
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        
        if(lastObj != null){
            Destroy(lastObj);
        }


        if(Input.GetMouseButtonDown(0) && hit.collider != null){
            if(canBuild(hit)){
                Vector2 hit_pos = hit.collider.gameObject.transform.position;
                int x_array_pos = (int) Mathf.Floor(hit_pos.x - transform.position.x );
                int y_array_pos = (int) Mathf.Floor(hit_pos.y - transform.position.y);
                if(buildingController.isEmptyObject(y_array_pos, x_array_pos)){
                    buildingRenderrer.addElement(2, y_array_pos, x_array_pos, false);
                } else {
                    buildingRenderrer.addElement(5, y_array_pos, x_array_pos, false);
                }
            }
        }

        if(Input.GetMouseButtonDown(1) && hit.collider != null){
            if(canBuild(hit)){
                Vector2 hit_pos = hit.collider.gameObject.transform.position;
                int x_array_pos = (int) Mathf.Floor(hit_pos.x - transform.position.x );
                int y_array_pos = (int) Mathf.Floor(hit_pos.y - transform.position.y);
                if(buildingController.isSolidObject(y_array_pos, x_array_pos)){
                    buildingRenderrer.addElement(4, y_array_pos, x_array_pos, false);
                }
            }
        }

        if(hit.collider != null) {
            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Building")){
                Vector2 hit_pos = hit.collider.gameObject.transform.position;
                if(canBuild(hit)){
                    lastObj = Instantiate(hlOK, hit_pos, Quaternion.identity);
                } else {
                    lastObj = Instantiate(hlWA, hit_pos, Quaternion.identity);
                }
            }
        }
 
    }

    bool canBuild(RaycastHit2D hit){
        if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Building")){
            Vector2 hit_pos = hit.collider.gameObject.transform.position;
            if((Mathf.Abs(player.gameObject.transform.position.x - hit_pos.x) <= 3.6f)
            && (Mathf.Abs(player.gameObject.transform.position.y - hit_pos.y) <= 1.5f)){
                return true;
            } else {
                return false;
            }
        }
        return false;
    }

}
