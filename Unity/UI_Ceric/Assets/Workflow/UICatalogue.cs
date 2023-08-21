using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class UICatalogue : MonoBehaviour
{
    Button ringButton;
    Button userButton;
    Button catalogueButton;
    Button giftboxButton;
    Button settingsButton;

    private void OnEnable()
    {
        UIDocument ui = GetComponent<UIDocument>();
        VisualElement root = ui.rootVisualElement;

        ringButton = root.Q<Button>("ringButton");
        ringButton.clicked += OnRingButtonClicked;

        userButton = root.Q<Button>("userButton");
        userButton.clicked += OnUserButtonClicked;

        catalogueButton = root.Q<Button>("catalogueButton");
        catalogueButton.clicked += OnCatalogueButtonClicked;

        giftboxButton = root.Q<Button>("giftboxButton");
        giftboxButton.clicked += OnGiftboxButtonClicked;

        settingsButton = root.Q<Button>("settingsButton");
        settingsButton.clicked += OnSettingsButtonClicked;

    }

    void OnRingButtonClicked()
    {
        ringButton.style.scale = new Scale(new Vector3(0.9f,0.9f,1.0f));
        Debug.Log("ringButton is clicked");

        SceneManager.LoadScene("ring3DViewer", LoadSceneMode.Single);
    }

    void OnUserButtonClicked()
    {
        userButton.style.scale = new Scale(new Vector3(0.9f, 0.9f, 1.0f));
        Debug.Log("userButton is clicked");
    }

    void OnCatalogueButtonClicked()
    {
        catalogueButton.style.scale = new Scale(new Vector3(0.9f, 0.9f, 1.0f));
        Debug.Log("catalogueButton is clicked");

        SceneManager.LoadScene("catalogue", LoadSceneMode.Single);
    }

        void OnGiftboxButtonClicked()
    {
        giftboxButton.style.scale = new Scale(new Vector3(0.9f, 0.9f, 1.0f));
        Debug.Log("giftboxButton is clicked");
    }

    void OnSettingsButtonClicked()
    {
        settingsButton.style.scale = new Scale(new Vector3(0.9f, 0.9f, 1.0f));
        Debug.Log("settingsButton is clicked");
    }
}