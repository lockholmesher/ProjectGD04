using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BehaviourController : MonoBehaviour
{
    protected float durationChangeValue;
    protected LeanTweenType typeMove = LeanTweenType.linear;
    protected void UpdateValueAndChangeColor(float from, float to, Action<float> updateValueCallback = null,Action onComplete = null){
        LeanTween.value(gameObject,from,to,durationChangeValue).setEase(typeMove).setOnUpdate(updateValueCallback).setOnComplete(onComplete);
    }
    protected void CheckCollider(){
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position,Vector2.zero);
        if(hit.collider!=null){
            OnCollection(hit.collider);
        }
    }
    protected virtual void OnCollection(Collider2D collider){}
}
