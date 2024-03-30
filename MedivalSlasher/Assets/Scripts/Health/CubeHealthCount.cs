using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeHealthCount : MonoBehaviour
{
    public TextMeshProUGUI text;
    TownCentreHealth health;
    public void SetHealthValue()
    {
        text.text = $"{health}";
    }

}
