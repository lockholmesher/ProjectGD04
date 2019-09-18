using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PersonController
{
    public Transform obj;
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
    public void Update()
    {
       float ho = Input.GetAxis("Horizontal");
       float ve = Input.GetAxis("Vertical");
       Vector3 tempVect = new Vector3(ho,ve,0);
       tempVect = tempVect.normalized*speed*Time.deltaTime;
       obj.transform.position += tempVect;
    }
}
