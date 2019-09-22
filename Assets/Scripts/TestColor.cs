using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class TestColor : SingletionMonoBehaviour<TestColor>/*, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler*/
{
	public Texture2D test;

	public Texture2D texture;
	Dictionary<int, List<ColorTex>> listRally = new Dictionary<int, List<ColorTex>>();
    int count = 0;
    public List<ListLock> locks = new List<ListLock>();

	public DataGame data;
	void Start()
    {

		DataManager.Instance.LoadData("data.json");
		//get khoang mau # nhau
		var lisData = DataManager.Instance.GetData().lis;
		var liscolor = GetlistColorForTextture(test.GetPixels());
		for (int i = 0; i < liscolor.Count; i++)
		{
			lisData.Add(i, LoadArrColor(liscolor[i]));
		}
		Debug.Log(lisData.Count);
		DataManager.Instance.SaveData("data.json", lisData);
		//Debug.Log(DataManager.Instance.LoadData("data.json").lis.Count);
	}

	
	
	public List<Color> GetlistColorForTextture(Color[] colors)
	{
		List<Color> list = new List<Color>();
		for (int i = 0; i < colors.Length; i++)
		{
			if (list.Count == 0)
			{
				list.Add(colors[i]);
			}
			else
			{
				if (!CheckColor(colors[i], list))
				{
					list.Add(colors[i]);
				}
			}
		}

		return list;
	}

	public bool CheckColor(Color color, List<Color> list)
	{
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] == color)
			{
				return true;
			}
		}
		return false;
	}

	public List<ColorTex> LoadArrColor(Color color)
	{
		List<ColorTex> lis = new List<ColorTex>();
		for( int i = 0; i < 299; i++)
		{
			for(int j = 0; j < 299; j++)
			{
				if(color == test.GetPixel(i ,j))
				{
					lis.Add(new ColorTex(color, new Vector2(i, j)));
				}
			}
		}
		return lis;
	}
	

	public void SetDataDefault(Texture2D color ,Texture2D dataset, int maxrow , int maxcol)
	{
		for( int i = 0; i < maxrow; i++)
		{
			for(int j = 0; j < maxcol; j++)
			{
				dataset.SetPixel(i, j, color.GetPixel(i, j));
			}
		}
	}
	
	public List<Vector2> GetListPosColorDefault(Color colorFind , Texture2D originalTextTure, List<Vector2> lis = null)
	{
		lis = new List<Vector2>();
		for(int i = 0; i < 512; i ++)
		{
			for( int j = 0; j < 512; j++)
			{
				if(colorFind ==  originalTextTure.GetPixel(i , j))
				{
					lis.Add(new Vector2(i, j));
				}
			}
		}
		return lis;
	}
	public void ClearColor(Texture2D texcolor)
	{
		for (int i = 0; i < 512; i++)
		{
			for (int j = 0; j < 512; j++)
			{

				//Color color = ((texcolor.GetPixel(i, j).r & texcolor.GetPixel(i, j).g) != 0 ? Color.white : Color.red);
				texcolor.SetPixel(i, j, Color.white);

			}
		}
		texcolor.Apply();
	}

	void SetupData()
	{
		//DataManager.Instance.SaveData("data.json", test);
	}
}
[SerializeField]
public class ListLock
{
	public	Color value;

	public Vector2 posi;
	public ListLock(Color value_, Vector2 pos)
	{
		value = value_;
		posi = pos;
	}
};