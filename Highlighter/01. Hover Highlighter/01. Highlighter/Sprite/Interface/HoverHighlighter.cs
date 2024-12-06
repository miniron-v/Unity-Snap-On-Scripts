using UnityEngine;

[RequireComponent(typeof(HighlighterHandler))]
public abstract class HoverHighlighter : MonoBehaviour
{
    protected HighlighterHandler _highlighterHandler;

    protected virtual void Awake()
    {
        _highlighterHandler = GetComponent<HighlighterHandler>();

        _highlighterHandler._onHighlight.AddListener(Highlight);
        _highlighterHandler._onUnhighlight.AddListener(Unhighlight);
        _highlighterHandler._onDefaultState.AddListener(DefaultState);
    }

    protected void Start()
    {
        DefaultState();
    }

    protected abstract void Highlight();
    protected abstract void Unhighlight();
    protected abstract void DefaultState();
}
