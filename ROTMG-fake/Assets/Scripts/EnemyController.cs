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
            playerObj.transform.localPosition.x,playerObj.transform.localPosition.y,0
        );
        MoveUpdate(tempVect);
        //tempVect = tempVect.normalized*speed*Time.deltaTime;
        //obj.transform.position += tempVect;
    }
}
