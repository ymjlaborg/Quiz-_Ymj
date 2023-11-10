using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLang : MonoBehaviour
{
    public TextMeshProUGUI text;
    Button button;
    private void Start() {
        button = GetComponent<Button>();

        button.onClick.AddListener(() => {
            text.text = LanguageSingleton.instance.Langs[1].value[0];
        });
    }
}
