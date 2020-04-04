using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    void Update(){
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
 
        if(hit.collider != null) {
            Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);
        } else {
            Debug.Log("NULL");
        }
 
    }
}
