using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    public Sprite[] sprites;
    System.Random random = new System.Random();

    void Start(){
        int rand = random.Next(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[rand];
    }
}
