using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickController : MonoBehaviour
{
    private PlayerInput m_playerInput;
    private InputAction m_pressAction;
    private Camera m_camera;

    private void Awake()
    {
        m_playerInput = GetComponent<PlayerInput>();
        m_pressAction = m_playerInput.actions.FindAction("IA_Press");
        m_camera = Camera.main;
    }

    private void OnEnable()
    {
        m_pressAction.performed += TouchPressed;
    }
    
    private void OnDisabled()
    {
        m_pressAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        Vector3 position = m_camera.ScreenToWorldPoint(m_pressAction.ReadValue<Vector2>());
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.gameObject.name);
        }


    }

}
