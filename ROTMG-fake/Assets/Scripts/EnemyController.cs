using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PersonController
{
    public GameObject enemy;
    public Transform player;
    private Animator anim;
    private SpriteRenderer flipPlayer;
    public float chaseRange = 5f ;
    bool isShoot = false;
    bool isMove = false;

    void Start() {
        anim = enemy.GetComponent<Animator>();
        flipPlayer = enemy.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        anim.SetBool("IsShoot",isShoot);
        anim.SetBool("IsMove",isMove);

        Vector3 tempVect = new Vector3(
            player.position.x,player.position.y,0
        );
        var distance = CalculateDistanceMove(enemy.transform,player);

        if(distance>chaseRange){
            isMove = false;
            Vector3 currentPos = new Vector3(enemy.transform.position.x,enemy.transform.position.y,0);
            MoveUpdate(currentPos,CalculateTimeMove(distance,speed));
        }else{
            isMove = true;
            MoveUpdate(tempVect,CalculateTimeMove(distance,speed));
            if(player.position.x>enemy.transform.position.x){
                 flipPlayer.flipX =false;
            }else{
                 flipPlayer.flipX =true;
            }
        }
    }

    double CalculateDistanceMove(Transform fromObj,Transform toObj){
        return Mathf.Sqrt((fromObj.position.x-toObj.position.x)*(fromObj.position.x-toObj.position.x)
                            +(toObj.position.y-fromObj.position.y)*(toObj.position.y-fromObj.position.y));
    }
    float CalculateTimeMove(double s,float v){
        return (float)s/v;
    }
}
