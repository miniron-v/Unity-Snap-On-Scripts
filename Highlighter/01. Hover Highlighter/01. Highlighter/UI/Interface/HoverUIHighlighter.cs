using UnityEngine;

[RequireComponent(typeof(UIHighlighterHandler))]
public abstract class HoverUIHighlighter : MonoBehaviour
{
    protected UIHighlighterHandler _uiHighlighterHandler;

    protected virtual void Awake()
    {
        _uiHighlighterHandler = GetComponent<UIHighlighterHandler>();

        _uiHighlighterHandler._onHighlight.AddListener(Highlight);
        _uiHighlighterHandler._onUnhighlight.AddListener(Unhighlight);
        _uiHighlighterHandler._onDefaultState.AddListener(DefaultState);
    }

    protected void Start()
    {
        DefaultState();
    }

    protected abstract void Highlight();
    protected abstract void Unhighlight();
    protected abstract void DefaultState();
}
