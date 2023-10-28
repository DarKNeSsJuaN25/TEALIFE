using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonText : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI textMeshPro;

    public void SetButtom(string textMeshPro2)
    {
        textMeshPro.text = textMeshPro2;
    }
}
