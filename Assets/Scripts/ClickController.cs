using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickController : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction pressAction;
    private Camera mainCamera;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        pressAction = playerInput.actions.FindAction("IA_Press");
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        pressAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        pressAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        Vector2 screenPosition = pressAction.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Planet planet = hit.transform.GetComponent<Planet>();
            if (planet)
                planet.Show();
        }

    }

}
