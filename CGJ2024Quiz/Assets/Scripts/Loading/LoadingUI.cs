using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _transitionTime;
    [SerializeField] private float _backgroundTargetAlpha = 0.3f;
    
    [Header("References")]
    [SerializeField] private Image _background;
    [SerializeField] private RectTransform _rotatingIcon;
    private Color _backgroundColor;

    private void Awake()
    {
        _backgroundColor = _background.color;
        SetActiveVisuals(false);

        Show();
    }
    
    public void Show()
    {
        SetActiveVisuals(true);
        SetBackgroundAlpha(0);
        LeanTween.value(0, 1, _transitionTime).
            setOnUpdate(SetFadeValue);
    }

    public void Hide()
    {
        LeanTween.value(1, 0, _transitionTime).
            setOnUpdate(SetFadeValue).
            setOnComplete(context => SetActiveVisuals(false));
    }

    private void SetFadeValue(float value)
    {
        SetBackgroundAlpha(value * _backgroundTargetAlpha);
        _rotatingIcon.localScale = value * Vector3.one;
    }

    private void SetBackgroundAlpha(float alpha)
    {
        _backgroundColor.a = alpha;
        _background.color = _backgroundColor;
    }

    private void SetActiveVisuals(bool value)
    {
        _background.gameObject.SetActive(value);
        _rotatingIcon.gameObject.SetActive(value);
    }
}