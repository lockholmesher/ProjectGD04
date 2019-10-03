using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberTextController : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro  textNumber;
    void Start()
    {
        
    }

    public void SetUpData(Vector2 Pos, string text)
    {
		gameObject.transform.localPosition = Pos;
        textNumber.text = text;
    }
    public void OnHold()
    {
        Destroy(gameObject);
    }
}
