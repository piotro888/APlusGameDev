using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBox : MonoBehaviour
{
    // losowanie ilosci poszczegolnych blokow
    public int max_count_Ladders;
    public int max_count_ConstrucionElements;
    public int count_Ladders; 
    public int count_ConstructionElements;  
    void Start()
    {
        StartCoroutine("SpawnBox"); 
        count_Ladders = Random.Range(1,max_count_Ladders);
        count_ConstructionElements= Random.Range(1,max_count_ConstrucionElements);
    }

    IEnumerator SpawnBox(){
        this.GetComponent<Rigidbody2D>().gravityScale = 0f;
        this.GetComponent<BoxCollider2D>().isTrigger=true;
        this.tag="Unbreakable";
        for(int i=0;i<3;i++){
            this.GetComponent<SpriteRenderer>().color= new Color(1f,1f,1f,0.4f);
            yield return new WaitForSeconds(0.5f);
            this.GetComponent<SpriteRenderer>().color= new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(0.5f);
        }
        this.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        this.GetComponent<BoxCollider2D>().isTrigger=false;
        this.tag="Box";
    }

}
