using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIListNumberColor : SingletionMonoBehaviour<UIListNumberColor>
{
	//tam thoi de static sau co data se get list color tu data
	
	[SerializeField]
	private Transform ListContent;
	[SerializeField]
	private Transform PaintTexture;
    private BaseController BaseController;
    void Start()
    {
        
    }
	public void InitNumberColors(Dictionary<int, List<ColorTex>> lisData)
	{
        if(BaseController == null)
        {
            BaseController = GamePlayController.Instance.IListColor;
        }
		// get data from dataManager khi co file data
		Debug.Log(lisData.Count);
		for( int i = 0; i < lisData.Count; i++)
		{
			InitNumberColor(i, lisData[i][0].colorTexture, BaseController);
		}
	}
	public void InitNumberColor(int key , Color color , BaseController basecontrol )
	{
        var child = CreateController.Instance.create( ListContent);
		child.transform.localScale = Vector3.one;
		child.SetUpData(key, color, BaseController);
	}

	public void SpawnNumber(List<Vector2> lisPosition)
	{
		for( int i = 0; i < lisPosition.Count; i++)
		{
			var child = CreateController.Instance.createNumberInTexture(lisPosition[i],null);
			child.SetUpData(lisPosition[i],(i + 1).ToString());
		}
	}
}
