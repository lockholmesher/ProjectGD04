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
    void Shoot(){

    }
    protected void MoveTo(Vector3 EndPoint,Action onComplete=null){
        LeanTween.moveLocal(this.gameObject,EndPoint,speed).setEase(typeMove).setOnComplete(onComplete);
    }
    protected void MoveUpdate(Vector3 EndPoint)
    {
        LeanTween.cancel (id);
		id = LeanTween.moveLocal (gameObject, EndPoint, speed).setEase(typeMove).id;
    }
    void UseSkill(){

    }
    void BeShoot(){

    }
    void BeDead(){

    }
}
