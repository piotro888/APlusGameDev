using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brzydkiskrypt : MonoBehaviour
{
    public float x;
    public float y;
    public void ustaw(){
        this.GetComponent<RectTransform>().sizeDelta=new Vector2(x,y);
    }
}
