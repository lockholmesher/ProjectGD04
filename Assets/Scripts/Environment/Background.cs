using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Transform anchor;
    [SerializeField] GameObject side;
    [SerializeField] float height;

    Vector2 old;
    List<GameObject> sides = new List<GameObject>();
    float xLeft;
    float xRight;
    
    void Start()
    {
        old = anchor.position;

        float startY = 0;
        xLeft = -CameraScreen.screenWidth * 0.5f;
        xRight = CameraScreen.screenWidth * 0.5f;

        for(int i = 0; i < 2; i++)
        {
            SpawnPairSide(startY);
            startY -= height;
        }
    }

    void Update()
    {
        float moved = ((Vector2)anchor.position - old).magnitude;
        if(moved >= height)
        {
            old = new Vector2(anchor.position.x, sides[sides.Count - 1].transform.position.y);
            SpawnPairSide(old.y - height);
        }

        sides.RemoveAll(side => 
        {
            if(side.transform.position.y - anchor.position.y > height)
            {
                side.SetActive(false);
                return true;
            }
            return false;
        });
    }

    private void SpawnPairSide(float y)
    {
        var left = PoolObjects.Instance.GetFreeObject(side, transform);
        left.transform.position = new Vector2(xLeft, y);
        Vector2 scale = left.transform.localScale;
        left.transform.localScale = new Vector2(Mathf.Abs(scale.x), Mathf.Abs(scale.y));

        var right = PoolObjects.Instance.GetFreeObject(side, transform);
        right.transform.position = new Vector2(xRight, y);
        scale = right.transform.localScale;
        right.transform.localScale = new Vector2(-Mathf.Abs(scale.x), Mathf.Abs(scale.y));

        sides.Add(left);
        sides.Add(right);
    }
}
