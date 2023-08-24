using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEngine.SceneManagement;
using UnityEditor;
using Unity.VisualScripting;

public class UICatalogue : MonoBehaviour
{
    Button catalogueRingButton;
    //Button settingsButton;

    private void OnEnable()
    {
        UIDocument ui = GetComponent<UIDocument>();
        VisualElement root = ui.rootVisualElement;

        var catalogueRingButtonVisualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Templates/catalogueRingButton.uxml");
        //var templateCatalogueRingButton = catalogueRingButtonVisualTree.Q<Button>("catalogueRingButton");
        Debug.Log(catalogueRingButtonVisualTree.GetInstanceID());
        Debug.Log(catalogueRingButtonVisualTree.GetType());

        //settingsButton = root.Q<Button>("settingsButton");
        //settingsButton.clicked += OnSettingsButtonClicked;

        VisualElement catalogueContainerRingButtons = root.Q<VisualElement>("catalogueContainerRingButtons");
     
        for (int i = 0; i < 30; i++)
        {
            VisualElement catalogueRingButtonTemplate = catalogueRingButtonVisualTree.Instantiate();
            //set image
            //set ref no
            //set button to try it on page
            catalogueContainerRingButtons.Add(catalogueRingButtonTemplate);
        }

        catalogueRingButton = root.Q<Button>();
        catalogueRingButton.clicked += OnRingButtonClicked;

    }

    void OnRingButtonClicked()
    {
        catalogueRingButton.style.scale = new Scale(new Vector3(0.9f, 0.9f, 1.0f));
        Debug.Log("ringButton is clicked");

        SceneManager.LoadScene("ring3DViewer", LoadSceneMode.Single);
    }
    //void OnSettingsButtonClicked()
    //{
    //settingsButton.style.scale = new Scale(new Vector3(0.9f, 0.9f, 1.0f));
    //Debug.Log("settingsButton is clicked");
    //}
}