using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : SingletionMonoBehaviour<GUIController>
{
	private void OnGUI()
	{

	
		GUIStyle guiStyle = new GUIStyle();
		guiStyle.fontSize = 30;
		guiStyle.normal.textColor = Color.red;
		guiStyle.alignment = TextAnchor.MiddleCenter;

		GUI.Label(new Rect(Screen.width / 2, Screen.height * 0.1f, 300f, 100f), "2");
		
	}
}
