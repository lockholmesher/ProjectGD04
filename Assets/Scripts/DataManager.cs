using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataManager : SingletionMonoBehaviour<DataManager>
{
	[SerializeField]
	protected DataGame data;

	private List<Vector2> listNumber;
	public DataGame GetData()
	{
		data = new DataGame();
		return data;
	}
	public DataGame LoadData(string path)
	{
		if (!File.Exists(Application.dataPath + "/Resources/" + path))
		{
			FileStream file = File.Create(Application.dataPath + "/Resources/" + path);
			file.Close();
		}
		else
		{
			var data_ = File.ReadAllText(Application.dataPath + "/Resources/" + path);
			data = JsonUtility.FromJson<DataGame>(data_);

			return data;
		}
		return null;
	}
	public void SaveData(string path, Dictionary<int, List<ColorTex>> datasave)
	{
		Debug.Log("Save data" + datasave.Count);
		DataGame save = new DataGame() { lis = datasave };
		//save.ToString();
		
		//Debug.Log(test);
		string json = JsonUtility.ToJson(save);
		
		File.WriteAllText(Application.dataPath + "/Resources/" + path, json);

	}

	
}
[SerializeField]
public class DataGame
{
	public Dictionary<int, List<ColorTex>> lis = new Dictionary<int, List<ColorTex>>();
	public string SaveToJSON()
	{
		
		return JsonUtility.ToJson(this);
	}

}

[SerializeField]
public class ColorTex
{
	public Color colorTexture;
	public Vector2 pos;
	public ColorTex(Color color, Vector2 pos)
	{
		this.colorTexture = color;
		this.pos = pos;
	}
}
