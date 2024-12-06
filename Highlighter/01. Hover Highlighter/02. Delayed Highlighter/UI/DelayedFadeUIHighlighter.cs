using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

// 호버링 시 일정 시간 후 이미지가 Fade되는 하이라이트 효과
public class DelayedFadeUIHighlighter : DelayedHoverUIHighlighter
{
    [Header("Fade Image")]
    [SerializeField] private Image _hoverImage;

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

    protected override void Awake()
    {
        base.Awake();

        _hoverImage.color = new Color(1, 1, 1, 0);
    }

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
        _hoverImage.DOFade(_exitFadeValue / 255f, _defaultFadeTime).SetEase(Ease.Linear);
    }
}
