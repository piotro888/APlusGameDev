using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCollider : MonoBehaviour
{
    public bool isLadder=false;
    void OnTriggerStay2D(Collider2D obj){
        if(obj.gameObject.tag=="Ground") isLadder=false;
        else isLadder=true;
    }
}
