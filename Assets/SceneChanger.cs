using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Zmienna publiczna do podpięcia nazwy sceny w Inspektorze
    public string sceneName;

    // Metoda do zmiany sceny
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
