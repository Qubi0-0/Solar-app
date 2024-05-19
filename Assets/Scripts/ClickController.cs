using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickController : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction pressAction;
    private InputAction positionAction;
    private Camera mainCamera;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        pressAction = playerInput.actions.FindAction("IA_Press");
        positionAction = playerInput.actions.FindAction("IA_Position");
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (pressAction.WasPerformedThisFrame())
        {
            Vector2 position = positionAction.ReadValue<Vector2>();
            Ray ray = mainCamera.ScreenPointToRay(position);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Planet planet = hit.transform.GetComponent<Planet>();
                if (planet)
                    planet.Show();
            }
        }
    }

}
