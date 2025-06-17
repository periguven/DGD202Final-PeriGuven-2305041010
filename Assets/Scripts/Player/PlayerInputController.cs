using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInputController : MonoBehaviour
{
    private PlayerInput inputActions;
    private PlayerMover playerMover;

    private void Awake()
    {
        inputActions = new PlayerInput();
        playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        inputActions.Gameplay.Enable();
    }

    private void OnDisable()
    {
        inputActions.Gameplay.Disable();
    }

    private void Update()
    {
        Vector2 input = inputActions.Gameplay.Move.ReadValue<Vector2>();
        playerMover.Move(input); 
    }
}