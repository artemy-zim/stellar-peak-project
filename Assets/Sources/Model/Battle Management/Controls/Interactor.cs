using System;
using UnityEngine.InputSystem;

public class Interactor
{
    private readonly PlayerInput _input;

    public event Action ActionButtonPressed;

    public Interactor(PlayerInput input)
    {
        _input = input;

        _input.Player.Interact.performed += OnInput;
    }

    ~Interactor()
    {
        _input.Player.Interact.performed -= OnInput;
    }

    private void OnInput(InputAction.CallbackContext _)
    {
        ActionButtonPressed?.Invoke();
    }
}
