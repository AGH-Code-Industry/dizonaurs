using System;
using System.Collections;
using System.Collections.Generic;
using EggSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoostIndicator : MonoBehaviour
{
    public TextMeshProUGUI indicatorText;
    public Image arrowImage;
    public Sprite UpArrow;
    public Sprite UpArrow2;
    public Sprite DownArrow;

    private void Update()
    {
        var value = EggStatusManager.Instance.CurrentGrowthRaw;
        var sign = "+";
        arrowImage.gameObject.SetActive(true);
        if (value < 0)
        {
            sign = String.Empty;
            arrowImage.sprite = DownArrow;
        }
        else if(value == 1)
        {
            arrowImage.sprite = UpArrow;
        }else if (value > 1)
        {
            arrowImage.sprite = UpArrow2;
        }
        else
        {
            arrowImage.sprite = null;
            arrowImage.gameObject.SetActive(false);
        }
        indicatorText.SetText(sign + value);
    }
}
