using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuTextAnimation : MonoBehaviour
{
    private TextMeshPro text;
    private Color desiredColor;

    private Material textShader;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        desiredColor = new Color(0, 0, 0, 0);
        text.fontSharedMaterial.SetColor("_UnderlayColor", desiredColor);
        StartCoroutine(Commons.DelayedAction(LateStart, 3));
    }

    void LateStart() {
        desiredColor = new Color(0, 0, 0, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Color old = text.fontSharedMaterial.GetColor("_UnderlayColor");
        Color color = Color.Lerp(old, desiredColor, 0.01f);
        text.fontSharedMaterial.SetColor("_UnderlayColor", color);
    }
}
