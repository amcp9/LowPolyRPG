using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour {
    private static Vector3 ON_DRAG_SCALE = new Vector3(1f, 1f, 1f);
    private static Vector3 NORMAL_SCALE = Vector3.one;
    private static Vector2 ON_DRAG_PIVOT = new Vector2(0.5f, 0.5f);
    private RectTransform mRectTransform;
    void Awake()
    {
        mRectTransform = GetComponent<RectTransform>();
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();

        UnityAction<BaseEventData> pointerdownClick = new UnityAction<BaseEventData>(OnPointerDown);
        EventTrigger.Entry myclickDown = new EventTrigger.Entry();
        myclickDown.eventID = EventTriggerType.PointerDown;
        myclickDown.callback.AddListener(pointerdownClick);
        trigger.triggers.Add(myclickDown);

        UnityAction<BaseEventData> pointerupClick = new UnityAction<BaseEventData>(OnPointerUp);
        EventTrigger.Entry myclickUp = new EventTrigger.Entry();
        myclickUp.eventID = EventTriggerType.PointerUp;
        myclickUp.callback.AddListener(pointerupClick);
        trigger.triggers.Add(myclickUp);

        UnityAction<BaseEventData> pointerdragClick = new UnityAction<BaseEventData>(OnDrag);
        EventTrigger.Entry myclickDrag = new EventTrigger.Entry();
        myclickDrag.eventID = EventTriggerType.Drag;
        myclickDrag.callback.AddListener(pointerdragClick);
        trigger.triggers.Add(myclickDrag);
    }
    public void OnPointerDown(BaseEventData data)
    {
        transform.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        mRectTransform.pivot = ON_DRAG_PIVOT;
        transform.position = Input.mousePosition;
        this.transform.localScale = ON_DRAG_SCALE;
    }
    public void OnPointerUp(BaseEventData data)
    {
        transform.GetComponent<Image>().color = new Color(0,0,0,0);
        this.transform.localScale = NORMAL_SCALE;
        transform.position = Input.mousePosition;
    }
    public void OnDrag(BaseEventData data)
    {
        transform.position = Input.mousePosition;
    }
}
