using DG.Tweening;
using UnityEngine;

public class DelayedScaleUIHighlighter : DelayedHoverUIHighlighter
{
    private RectTransform myRect;

    [Header("Scale Time")]
    [SerializeField] private float _enterScaleTime = 0.4f;
    [SerializeField] private float _exitScaleTime = 0.4f;
    [SerializeField] private float _defaultScaleTime = 0.4f;

    [Header("Scale Value")]
    [SerializeField] private Vector3 _highlightScale = new Vector3(1.1f, 1.1f, 1.1f);
    [SerializeField] private Vector3 _unhighlightScale = Vector3.one;
    [SerializeField] private Vector3 _defauleScale = Vector3.one;

    protected override void Awake()
    {
        base.Awake();

        myRect = GetComponent<RectTransform>();
    }

    protected override void Highlight()
    {
        myRect.DOScale(_highlightScale, _enterScaleTime).SetEase(Ease.Linear);
    }

    protected override void Unhighlight()
    {
        myRect.DOScale(_unhighlightScale, _exitScaleTime).SetEase(Ease.Linear);
    }

    protected override void DefaultState()
    {
        myRect.DOScale(_defauleScale, _defaultScaleTime).SetEase(Ease.Linear);
    }
}