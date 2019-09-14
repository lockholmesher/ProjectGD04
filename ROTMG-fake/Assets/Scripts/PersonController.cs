using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PersonController : BehaviourController
{
    int exp;
    int hp;
    int mana;
    public int speed;
    int atk;
    int def;
    int dex;
    int vit;
    int wis;
    int id;

    //public float timeMove;
    void Shoot(){

    }
    protected void MoveTo(Vector3 EndPoint,float timeMove,Action onComplete = null){
        LeanTween.moveLocal(this.gameObject,EndPoint,timeMove).setEase(typeMove).setOnComplete(onComplete);
    }
    protected void MoveUpdate(Vector3 EndPoint,float timeMove)
    {
        LeanTween.cancel (id);
		id = LeanTween.moveLocal (gameObject, EndPoint, timeMove).setEase(typeMove).id;
    }
    void UseSkill(){

    }
    void BeShoot(){

    }
    void BeDead(){

    }
}
