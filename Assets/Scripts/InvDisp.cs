using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InvDisp : MonoBehaviour
{   
    public TMPro.TextMeshProUGUI text1;
    public TMPro.TextMeshProUGUI text2;
    public GameObject playerObj;
    
    Movement player;

    void Start(){
        player = playerObj.GetComponent<Movement>();
    }

    void Update() {
        text1.text = ""+player.getConstructionElements();
        text2.text = ""+player.getLadders();
    }
}
