using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PersonController
{
    public Transform obj;
    public Transform playerObj;
    void Update()
    {
        Vector3 tempVect = new Vector3(
            playerObj.transform.position.x,playerObj.transform.position.y,0
        );
        MoveUpdate(tempVect,CalculateTimeMove(CalculateS(obj,playerObj),speed));
        //tempVect = tempVect.normalized*speed*Time.deltaTime;
        //obj.transform.position += tempVect;
    }

    double CalculateS(Transform fromObj,Transform toObj){
        return Mathf.Sqrt((fromObj.position.x-toObj.position.x)*(fromObj.position.x-toObj.position.x)
                            +(toObj.position.y-fromObj.position.y)*(toObj.position.y-fromObj.position.y));
    }
    float CalculateTimeMove(double s,float v){
        return (float)s/v;
    }
}
