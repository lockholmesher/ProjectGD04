using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PersonController
{
    //public Transform obj;
    public GameObject player;
    private Animator anim;
    private SpriteRenderer flipPlayer;
    int directionMove = 0;
    // Direction: 0: idle; 1:right, 2: left, 3: up, 4: down;
    void Start() {
        anim = player.GetComponent<Animator>();
        flipPlayer = player.GetComponent<SpriteRenderer>();
    }
    void LvlUp(){

    }
    void PickUpItem(){

    }
    void MoveItem(){

    }
    void ComsumeItem(){

    }
    void EquipItem(){

    }
    void DestroyItem(){
        
    }  
    public void FixedUpdate()
    {
       anim.SetInteger("DirectionMove",directionMove);
       float ho = Input.GetAxis("Horizontal");
       float ve = Input.GetAxis("Vertical");
       Vector3 tempVect = new Vector3(ho,ve,0);
       tempVect = tempVect.normalized*speed*Time.fixedDeltaTime;

       if(ho == 0&&ve ==0){
            directionMove = 0;
       }else{
           //di chuyen nhan vat
            player.transform.position += tempVect;

            if(ve>0){
                directionMove = 3;
            }else if(ve <0){
                directionMove = 4;
            }else{
                if(ho > 0){
                    directionMove = 1;
                    flipPlayer.flipX =false;
                }else{
                    directionMove = 2;
                    flipPlayer.flipX =true;
                }
            }  
       } 
    }
}
