using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public static HealthBarController instance { get; private set; }
    float OriginalMaskWidth = 600f;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update() 
    {
        
    }

    public void SetHealthValue(float value, Image mask)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, mask.rectTransform.rect.width * value);
    }

    public void SetInitialMaskWidth(Image mask)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, OriginalMaskWidth);
    }
}
