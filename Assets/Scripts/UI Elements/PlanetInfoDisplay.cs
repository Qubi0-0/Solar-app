using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class PlanetInfoDisplay : MonoBehaviour
{
    private static PlanetInfoDisplay instance;

    private Canvas canvas;
    private CanvasGroup canvasGroup;

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

    private Volume volume;
    private Vignette effectVignette;
    private ColorAdjustments colorAdjustment;

    #region effectStrength
    [SerializeField]
    private float vignetteIntensityStrength = 0.412f;
    [SerializeField]
    private float colorAdjustmentStrength = -2;
    #endregion

    private void Awake()
    {
        canvas = gameObject.GetComponent<Canvas>();
        instance = this;
        canvasGroup = canvas.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;

        volume = gameObject.GetComponentInChildren<Volume>();

        volume.profile.TryGet<Vignette>(out effectVignette);
        volume.profile.TryGet<ColorAdjustments>(out colorAdjustment);

        effectVignette.intensity.value = 0;
        colorAdjustment.postExposure.value = 0;
        gameObject.SetActive(false);
    }

    public static void Show(Planet planet)
    {
        instance.gameObject.SetActive(true);
        instance.canvasGroup.DOFade(1, 1).SetEase(Ease.InOutSine);
        if (instance.effectVignette)
            DOTween.To(() => instance.effectVignette.intensity.value, x => instance.effectVignette.intensity.value = x, instance.vignetteIntensityStrength, 1);
        if (instance.colorAdjustment)
            DOTween.To(() => instance.colorAdjustment.postExposure.value, x => instance.colorAdjustment.postExposure.value = x, instance.colorAdjustmentStrength, 1);

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
        if (instance.effectVignette)
            DOTween.To(() => instance.effectVignette.intensity.value, x => instance.effectVignette.intensity.value = x, 0, 1);
        if (instance.colorAdjustment)
            DOTween.To(() => instance.colorAdjustment.postExposure.value, x => instance.colorAdjustment.postExposure.value = x, 0, 1);
        instance.canvasGroup.DOFade(0, 1).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            instance.gameObject.SetActive(false);
        });
    }
}