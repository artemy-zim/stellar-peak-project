using UniRx;
using UnityEngine;

public class PlayerAnimatorPresenter
{
    private readonly PlayerAnimator _animator;
    private readonly PlayerAnimatorView _view;

    private readonly CompositeDisposable _disposables = new();

    public PlayerAnimatorPresenter(PlayerAnimator animator, PlayerAnimatorView view)
    {
        _animator = animator;
        _view = view;

        _animator.AnimationDirection
            .Subscribe(SetAnimatorParameters)
            .AddTo(_disposables);
    }

    ~PlayerAnimatorPresenter()
    {
        _disposables.Dispose();
    }

    private void SetAnimatorParameters(Vector2 direction)
    {
        _view.UpdateView(direction);
    }
}
