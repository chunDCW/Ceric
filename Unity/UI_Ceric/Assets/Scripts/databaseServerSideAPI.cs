using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;


[System.Serializable]
public class rawJewelleryData
{
    public string id;
    public string ringButtonImg;
    public string meshFile;
    public string category;
    public string style;
    public string description;
    public int centreStoneQty;
    public string centreStoneCut;
    public int sideStoneQty;
    public string sideStoneCut;
    public int metalQty;
}

[System.Serializable]
public class rawJewelleryDataList
{
    public List<rawJewelleryData> jewelleryCollection;
}

public class databaseServerSideAPI : MonoBehaviour
{
    private string apiUrl = "http://localhost:3000/api/data";
    public VisualTreeAsset ringButtonTemplate;
    public StyleSheet ringButtonStyles;
    public UIDocument ringButtonUI;

    private void Start()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        //ringButtonUI = GetComponent<UIDocument>();
        VisualElement root = ringButtonUI.rootVisualElement;
        root.styleSheets.Add(ringButtonStyles);
        VisualElement catalogueContainerRingButtons = root.Q<VisualElement>("catalogueContainerRingButtons");

        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            // Debug.Log("Data received: " + request.downloadHandler.text);

            // Process the JSON data and use it in your Unity project
            string json = "{\"jewelleryCollection\":" + request.downloadHandler.text + "}";
            rawJewelleryDataList parsedJewelleryDataList = JsonUtility.FromJson<rawJewelleryDataList>(json);

            // Use the data in Unity
            foreach (rawJewelleryData jewellery in parsedJewelleryDataList.jewelleryCollection)
            {
                Debug.Log("totalJewellery: " + parsedJewelleryDataList.jewelleryCollection.Count + ", id: " + jewellery.id + ", ringButtonImg: " + jewellery.ringButtonImg + ", meshFile: " + jewellery.meshFile);

                VisualElement newRingButton = ringButtonTemplate.Instantiate();
                //newRingButton.Q<Button>().text = jewellery.id;

                string id = jewellery.id;
                newRingButton.Q<Button>().RegisterCallback<ClickEvent>(e => OnRingButtonClicked(id));
                root.Add(newRingButton);
            }
        }
    }

    private void OnRingButtonClicked(string id)
    {
        Debug.Log(id + " button clicked");
    }

}