using UnityEngine;
using UnityEngine.InputSystem;

public class Mover
{
    private readonly PlayerInput _input;
    private readonly float _gravity;
    private readonly float _movementSpeed;
    private readonly float _groundSnap;

    private Vector3 _direction;
    private Vector3 _velocity;

    public Vector3 Direction => _direction;

    public Mover(float movementSpeed, float gravity, float groundSnap, PlayerInput input)
    {
        _movementSpeed = movementSpeed;
        _input = input;
        _groundSnap = groundSnap;
        _gravity = gravity;

        _input.Player.Move.performed += OnMove;
        _input.Player.Move.canceled += OnMove;
    }

    ~Mover()
    {
        _input.Player.Move.performed -= OnMove;
        _input.Player.Move.canceled -= OnMove;
    }

    public Vector3 GetNextMovement(float deltaTime, bool isGrounded)
    {
        if (isGrounded)
            _velocity.y = _groundSnap;
        else
            _velocity.y -= _gravity * deltaTime;

        Vector3 movement = _movementSpeed * deltaTime * _direction;
        movement.y = _velocity.y * deltaTime;

        return movement;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        SetDirection(context.ReadValue<Vector2>());
    }

    private void SetDirection(Vector2 direction)
    {
        _direction = new Vector3(direction.x, 0, direction.y);
    }
}
