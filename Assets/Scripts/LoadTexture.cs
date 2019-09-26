using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.VectorGraphics;
using System.IO;
public class LoadTexture : MonoBehaviour
{
	public Texture2D drowTexture;

	public SpriteRenderer spriteRender;


	Texture2D texture;
	Rect rect;
    // Start is called before the first frame update
    void Start()
    {
		spriteRender.enabled = false;
		rect = spriteRender.sprite.rect;
		StartCoroutine(Load());
		


	}

    // Update is called once per frame
    IEnumerator Load()
	{
		WWW www = new WWW("http://pbncdn.tapque.com/paintbynumber/2200236.svg");
		yield return www;

		Debug.Log(www.texture.height);
		string svg = www.text;
		loadTexture2d(svg);
	}
	public void loadTexture2d(string svg)
	{
		var tessOptions = new VectorUtils.TessellationOptions()
		{
			StepDistance = 100.0f,
			MaxCordDeviation = 0.5f,
			MaxTanAngleDeviation = 0.1f,
			SamplingStepSize = 0.01f
		};
		var sceneInfo = SVGParser.ImportSVG(new StringReader(svg));
		var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);

		// Build a sprite with the tessellated geometry.
		var sprite = VectorUtils.BuildSprite(geoms, 100f, VectorUtils.Alignment.Center, Vector2.zero, 128, true);
		spriteRender.sprite = sprite;
		spriteRender.enabled = true;
		
		//CleareColorSvg(spriteRender);
	}
	public void CleareColorSvg( SpriteRenderer spriteRender_)
	{
		
		for(int i = 0; i < spriteRender_.sprite.texture.width; i++ )
		{
			for( int j = 0; j < spriteRender_.sprite.texture.height;i++)
			{
				var color = spriteRender_.sprite.texture.GetPixel(i, j);
				spriteRender_.sprite.texture.SetPixel(i, j, Color.white);
			}
		}
		spriteRender_.sprite.texture.Apply();
	}
}
