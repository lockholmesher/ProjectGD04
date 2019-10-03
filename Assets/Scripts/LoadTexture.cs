using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.VectorGraphics;
using UnityEngine.UI;
using System.IO;
public class LoadTexture : MonoBehaviour
{
	public Texture2D TexttureOld;

	[SerializeField]
	private Texture2D texture;
	


	[SerializeField]
	private Texture2D texLoad;


	
	
    void Start()
    {

		//StartCoroutine(Load());
		

	}
	public void CreateMesh()
	{
		Mesh mesh = new Mesh();
		Vector3[] vertical = new Vector3[4];
		Vector2[] uv = new Vector2[4];
		int[] triangle = new int[6];

		vertical[0] = new Vector3(0, 1);
		vertical[1] = new Vector3(0, 0);
		vertical[2] = new Vector3(1, 1);
		vertical[3] = new Vector3(1, 0);

		uv[0] = new Vector2(0, 1);
		uv[1] = new Vector2(1, 1);
		uv[2] = new Vector2(0, 0);
		uv[3] = new Vector2(1, 0);

		triangle[0] = 0;
		triangle[1] = 1;
		triangle[2] = 2;
		triangle[3] = 2;
		triangle[4] = 1;
		triangle[5] = 3;

		mesh.vertices = vertical;
		mesh.uv = uv;

		mesh.triangles = triangle;
		GetComponent<MeshFilter>().mesh = mesh;
	}

	// Update is called once per frame
	//IEnumerator Load()
	//{
	//	WWW www = new WWW("http://pbncdn.tapque.com/paintbynumber/2200236.svg");
	//	yield return www;
	//}
	//public void loadTexture2d(string svg)
	//{
	//	var tessOptions = new VectorUtils.TessellationOptions()
	//	{
	//		StepDistance = 100.0f,
	//		MaxCordDeviation = 0.5f,
	//		MaxTanAngleDeviation = 0.1f,
	//		SamplingStepSize = 0.01f
	//	};
	//	var sceneInfo = SVGParser.ImportSVG(new StringReader(svg));
	//	var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);

	//	// Build a sprite with the tessellated geometry.
	//	texAlas = VectorUtils.GenerateAtlasAndFillUVs(geoms, 128);
	//	Debug.Log(geoms.Count);
	//	//spriteRender.sprite = sprite;
	//	//spriteRender.enabled = true;

	//	//CleareColorSvg(spriteRender);
	//}
	//public void CleareColorSvg( SpriteRenderer spriteRender_)
	//{
		
	//	for(int i = 0; i < spriteRender_.sprite.texture.width; i++ )
	//	{
	//		for( int j = 0; j < spriteRender_.sprite.texture.height;i++)
	//		{
	//			var color = spriteRender_.sprite.texture.GetPixel(i, j);
	//			spriteRender_.sprite.texture.SetPixel(i, j, Color.white);
	//		}
	//	}
	//	spriteRender_.sprite.texture.Apply();
	//}
}
