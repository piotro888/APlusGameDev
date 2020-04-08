using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {



    [Header("Poruszanie")]

    public Rigidbody2D pl;
    public float velocity_player;
    public GameObject player;
    public Animator anim;
    public float size_x, size_y;
    public bool end=false;
    //public Camera kamera;
    bool czy_chodzi, czy_drabina;
    [Header("Drabina")]
    public AudioSource cos;
    public AudioSource podnoszenie;
    public AudioSource drabina;
    public float velocity_ladder;
    public bool isCollsionWithLadder = false;

    [Header("Ekwipunek")]
    public int Ladders;
    public int ContructionElements;

    Collider2D ladderObj;

    void OnTriggerEnter2D(Collider2D obj) {
        if (obj.gameObject.tag == "Ladder") {
            ladderObj = obj;
            isCollsionWithLadder = true;
        }
        if (obj.gameObject.tag == "Box") {
            Debug.Log("zde");
            Ladders += obj.GetComponent<InBox>().count_Ladders;
            ContructionElements += obj.GetComponent<InBox>().count_ConstructionElements;
            Destroy(obj.gameObject);
            Debug.Log("drabiny: " + Ladders + " i elementy budowy: " + ContructionElements);
            podnoszenie.Play();
        }
    }

    void OnTriggerStay2D(Collider2D obj) {
        if (obj.gameObject.tag == "Ladder") {
            isCollsionWithLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D obj) {
        if (obj.gameObject.tag == "Ladder") {
            player.GetComponent<Collider2D>().isTrigger = false;
            isCollsionWithLadder = false;
        }
    }


    void Update() {
        //kamera.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10f);
        anim.SetFloat("animacjapor", Mathf.Abs(pl.velocity.x));
        anim.SetFloat("animacjaskok", Mathf.Abs(pl.velocity.y));
        if(end==false){
        if (isCollsionWithLadder) {
            pl.gravityScale = 0.5f;
            if (Input.GetKey(KeyCode.W)) {
                pl.velocity = new Vector2(0, velocity_ladder);
                player.GetComponent<Collider2D>().isTrigger = true;
                player.transform.position = new Vector2(ladderObj.transform.position.x, player.transform.position.y);
            }
            else if (Input.GetKey(KeyCode.S)) {
                pl.velocity = new Vector2(0, -(velocity_ladder / 2));
                player.GetComponent<Collider2D>().isTrigger = true;
                player.transform.position = new Vector2(ladderObj.transform.position.x, player.transform.position.y);
            }
            else {
                player.GetComponent<Collider2D>().isTrigger = false;
            }
        }

        if (isCollsionWithLadder == true) anim.SetBool("LadderOn", true);
        else anim.SetBool("LadderOn", false);

        if (Input.GetKey(KeyCode.D))
        {
            pl.velocity = new Vector2(velocity_player, pl.velocity.y);
            player.transform.localScale = new Vector2(size_x, size_y);
            pl.gravityScale = 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            pl.velocity = new Vector2(-velocity_player, pl.velocity.y);
            player.transform.localScale = new Vector2(-size_x, size_y);
            pl.gravityScale = 1f;
        }

        if (pl.velocity.x != 0)
            czy_chodzi = true;
        else
            czy_chodzi = false;

        if (czy_chodzi)
        {
            if (!cos.isPlaying)
                cos.Play();
        }
        else
            cos.Stop();

        if (pl.velocity.y != 0 && (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.S))))
            czy_drabina = true;
        else
            czy_drabina = false;

        if (czy_drabina)
        {
            if (!drabina.isPlaying)
                drabina.Play();
        }
        else
            drabina.Stop();
    }
    else {pl.gravityScale = 0f;pl.velocity = new Vector2(0f, 0f);}}

    public int getLadders(){
        return Ladders;
    }

    public int getConstructionElements(){
        return ContructionElements;
    }
    
    
}