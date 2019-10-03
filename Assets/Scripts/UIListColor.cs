using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIListColor : BaseController
{
   
    void Start()
    {
        
    }

	public void OnfinishAds(int number)
	{

	}
    public override void Notify(string p_event_path, Object p_target, int p_data)
    {
        switch(p_event_path)
        {
            case ClickNumberPaint:
                Debug.Log("Click" + p_data.ToString());
                break;

        }
       
    }
}
