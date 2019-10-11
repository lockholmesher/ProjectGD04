using UnityEngine;

[RequireComponent(typeof(Canvas))]
public abstract class BaseState : MonoBehaviour
{
    [HideInInspector] protected Canvas canvas;
    public virtual void Awake()
    {
        canvas = GetComponent<Canvas>();
    }
    public virtual void Show() => canvas.enabled = true;
    public virtual void Hide() => canvas.enabled = false;

    public bool IsShow { get{ return canvas.enabled; }}
}
