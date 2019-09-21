using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class DataManager : SingletionMonoBehaviour<DataManager>
{
	public DataGame data;
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
	public void SaveData(string path, Texture2D datasave )
	{
		DataGame save = new DataGame { colorTexture = datasave };
		string json = JsonUtility.ToJson(save);
		File.WriteAllText(Application.dataPath + "/Resources/" + path, json);

	}
}
[SerializeField]
public class DataGame
{
	public Texture2D colorTexture;
	
}