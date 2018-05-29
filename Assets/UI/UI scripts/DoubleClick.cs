using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleClick : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    float lastClick = 0f;
    float interval = 0.4f;

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((lastClick + interval) > Time.time)
        {
            Debug.Log("single click");
        }
        else
        {
            lastClick = Time.time;
            Debug.Log("double click");
        }
    }
}
