using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ToolTip : MonoBehaviour
{
    [SerializeField] private Text headerField;
    [SerializeField] private Text contentField;

    [SerializeField] private LayoutElement layoutElement;

    [SerializeField] private int maxCharacter;

    [SerializeField] private RectTransform rectTransform;

    public void SetText(string content, string header = "")
    {
        if (header == "") headerField.gameObject.SetActive(false);
        else {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }

        contentField.text = content;
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;
        layoutElement.enabled = (headerLength > maxCharacter || contentLength > maxCharacter) ? true : false;
    }

    private void Update() {
        Vector2 mousePosition = Input.mousePosition;
        
        float pivoX = mousePosition.x / Screen.width;
        float pivoY = mousePosition.y / Screen.height;

        rectTransform.pivot = new Vector2(pivoX, pivoY + 0.5f);
        
        transform.position = mousePosition;
    }
}
    
