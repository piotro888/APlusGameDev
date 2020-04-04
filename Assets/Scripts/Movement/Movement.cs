using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [Header ("Poruszanie")]
    public Rigidbody2D pl;
    public float velocity_player;
    public GameObject head;
    public GameObject feet;
    public GameObject player;
    //private Animator animacja;
    //public Camera kamera;

    [Header ("Drabina")]
    public float velocity_ladder;


    void OnTriggerStay2D(Collider2D obj){
       if(obj.gameObject.tag=="Ladder"){
           pl.gravityScale=0.5f;
           if (Input.GetKey(KeyCode.W)&&head.GetComponent<HeadCollider>().isLadder==true){
                pl.velocity = new Vector2(0, velocity_ladder);
                player.GetComponent<Collider2D>().isTrigger=true;
               player.transform.position = new Vector2(obj.transform.position.x,player.transform.position.y);
           }
           else if (Input.GetKey(KeyCode.S)&&feet.GetComponent<FeetCollider>().isLadder==true){
                pl.velocity = new Vector2(0, -(velocity_ladder/2));
                player.GetComponent<Collider2D>().isTrigger=true;
               player.transform.position = new Vector2(obj.transform.position.x,player.transform.position.y);
           }
           else {player.GetComponent<Collider2D>().isTrigger=false;
           }
            /*else if (Input.GetKey(KeyCode.S)){
                pl.velocity = new Vector2(0, -velocity_ladder);

            }*/
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