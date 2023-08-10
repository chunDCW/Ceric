using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FirstUI : MonoBehaviour
{
    private void OnEnable()
    {
        {
            UIDocument ui = GetComponent<UIDocument>();
            VisualElement root = ui.rootVisualElement;

            Button button = root.Q<Button>("indvRingButton");
            button.RegisterCallback<ClickEvent>(elem => button.style.backgroundColor = Color.red);
        }
    }
}
