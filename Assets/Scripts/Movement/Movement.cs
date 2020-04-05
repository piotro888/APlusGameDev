using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [Header ("Poruszanie")]
    public Rigidbody2D pl;
    public float velocity_player;
    public GameObject player;
    //private Animator animacja;
    //public Camera kamera;

    [Header ("Drabina")]
    public float velocity_ladder;
    public bool isCollsionWithLadder = false;

    [Header ("Ekwipunek")]
    public int Ladders;
    public int ContructionElements;

    Collider2D ladderObj;

    void OnTriggerEnter2D(Collider2D obj){
        if(obj.gameObject.tag=="Ladder"){
            ladderObj = obj;
            isCollsionWithLadder = true;
        }
        if(obj.gameObject.tag=="Box"){
            Ladders+=obj.GetComponent<InBox>().count_Ladders;
            ContructionElements+=obj.GetComponent<InBox>().count_ConstructionElements;
            Destroy(obj.gameObject);
            Debug.Log("drabiny: " + Ladders + " i elementy budowy: " + ContructionElements);
        }
    }

    void OnTriggerStay2D(Collider2D obj){
        if(obj.gameObject.tag=="Ladder"){
            isCollsionWithLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D obj){
        if(obj.gameObject.tag == "Ladder"){
            player.GetComponent<Collider2D>().isTrigger=false;
            if(obj == ladderObj) isCollsionWithLadder = false;
        }
    }


    void Update () {
        //kamera.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10f);
            if (Input.GetKey(KeyCode.D))
            {
                pl.velocity = new Vector2(velocity_player, pl.velocity.y);
                pl.gravityScale=1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                pl.velocity = new Vector2(-velocity_player, pl.velocity.y);
                pl.gravityScale=1f;
            }

            if(isCollsionWithLadder){
                pl.gravityScale=0.5f;
                if (Input.GetKey(KeyCode.W)){
                        pl.velocity = new Vector2(0, velocity_ladder);
                        player.GetComponent<Collider2D>().isTrigger=true;
                        player.transform.position = new Vector2(ladderObj.transform.position.x,player.transform.position.y);
                }
                else if (Input.GetKey(KeyCode.S)){
                        pl.velocity = new Vector2(0, -(velocity_ladder/2));
                        player.GetComponent<Collider2D>().isTrigger=true;
                        player.transform.position = new Vector2(ladderObj.transform.position.x,player.transform.position.y);
                }
                else {
                    player.GetComponent<Collider2D>().isTrigger=false;
                }
            }
        

        //roznica = Mathf.Abs(stanPrzed - pl.position.x);

        
        /*if (jestDrabina == true)
        {
            pl.gravityScale = 1f;
            animacja.SetBool("drabinka", jestDrabina);
            animacja.SetBool("skok", true);
            animacja.SetBool("woda", jestWoda);

        }
        else
        {
            pl.gravityScale = 1f;
            animacja.SetBool("drabinka", jestDrabina);
            animacja.SetFloat("velocity_player", roznica);
            animacja.SetBool("skok", dotyka);
            animacja.SetBool("woda", jestWoda);
        }*/
        
    }

    public int getLadders(){
        return Ladders;
    }

    public int getConstructionElements(){
        return ContructionElements;
    }

    /*private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "przeciwnik")
        {            
            serce.GetComponent<Menu>().Umiera();
        }
        if(obj.gameObject.tag == "koniec")
        {
            
        }
        if (obj.gameObject.tag == "spawnpoint")
        {
            serce.GetComponent<Menu>().spawnpoint.transform.position = player.transform.position;
        }
    }*/
}