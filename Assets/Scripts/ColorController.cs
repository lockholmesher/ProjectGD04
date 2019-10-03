using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class ColorController : SingletionMonoBehaviour<ColorController>/*, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler*/
{
	public Texture2D test;

	public Texture2D texture;

	public Texture2D texCurrent;

	Dictionary<int, List<ColorTex>> lisData;

	Dictionary<int, List<Vector2>> listpos;

	int count = 0;
   

	void Start()
    {

		//DataManager.Instance.LoadData("data.json");
		////get khoang mau # nhau
		listpos = new Dictionary<int, List<Vector2>>();
		lisData = DataManager.Instance.GetData().lis;
		var liscolor = GetlistColorForTextture(test.GetPixels());
		for (int i = 0; i < liscolor.Count; i++)
		{
			lisData.Add(i, LoadArrColor(liscolor[i]));
		}
		
		// spawn NUmber bottom;
		UIListNumberColor.Instance.InitNumberColors(lisData);

		// spawn number in texture

		UIListNumberColor.Instance.SpawnNumber(GetListPosNumber(lisData));
		
		//DataManager.Instance.SaveData("data.json", lisData);
		//Debug.Log(DataManager.Instance.LoadData("data.json").lis.Count);
	}

	
	public void Spawn(Vector2 posi)
	{
		
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
			texCurrent.SetPixel((int)lisData[keyvalue][i].pos.x, (int)lisData[keyvalue][i].pos.y, texture.GetPixel((int)lisData[keyvalue][i].pos.x, (int)lisData[keyvalue][i].pos.y));
		}
		texCurrent.Apply();
	}
	public void ClearColor(Texture2D tex)
	{
		for(int i = 0; i < tex.width; i++)
		{
			for(int j = 0; j < tex.height; j++)
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
		for( int i = 0; i < test.width; i++)
		{
			for(int j = 0; j < test.height; j++)
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
	// list number texture

	public List<Vector2> GetListPosNumber(Dictionary<int, List<ColorTex>> lisData , List<Vector2> list = null)
	{
		list = new List<Vector2>();
		for (int i = 1; i < lisData.Count; i++)
		{
			list.Add(GetPosNumberInTexture(lisData[i]));
		}
		//list.Add(GetPosNumberInTexture(lisData[3]));
		return list;
	}
	public Vector2 GetPosNumberInTexture(List<ColorTex> lisData)
	{
		return new Vector2(GetX(lisData), GetY(lisData));
	}
	//get pos y
	List<Vector2> vecY = new List<Vector2>();
	public float GetY(List<ColorTex> lisData)
	{
		List<int> count = new List<int>();
		for (int i = 0; i < lisData.Count; i++)
		{
			if (vecY.Count == 0)
			{
				vecY.Add(lisData[i].pos);
			}
			else
			{
				if (checkVecY(lisData[i].pos) == true)
				{
					vecY.Add(lisData[i].pos);
				}
			}
		}
		
		for (int i = 0; i < vecY.Count; i++)
		{
			count.Add(CountPosX(vecY[i], lisData));
		}
		var sum = count[0];

		int index = 0;
		for (int i = 0; i < count.Count; i++)
		{
			if (count[i] > sum)
			{
				sum = count[i];
				index = i;
			}
		}

		
		return vecY[index].y;

	}
	public int CountPosY(Vector2 pos, List<ColorTex> lisData, int count = 0)
	{
		for (int i = 0; i < lisData.Count; i++)
		{
			if (lisData[i].pos.y == pos.y)
			{
				count++;
			}
		}
		return count;
	}
	public bool checkVecY(Vector2 pos)
	{
		for (int i = 0; i < vecY.Count; i++)
		{
			if (vecY[i].y == pos.y)
			{
				return false;
			}
		}
		return true;
	}
	// get pos X
	List<Vector2> vecX = new List<Vector2>();
	public float GetX(List<ColorTex> lisData)
	{
		List<int> count = new List<int>();
		for ( int i = 0; i < lisData.Count; i++)
		{
			if(vecX.Count == 0)
			{
				vecX.Add(lisData[i].pos);
			}
			else
			{
				if(checkVecX(lisData[i].pos) == true)
				{
					vecX.Add(lisData[i].pos);
				}
			}
		}
		for( int i = 0; i < vecX.Count; i++)
		{
			count.Add(CountPosX(vecX[i], lisData)); 
		}
		var sum = count[0];
		
		int index = 0;
		for(int i = 0; i < count.Count; i++)
		{
			if( count[i] > sum)
			{
				sum = count[i];
				index = i ;
			}
		}
		
		
		return vecX[index].x;

	}
	public int CountPosX(Vector2 pos , List<ColorTex> lisData, int count = 0)
	{
		for(int i = 0; i < lisData.Count; i++)
		{
			if(lisData[i].pos.x == pos.x)
			{
				count++;
			}
		}
		return count;
	}
	public bool checkVecX(Vector2 pos)
	{
		for(int i = 0; i < vecX.Count; i++)
		{
			if(vecX[i].x == pos.x)
			{
				return false;
			}
		}
		return true;
	}
	

	void SetupData()
	{
		//DataManager.Instance.SaveData("data.json", test);
	}
}
