using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private PlayerInputs inputs;

    private void Awake()
    {
        inputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Moving.performed += Moving;
    }

    private void OnDisable()
    {
        inputs.Disable();
        inputs.Player.Moving.performed -= Moving;
    }

    private void Moving(InputAction.CallbackContext context)
    {
        Vector2 screenCoordinates = inputs.Player.Moving.ReadValue<Vector2>();
        Vector3 worldCoordinates = Camera.main.ScreenToWorldPoint(screenCoordinates); 
        transform.position = new Vector3(worldCoordinates.x, transform.position.y, Camera.main.nearClipPlane);  
        worldCoordinates.z = 0;
    }
}
