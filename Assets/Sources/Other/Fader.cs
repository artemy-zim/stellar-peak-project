using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] private Graphic _graphic;

    [SerializeField] private float _delayInSeconds;
    [SerializeField] private float _durationInSeconds;
    [SerializeField] private float _targetAlpha;

    public void Launch()
    {
        StartCoroutine(FadeCoroutine());
    }

    private IEnumerator FadeCoroutine()
    {
        yield return new WaitForSeconds(_delayInSeconds);

        Color startColor = _graphic.color;
        Color targetColor = new(startColor.r, startColor.g, startColor.b, _targetAlpha);

        float elapsedTime = 0f;

        while (elapsedTime < _durationInSeconds)
        {
            elapsedTime += Time.deltaTime;
            _graphic.color = Color.Lerp(startColor, targetColor, elapsedTime / _durationInSeconds);
            yield return null;
        }

        _graphic.color = targetColor;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
