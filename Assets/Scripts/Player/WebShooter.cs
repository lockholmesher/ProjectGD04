using UnityEngine;

public class WebShooter : MonoBehaviour
{
    public LineRenderer lineRenderer;

    Vector2 target;
    bool isDraw = false;
    public void Shoot(Vector2 target)
    {
        lineRenderer.positionCount = 0;
        isDraw = true;
        this.target = target;
    }

    void Update()
    {
        if(isDraw)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, (Vector2)transform.position);
            lineRenderer.SetPosition(1, target);
        }
    }

    public void Clear()
    {
        lineRenderer.positionCount = 0;
        isDraw = false;
    }
}