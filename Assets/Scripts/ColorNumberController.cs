using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorNumberController : MonoBehaviour
{
	[SerializeField]
	private Text texNumberColor;

	[SerializeField]
	private UIButton btnClick;

	private int typeNumber;

    private BaseController BaseController;
    
    void Start()
    {
		btnClick.SetUpEvent(ClickNumberColor);
    }

	public void ClickNumberColor()
	{
        BaseController.Notify(BaseController.ClickNumberPaint, null, typeNumber);
	}
    
	public void SetUpData(int tex, Color textColor , BaseController baseController = null)
	{
        typeNumber = tex;
        texNumberColor.text = (tex + 1).ToString();
        texNumberColor.color = textColor;
        BaseController = baseController;
    }
}
