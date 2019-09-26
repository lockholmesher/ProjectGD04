using UnityEngine;
using System.Collections;

public abstract class SingletionMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour {

	private static  T instance;


	public static T Instance
	{
		get
		{
			if (instance==null)
			{
				instance = GameObject.FindObjectOfType<T> ();
			}
			return instance;
		}
	}

	void OnDestroy()
	{
		instance = null;
	}
}
