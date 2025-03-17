using UnityEngine;

public class PlayerControlPresenter
{
    private readonly PlayerControlView _view;
    private readonly PlayerControl _control;

    public PlayerControlPresenter(PlayerControlView view, PlayerControl control)
    {
        _view = view;
        _control = control;

        _control.Interacted += _view.CallOnInteract;
        _control.Shot += ProcessShot;
    }

    ~PlayerControlPresenter()
    {
        _control.Interacted -= _view.CallOnInteract;
        _control.Shot -= ProcessShot;
    }

    public void Update(float deltaTime)
    {
        Vector3 movement = _control.GetMovement(deltaTime, _view.IsGrounded, _view.GetRotation());
        Quaternion rotation = _control.GetRotation(_view.transform.position);

        _view.SetMovement(movement);
        _view.SetRotation(rotation);
    }

    private void ProcessShot()
    {
        _control.Shoot(_view.GetShotPoint(), _view.GetRotation());
        _view.CallOnShoot();
    }
}
