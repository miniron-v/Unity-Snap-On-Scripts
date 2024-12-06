using DG.Tweening;
using UnityEngine;

public class FadeHighlighter : HoverHighlighter
{
    [Header("Fade Image")]
    [SerializeField] private SpriteRenderer _hoverImage;

    [Header("Fade Time")]
    [SerializeField] private float _enterFadeTime = 0.4f;
    [SerializeField] private float _exitFadeTime = 0.4f;
    [SerializeField] private float _defaultFadeTime = 0.4f;

    [Header("Fade Value")]
    [Tooltip("Set a value between 0 and 255.")]
    [SerializeField] private int _enterFadeValue = 255;
    [Tooltip("Set a value between 0 and 255.")]
    [SerializeField] private int _exitFadeValue = 0;
    [Tooltip("Set a value between 0 and 255.")]
    [SerializeField] private int _defaultFadeValue = 0;

    protected override void Highlight()
    {
        _hoverImage.DOFade(_enterFadeValue / 255f, _enterFadeTime).SetEase(Ease.Linear);
    }

    protected override void Unhighlight()
    {
        _hoverImage.DOFade(_exitFadeValue / 255f, _exitFadeTime).SetEase(Ease.Linear);
    }

    protected override void DefaultState()
    {
        _hoverImage.DOFade(_defaultFadeValue / 255f, _defaultFadeTime).SetEase(Ease.Linear);
    }
}
