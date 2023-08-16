using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{

    Button ringButton;

    private void OnEnable()
    {

        UIDocument ui = GetComponent<UIDocument>();
        VisualElement root = ui.rootVisualElement;

        ringButton = root.Q<Button>("ringButton");
        ringButton.clicked += OnButtonClicked;
    }

    void OnButtonClicked()
    {
        Debug.Log("ringButton is clicked");

        SceneManager.LoadScene("ring3DViewer", LoadSceneMode.Single);

    }
}
