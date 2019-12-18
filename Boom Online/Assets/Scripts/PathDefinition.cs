using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDefinition : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] listPoints;
    public int startAt = 0;
    public int directionMove = 1;
    public void OnDrawGizmos()
    {
        if (listPoints == null ||
            listPoints.Length < 2)
            return;
        for (int i = 1; i < listPoints.Length; i++)
        {
            Gizmos.DrawLine(listPoints[i - 1].position, listPoints[i].position);
        }

    }
    public Transform getPointAt(int p)
    {
        return listPoints[p];
    }
    public Transform getNextPoint()
    {
        if (startAt == 0)
            directionMove = 1;
        else if (startAt == listPoints.Length - 1)
            directionMove = -1;
        startAt += directionMove;
        return listPoints[startAt];
    }
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}
}
