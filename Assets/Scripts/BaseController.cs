using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour 
{
    public const string ClickNumberPaint = "ClickNumberPaint";

    public virtual void Notify(string p_event_path, Object p_target, int p_data)
    {
        throw new System.NotImplementedException();
    }
}
