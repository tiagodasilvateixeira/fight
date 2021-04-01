using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class HealthBarController : MonoBehaviour
    {
        readonly float OriginalMaskWidth = 400f;
        Mask Mask
        {
            get
            {
                return gameObject.GetComponent<Mask>();
            }
        }

        private void Start()
        {
            SetInitialMaskWidth();
        }

        public void SetHealthValue(float value)
        {
            Mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, OriginalMaskWidth * value);
        }

        public void SetInitialMaskWidth()
        {
            Mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, OriginalMaskWidth);
        }
    }
}