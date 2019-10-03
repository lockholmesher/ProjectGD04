using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
	Vector3 touchStart;
	public float zoomOutMin = 1;
	public float zoomOutMax = 8;

	Vector3 touchDown;

	Vector3 posCameraUPdate;

	Vector3 posBegin;

	public void Start()
	{
		
	}
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			touchDown = Camera.main.transform.position;
			posBegin = Input.mousePosition;
		}
		if (Input.touchCount == 2)
		{
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

			float difference = currentMagnitude - prevMagnitude;

			zoom(difference * 0.01f);
		}
		else if (Input.GetMouseButton(0))
		{
			if(posBegin.y > 100)
			{
				float realWidth = Screen.width / 100f;
				float realHeight = Screen.height / 100f;

				Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);

				posCameraUPdate = Camera.main.transform.position;

				if (posCameraUPdate.x + direction.x < 15f && posCameraUPdate.x + direction.x > -15f && posCameraUPdate.y + direction.y > -9 && posCameraUPdate.y + direction.y < 9f)
				{
					Camera.main.transform.position += direction;
				}
			}
			


		}
		if (Input.GetMouseButtonUp(0))
		{
			Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (touchPos.x <= transform.position.x + 5f && touchPos.x >= transform.position.x - 5f &&
				touchPos.y <= transform.position.y + 5f && touchPos.y >= transform.position.y - 5f)
			{
				if (touchDown == posCameraUPdate)
				{
					SetColorTexture(touchPos);
				}
			}
			
			
			
		}

		zoom(Input.GetAxis("Mouse ScrollWheel"));
	}
	public void SetColorTexture(Vector2 pos)
	{
		Debug.Log(pos);
		ColorController.Instance.Spawn(new Vector2((pos.x + 5) * 50, (pos.y + 5) * 50));
	}

	public	void zoom(float increment)
	{
		Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
	}


}
