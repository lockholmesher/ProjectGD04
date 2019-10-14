using UnityEngine;
using System.Collections;

public class PlayerBounds : MonoBehaviour {

    private float _minX, _maxX, _minY, _maxY;
    // Use this for initialization
    void Start()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        _minX = -bounds.x + 0.25f;
        _maxX = bounds.x - 0.25f;
        _minY = -bounds.y + 0.25f;
        _maxY = bounds.y - 0.25f;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        if (temp.x < _minX)
        {
            temp.x = _minX;
        }
        else if (temp.x > _maxX)
        {
            temp.x = _maxX;
        }
        if (temp.y < _minY)
        {
            temp.y = _minY;
        }
        else if (temp.y > _maxY)
        {
            temp.y = _maxY;
        }
        transform.position = temp;
    }
}
