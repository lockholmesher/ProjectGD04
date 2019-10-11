using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreen : Singleton<CameraScreen>
{
    [Header("Camra config")]
    public float cameraSizeReady		= 5.12f;
	public float cameraSizePlay		= 10.24f;

	public float cameraPositionReady	= -5.12f;
	public float cameraPositionPlay	= 0;

    [Header("Screen Shake config")]
	public float durationShake 		= 0.2f;
	public float amountShake 			= 0.3f;

    public static float screenWidth;
	public static float screenHeight;
    public static float WidthGame => 1080;
    public static float MaxHeight { get{ return CameraScreen.Instance.gameObject.transform.position.y + screenHeight * 0.5f; }}
    public static float MinHeight { get{ return CameraScreen.Instance.gameObject.transform.position.y - screenHeight * 0.5f; }}
    public static Vector3 Position => CameraScreen.Instance.transform.position;

    protected override void Awake()
    {
        base.Awake();
        screenHeight = 20.48f;
		screenWidth = screenHeight * Screen.width / Screen.height;
    }

    public void Ready(bool isAnimation)
    {
        // if(isAnimation)
        // {
        //     // iTween.MoveTo(gameObject, iTween.Hash("y", CAMERA_POSITION_PLAY, "time", 0.5f, "easetype", "easeOutSine"));
        //     float currentSize = Camera.main.orthographicSize;
        //     iTween.ValueTo(gameObject, iTween.Hash("from", currentSize, "to", CAMERA_SIZE_READY, "time", 0.5f, "easetype", "easeOutSine", "onupdate", "UpdateCameraSize", "oncomplete", "CompleteZoomCamera"));
        // }
        // else
        {
            transform.position = new Vector3(transform.position.x, cameraPositionReady, transform.position.z);
		    Camera.main.orthographicSize = cameraSizeReady;
        }

    }

    public void ZoomCamera() {
		iTween.MoveTo(gameObject, iTween.Hash("y", cameraPositionPlay, "time", 0.5f, "easetype", "easeOutSine"));
		iTween.ValueTo(gameObject, iTween.Hash("from", cameraSizeReady, "to", cameraSizePlay, "time", 0.5f, "easetype", "easeOutSine", "onupdate", "UpdateCameraSize", "oncomplete", "CompleteZoomCamera"));
	}
    
	private void UpdateCameraSize(float size) {
		Camera.main.orthographicSize = size;
	}

	private void CompleteZoomCamera() {

	}

    public static void Shake()
    {
        CameraScreen cam = CameraScreen.Instance;
        cam.StopCoroutine(cam.IEShake());
        cam.StartCoroutine(cam.IEShake());
    }

    IEnumerator IEShake()
    {
        float cooldown = 0;
        Vector3 initPos = Camera.main.transform.position;
        while(cooldown < durationShake)
        {
            float x = Random.Range(-1, 1) * amountShake * cooldown / durationShake;
            float y = Random.Range(-1, 1) * amountShake * cooldown / durationShake;
            Camera.main.transform.position = new Vector3(initPos.x + x, initPos.y + y , initPos.z);
            yield return new WaitForEndOfFrame();
            cooldown += Time.deltaTime;
        }
        Camera.main.transform.position = initPos;
    }

    public static Vector3 GetRealPosition(Vector3 input, bool fromBot)
    {
        float rate = input.x / (WidthGame * 0.5f);
        input.x = rate * Screen.width;
        if(fromBot)
        {
            input += new Vector3(Position.x, MinHeight, 0);
        }
        else
        {
            input += new Vector3(Position.x, Position.y, 0);
        }

        return input;
    }
}
