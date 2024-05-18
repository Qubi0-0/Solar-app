using UnityEngine;

public class SolarSystemMovement : MonoBehaviour
{
    public float semiMajorAxisAU = 1.0f; // Półosi wielkiej orbity w jednostkach astronomicznych (AU)
    public float orbitalPeriodYears = 1.0f; // Okres orbitalny w latach
    public bool clockwise = false; // Kierunek ruchu orbitalnego (zgodnie z ruchem wskazówek zegara lub przeciwnie do ruchu wskazówek zegara)
    public float speedFactor = 1.0f; // Czynnik przyspieszenia
    public float scaleFactor = 1.0f; // Czynnik skalowania

    private float orbitalSpeed; // Prędkość kątowa orbitalna

    void Start()
    {
        // Obliczenie prędkości kątowej na podstawie trzeciego prawa Keplera
        orbitalSpeed = 360.0f / orbitalPeriodYears;

        // Jeśli kierunek ruchu jest przeciwny do ruchu wskazówek zegara, odwróć prędkość orbitalną
        if (clockwise)
        {
            orbitalSpeed *= -1.0f;
        }
    }

    void Update()
    {
        // Obliczenie kąta orbitalnego na podstawie czasu
        float orbitalAngle = Time.time * orbitalSpeed * speedFactor;

        // Obliczenie skalowanej półosi wielkiej orbity
        float scaledSemiMajorAxisAU = semiMajorAxisAU * scaleFactor;

        // Konwersja półosi wielkiej orbity z jednostek astronomicznych na jednostki Unity (np. metry)
        float semiMajorAxisMeters = scaledSemiMajorAxisAU * 149597870700.0f; // 1 AU = 149 597 870 700 metrów

        // Obliczenie położenia obiektu na orbicie względem środka sceny
        Vector3 centerPosition = Vector3.zero;
        float posX = Mathf.Cos(Mathf.Deg2Rad * orbitalAngle) * semiMajorAxisMeters + centerPosition.x;
        float posY = centerPosition.y;
        float posZ = Mathf.Sin(Mathf.Deg2Rad * orbitalAngle) * semiMajorAxisMeters + centerPosition.z;

        // Aktualizacja pozycji obiektu
        transform.position = new Vector3(posX, posY, posZ);
    }
}
