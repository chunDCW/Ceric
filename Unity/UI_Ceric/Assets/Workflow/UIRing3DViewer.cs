using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;
using UnityEditor;

public class UIRing3DViewer : MonoBehaviour
{
    Camera mainCamera;
    bool cameraMove = false;
    Vector3 cameraTargetPosition;

    Button catalogueButton;
    Button ARButton;

    Button customiseButton;
    VisualElement customiseMenuContainer;
    VisualElement customiseMenuMiddleContainer;
    VisualElement customiseMenuIndent;
    Boolean customiseButtonValue = false;
    ScrollView customiseMenuScroll;

    Button giftboxButton;
    Boolean giftboxButtonValue = false;

    Button mainMenuButton;
    VisualElement mainMenuContainer;
    Boolean mainMenuButtonValue = false;
    VisualElement mainMenuIndent;


    private void Awake()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //mainCamera.transform.position = new Vector3(0, 3, -12);
    }

    private void OnEnable()
    {
        UIDocument ui = GetComponent<UIDocument>();
        VisualElement root = ui.rootVisualElement;

        //catalogueButton
        catalogueButton = root.Q<Button>("catalogueButton");
        catalogueButton.clicked += OnCatalogueButtonClicked;


        //customiseButton
        customiseButton = root.Q<Button>("customiseButton");
        customiseMenuContainer = root.Q<VisualElement>("customiseMenuContainer");
        customiseMenuMiddleContainer = root.Q<VisualElement>("customiseMenuMiddleContainer");
        customiseMenuIndent = root.Q<VisualElement>("customiseMenuIndent");
        customiseMenuScroll = root.Q<ScrollView>("customiseMenuScroll");
        customiseButton.clicked += OnCustomiseButtonClicked;


        //mainMenuButton
        mainMenuButton = root.Q<Button>("mainMenuButton");
        mainMenuContainer = root.Q<VisualElement>("mainMenuContainer");
        mainMenuIndent = root.Q<VisualElement>("mainMenuIndent");
        mainMenuButton.clicked += OnMainMenuButtonClicked;


        //giftboxButton
        giftboxButton = root.Q<Button>("giftboxButton");
        giftboxButton.clicked += OnGiftboxButtonClicked;


        //ARButton
        ARButton = root.Q<Button>("ARButton");
    }

    private void Update()
    {
        float cameraSpeed = 20.0f;
        var step = cameraSpeed * Time.deltaTime;

        if (cameraMove == true && mainCamera.transform.position != cameraTargetPosition)
        {
            Debug.Log("Camera is transitioning");
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, cameraTargetPosition, cameraSpeed);
        }
        cameraMove = false;
    }

    void OnCatalogueButtonClicked()
    {
        catalogueButton.style.scale = new Scale(new Vector3(0.9f, 0.9f, 1.0f));
        Debug.Log("catalogueButton is clicked");

        SceneManager.LoadScene("catalogue", LoadSceneMode.Single);
    }

    void OnGiftboxButtonClicked()
    {
        //customiseButton.style.scale = new Scale(new Vector3(0.9f, 0.9f, 1.0f));

        if (giftboxButtonValue == false)
        {
            //add to giftbox
            giftboxButton.style.backgroundImage = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Art/Icons/NavIcon_GiftboxOn.png");
            giftboxButtonValue = true;
        }
        else
        {
            //minus from giftbox
            giftboxButton.style.backgroundImage = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Art/Icons/NavIcon_GiftboxOff.png");
            giftboxButtonValue = false;
        }

        Debug.Log("customiseButton is clicked");
    }

    void OnMainMenuButtonClicked()
    {

        ResetAllMenus();

        if (mainMenuButtonValue == false)
        {

            //portrait or landscape
            if (Screen.currentResolution.width <= Screen.currentResolution.height)
            {
                //portrait
                mainMenuContainer.style.width = Length.Percent(94);
                mainMenuContainer.style.height = Length.Percent(30);
                catalogueButton.style.opacity = 0;
                giftboxButton.style.opacity = 0;
            }
            else
            {
                //landscape
                mainMenuContainer.style.width = Length.Percent(31);
                mainMenuContainer.style.height = Length.Percent(70);
            }
            mainMenuIndent.style.opacity = 10;
            AllButtonValuesFalse();
            mainMenuButtonValue = true;
            //pan camera to accommodate menu
        }
        else
        {
            ResetAllMenus();
            AllButtonValuesFalse();
            //return camera to default position
        }

        Debug.Log("mainMenuButton is clicked");
        Debug.Log(Screen.currentResolution.width + " " + Screen.currentResolution.height);

    }

    void OnCustomiseButtonClicked()
    {

        ResetAllMenus();

        if (customiseButtonValue == false)
        {
            if (Screen.currentResolution.width <= Screen.currentResolution.height)
            {
                //portrait
                customiseMenuContainer.style.width = Length.Percent(94);
                customiseMenuContainer.style.height = Length.Percent(40);
                ARButton.style.opacity = 0;
            }
            else
            {
                //landscape
                customiseMenuContainer.style.width = Length.Percent(31);
                customiseMenuContainer.style.height = Length.Percent(94);
                mainMenuContainer.style.opacity = 0;
                cameraTargetPosition = new Vector3(-4, 3, -12);
                cameraMove = true;
            }
            //resize texts
            customiseMenuMiddleContainer.style.scale = new Vector2(1, 1);

            customiseMenuScroll.style.opacity = 100;
            customiseMenuIndent.style.opacity = 10;
            AllButtonValuesFalse();
            customiseButtonValue = true;
            //pan camera to accommodate menu
        }
        else
        {
            ResetAllMenus();
            AllButtonValuesFalse();
            //return camera to default position
        }

        Debug.Log("customiseButton is clicked");
        Debug.Log(Screen.currentResolution.width + " " + Screen.currentResolution.height);
    }

    void ResetAllMenus()
    {
        mainMenuContainer.style.width = 200;
        mainMenuContainer.style.height = 200;
        mainMenuContainer.style.opacity = 100;
        mainMenuIndent.style.opacity = 0;
        customiseMenuContainer.style.width = 200;
        customiseMenuContainer.style.height = 200;
        customiseMenuIndent.style.opacity = 0;
        customiseMenuScroll.style.opacity = 0;

        //resize texts
        customiseMenuMiddleContainer.style.scale = new Vector2(0, 0);

        ARButton.style.opacity = 100;
        catalogueButton.style.opacity = 100;
        giftboxButton.style.opacity = 100;
        cameraTargetPosition = new Vector3(0, 3, -12);
        cameraMove = true;

    }

    void AllButtonValuesFalse()
    {
        mainMenuButtonValue = false;
        customiseButtonValue = false;
    }


}
