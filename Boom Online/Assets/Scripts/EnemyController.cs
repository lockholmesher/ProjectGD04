using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public PathDefinition thePath;
    public float moveSpeed = 1f;
    private Transform _targetPoint;
    void Start()
    {
        if (thePath == null)
            return;
        transform.position = thePath.getPointAt(0).position;
        _targetPoint = thePath.getNextPoint();
    }
    // Update is called once per frame
    void Update()
    {
        if (thePath == null)
            return;
        transform.position = Vector3.MoveTowards(transform.position,_targetPoint.position,moveSpeed*Time.deltaTime);
        var distanceTarget = (transform.position - _targetPoint.position).sqrMagnitude;
        if(distanceTarget<0.1f)
        {
            _targetPoint = thePath.getNextPoint();
        }
    }
}
