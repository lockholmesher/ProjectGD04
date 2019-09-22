
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
{
    private Transform parent;
    private Vector3 localScaleOld;
    private void Start()
    {
        parent = this.transform.parent;
        localScaleOld = this.transform.localScale;
    }
    UnityEvent ClickEvent = new UnityEvent();

    public void OnPointerUp(PointerEventData data)
    {
        //transform.localScale = Vector3.one;
        transform.localScale = localScaleOld;
    }

    public void OnPointerDown(PointerEventData data)
    {
        //transform.localScale = Vector3.one * 1.2f;
        //transform.localScale = localScaleOld * 1.2f;
        //TestColor.Instance.ClickDrawnColor(data.position);
        //Debug.Log(GetComponent<RawImage>().texture.width);
        //TestColor.Instance.DisplayCountColor((int)data.position.x, (int)data.position.y);
    }

    public void OnPointerClick(PointerEventData data)
    {
        ClickEvent.Invoke();
        if(gameObject.name == "SkeletonGraphic(bird)")
        {
            gameObject.SetActive(false);
        }
    }

    public void SetUpEvent(UnityAction action)
    {
        ClickEvent.RemoveAllListeners();
        ClickEvent.AddListener(action);
    }

    public void ReturnParent()
    {
        this.transform.parent = parent;
    }

    public void ClearEvent()
    {
        ClickEvent.RemoveAllListeners();
    }
}
