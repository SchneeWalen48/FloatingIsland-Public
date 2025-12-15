using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEditor;

public class BtnType2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   
    public Transform buttonScale;
    Vector3 defaultScale;

    public void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.1f;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}
