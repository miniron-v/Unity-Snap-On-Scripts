using System.Collections;
using UnityEngine;

public abstract class DelayedHoverUIHighlighter : HoverUIHighlighter
{
    [Header("Delay Time")]
    [SerializeField] private float _enterDelayTime;
    [SerializeField] private float _exitDelayTime;
    [SerializeField] private float _defaultDelayTime;
    private Coroutine _coroutine;

    protected override void Awake()
    {
        _uiHighlighterHandler = GetComponent<UIHighlighterHandler>();

        _uiHighlighterHandler._onHighlight.AddListener(StartHighlightCoroutine);
        _uiHighlighterHandler._onUnhighlight.AddListener(StartUnhighlightCoroutine);
        _uiHighlighterHandler._onDefaultState.AddListener(StartDefaultCoroutine);
    }

    private void StartHighlightCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(HighlightCoroutine());
    }

    private void StartUnhighlightCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(UnhighlightCoroutine());
    }

    private void StartDefaultCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(DefaultCoroutine());
    }

    private IEnumerator HighlightCoroutine()
    {
        yield return new WaitForSeconds(_enterDelayTime);

        Highlight();
    }

    private IEnumerator UnhighlightCoroutine()
    {
        yield return new WaitForSeconds(_exitDelayTime);

        Unhighlight();
    }

    private IEnumerator DefaultCoroutine()
    {
        yield return new WaitForSeconds(_defaultDelayTime);

        DefaultState();
    }
}
