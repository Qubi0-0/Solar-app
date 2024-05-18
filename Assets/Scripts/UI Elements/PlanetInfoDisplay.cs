using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class PlanetInfoDisplay : MonoBehaviour
{
    private static PlanetInfoDisplay instance;

    private Canvas canvas;

    #region Descriptions

    [SerializeField]
    private TMP_Text planetNameDisplay;
    [SerializeField]
    private TMP_Text diameterDescription;
    [SerializeField]
    private TMP_Text temperatureDescription;
    [SerializeField]
    private TMP_Text moonsDescription;
    [SerializeField]
    private TMP_Text trivia;
    #endregion

    private void Awake()
    {
        canvas = gameObject.GetComponent<Canvas>();
        instance = this;
        gameObject.SetActive(false);
    }

    public static void Show(Planet planet)
    {
        instance.gameObject.SetActive(true);
        Dictionary<string, string> planetData = new Dictionary<string, string>();
        PlanetInfoReader.ReadPlanetData(planet.planetName, out planetData);
        UpdateText(planetData);
    }

    private static void UpdateText(Dictionary<string, string> planetData)
    {
        string textData;
        planetData.TryGetValue("Nazwa", out textData);
        instance.planetNameDisplay.SetText(textData);

        planetData.TryGetValue("Średnica", out textData);
        instance.diameterDescription.SetText(textData);

        planetData.TryGetValue("Temperatura", out textData);
        instance.temperatureDescription.SetText(textData);

        planetData.TryGetValue("Księżyce", out textData);
        instance.moonsDescription.SetText(textData);

        planetData.TryGetValue("Ciekawostki", out textData);
        instance.trivia.SetText(textData);
    }

    public static void Hide() 
    {
        instance.gameObject.SetActive(false);
    }
}
