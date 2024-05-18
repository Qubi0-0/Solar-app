using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField]
    public string planetName;

    public void Show()
    {
        PlanetInfoDisplay.Show(this);
    }

    public void Hide()
    {
        PlanetInfoDisplay.Hide();
    }
}
