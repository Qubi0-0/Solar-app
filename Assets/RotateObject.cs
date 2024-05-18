using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public GameObject objectToRotate; // Istniejący obiekt, który chcemy obracać
    public float rotationTimeHours = 1.0f; // Czas obrotu w godzinach
    public float timeFactor = 1.0f; // Czynnik przyspieszenia obrotu
    public bool clockwise = false; // Kierunek obrotu (zgodnie z ruchem wskazówek zegara lub przeciwnie do ruchu wskazówek zegara)

    private float rotationSpeed; // Prędkość obrotu w stopniach na sekundę

    void Start()
    {
        // Obliczenie prędkości obrotu w stopniach na sekundę
        float rotationSpeedDegreesPerSecond = 360.0f / (rotationTimeHours * 3600.0f); // 3600 sekund w godzinie
        rotationSpeed = rotationSpeedDegreesPerSecond * timeFactor;

        // Odwrócenie prędkości obrotu, jeśli kierunek jest przeciwny do ruchu wskazówek zegara
        if (clockwise)
        {
            rotationSpeed *= -1.0f;
        }
    }

    void Update()
    {
        // Obrót obiektu wokół własnej osi
        if (objectToRotate != null)
        {
            objectToRotate.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
