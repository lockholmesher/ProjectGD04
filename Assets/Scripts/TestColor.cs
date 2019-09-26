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

	public Texture2D texCurrent;

	Dictionary<int, List<ColorTex>> lisData;

	int count = 0;
   

	void Start()
    {

		DataManager.Instance.LoadData("data.json");
		//get khoang mau # nhau
		lisData = DataManager.Instance.GetData().lis;
		var liscolor = GetlistColorForTextture(test.GetPixels());
		for (int i = 0; i < liscolor.Count; i++)
		{
			lisData.Add(i, LoadArrColor(liscolor[i]));
		}
		Debug.Log(lisData.Count);
		ClearColor(texture);
		
		//DataManager.Instance.SaveData("data.json", lisData);
		//Debug.Log(DataManager.Instance.LoadData("data.json").lis.Count);
	}

	public void Spawn(Vector2 posi)
	{
		Debug.Log(posi);
		Debug.Log(texCurrent.GetPixel((int)posi.x,(int)posi.y));
		for (int i = 0; i < lisData.Count; i++)
		{
			if(test.GetPixel((int)posi.x,(int)posi.y)  == lisData[i][0].colorTexture )
			{
				SpawnArr(i);
				return;
			}
		}
	}
	public void SpawnArr(int keyvalue)
	{
		for( int i = 0; i < lisData[keyvalue].Count;i++)
		{
			texture.SetPixel((int)lisData[keyvalue][i].pos.x, (int)lisData[keyvalue][i].pos.y, texCurrent.GetPixel((int)lisData[keyvalue][i].pos.x, (int)lisData[keyvalue][i].pos.y));
		}
		texture.Apply();
	}
	public void ClearColor(Texture2D tex)
	{
		for(int i = 0; i < 299; i++)
		{
			for(int j = 0; j < 299; j++)
			{
				if (tex.GetPixel(i,j) != Color.black)
				{
					tex.SetPixel(i, j, Color.white);
				}
			}
		}
		tex.Apply();
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
	//public void ClearColor(Texture2D texcolor)
	//{
	//	for (int i = 0; i < 512; i++)
	//	{
	//		for (int j = 0; j < 512; j++)
	//		{

	//			//Color color = ((texcolor.GetPixel(i, j).r & texcolor.GetPixel(i, j).g) != 0 ? Color.white : Color.red);
	//			texcolor.SetPixel(i, j, Color.white);

	//		}
	//	}
	//	texcolor.Apply();
	//}

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