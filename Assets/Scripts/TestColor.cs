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
	Dictionary<int, List<Vector2>> listRally = new Dictionary<int, List<Vector2>>();
    int count = 0;
    public List<ListLock> locks = new List<ListLock>();
	void Start()
    {
        //var originalColor =	DataManager.Instance.LoadData("data.json");

        //if (originalColor == null)
        //{
        //	SetupData();
        //}

        //LoadDataDefault("datadefault.json");

        //for( int i = 0; i < 327; i++)
        //{
        //	for( int j = 0; j < 460; j++)
        //	{
        //		if (test.GetPixel(i, j).r == 1 && test.GetPixel(i, j).g == 1 && test.GetPixel(i, j).b == 1)
        //		{
        //			test.SetPixel(i, j, Color.black);
        //		}
        //		else
        //		{
        //			test.SetPixel(i, j, Color.white);
        //		}
        //		//test.SetPixel(i, j, Color.white);

        //	}
        //}
        //test.Apply();

        Debug.Log("Total Color different in list " + GetListColorInTexture(test.GetPixels()).Count);
        // list mau khac nhau
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
        }
        //lay loang 1 mau bat ky trong list

        CreateListLock();
        
	}
	public void CreateListLock()
	{
		
		for( int i = 0; i < 300; i++)
		{
			for( int j = 0; j < 300; j++)
			{
				locks.Add(new ListLock(0, new Vector2(i, j)));
			}
		}
	}
	List<Color> list = new List<Color>();
	public List<Color> GetListColorInTexture(Color[] colors)
	{
		for(int i = 0; i < colors.Length;i++)
		{
			if(list.Count == 0)
			{
				list.Add(colors[i]);
			}
			else
			{
				if(!CheckColor(colors[i]))
				{
					list.Add(colors[i]);
				}
			}
		}

		return list;
	}

	public bool CheckColor(Color color)
	{
		for(int i = 0; i < list.Count; i++)
		{
			if( list[i] == color)
			{
				return true;
			}
		}
		return false;
	}

    public void DisplayCountColor(int x , int y)
    {
        algorithm(x, y);

        Debug.Log(count);
        count = 0;
    }
	
	// alogrithm
	void algorithm(int row, int col)
	{
		int i, j;
		if (test.GetPixel(row, col) == list[2])// set mau bat ky trong list
		{
            ChangeValueListLock(row, col); 
            // Đánh dấu ô đang xét đã được mở
            // Nếu ô đang xét gtri == 0
            // Xét các ô xung quanh
            for (i = -1; i < 2; i++)
			{
				for (j = -1; j < 2; j++)
				{
					if (i != 0 || j != 0)
					{
						if (row + i >= 0 && row + i <= 299 && col + j >= 0 && col + j <= 299)
						{ // Nếu ô nằm trong khoảng kt
							if (CheckUnlock(row +i , col +j) == false)
								// Nếu ô chưa được check
								algorithm(row + i, col + j );
						}
					}
				}
			}
		}
	}
	public bool CheckUnlock(int x , int y)
	{
		for(int i = 0; i < locks.Count; i++)
		{
			if((int)locks[i].posi.x == x && (int)locks[i].posi.y == y )
            {
                if(locks[i].value == 1)
                {

                    return true;
                }
            }
			
		}
		return false;
	}
	public void ChangeValueListLock(int x , int y)
	{
		for( int i = 0; i < locks.Count; i++)
		{
			if( (int)locks[i].posi.x == x && (int)locks[i].posi.y == y)
			{
				locks[i].value = 1;
                count++;
            }
		}
	}
	public void LoadDataDefault(string pathData)
	{
		var data = DataManager.Instance.LoadData(pathData);
		if(data == null)
		{
			ClearColor();
			return;
		}
		SetDataDefault(data.colorTexture);
		
	}

	public void SetDataDefault(Texture2D color)
	{
		for( int i = 0; i < 512; i++)
		{
			for(int j = 0; j < 512; j++)
			{
				test.SetPixel(i, j, color.GetPixel(i, j));
			}
		}
	}
	public void ClickDrawnColor(Vector2 position)
	{
		var color = DataManager.Instance.LoadData("data.json");
		
		if (position.x < 512 && position.y < 512)
		{
			Color color_ = color.colorTexture.GetPixel((int)position.x, (int)position.y);
			Debug.Log(color_);
			var lis = GetListPosColorDefault(color_, color.colorTexture);
			for( int i = 0; i < lis.Count; i++)
			{
				test.SetPixel((int)lis[i].x, (int)lis[i].y, color_);
			}

		}
		test.Apply();
		DataManager.Instance.SaveData("datadefault.json", test);
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
	public void ClearColor()
	{
		for (int i = 0; i < 512; i++)
		{
			for (int j = 0; j < 512; j++)
			{

				//Color color = ((test.GetPixel(i, j).r & test.GetPixel(i, j).g) != 0 ? Color.white : Color.red);
				test.SetPixel(i, j, Color.white);

			}
		}
		test.Apply();
	}

	void SetupData()
	{
		DataManager.Instance.SaveData("data.json", test);
	}
}
[SerializeField]
public class ListLock
{
	public	int value;
	public Vector2 posi;
	public ListLock(int value_, Vector2 pos)
	{
		value = value_;
		posi = pos;
	}
};