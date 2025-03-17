using DG.Tweening;
using System;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private List<Sprite> _images;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _image;
    [SerializeField] private int _animationSpeed;
    [SerializeField] private int _degreeStep;

    private RectTransform _animatable;
    private int _currentImageIndex;
    private float _currentRotation;

    private readonly Subject<float> _progressSubject = new Subject<float>(); 
    private IDisposable _animationSubscription;

    private void Awake()
    {
        _animatable = _image.TryGetComponent(out RectTransform rectTransform)
            ? rectTransform
            : throw new ArgumentNullException(nameof(rectTransform));

        _currentImageIndex = 0;
        UpdateImage();

        _progressSubject
            .Subscribe(progress => _text.text = $"{(int)(progress * 100)}%")
            .AddTo(this);
    }

    private void UpdateImage()
    {
        _image.sprite = _images[_currentImageIndex];
    }

    public void UpdateProgress(float progress)
    {
        _progressSubject.OnNext(progress);
    }

    public void StartAnimation()
    {
        _animationSubscription = Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                _currentRotation += _animationSpeed * Time.deltaTime;
                _animatable.localRotation = Quaternion.Euler(0, _currentRotation, 0);

                if (_currentRotation >= _degreeStep)
                {
                    _currentRotation = 0;
                    _currentImageIndex = (_currentImageIndex + 1) % _images.Count;
                    UpdateImage();
                }
            })
            .AddTo(this);
    }

    private void OnDestroy()
    {
        _animationSubscription?.Dispose();
        _progressSubject?.Dispose();
    }
}
