using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBombGen : MonoBehaviour
{
    public GameObject bomb;

    public void Spawn(){
        GameObject gen_bomb = Instantiate(bomb, new Vector3(0, 0, 0), Quaternion.identity);
        gen_bomb.GetComponent<BombController>().init(1, 1);
    }
}
