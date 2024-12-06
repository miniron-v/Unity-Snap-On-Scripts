using UnityEngine;

public class FrontUIHighlighter : HoverUIHighlighter
{
    [SerializeField] private int _originSiblingIndex;

    protected override void Awake()
    {
        base.Awake();

        _originSiblingIndex = transform.GetSiblingIndex();
    }

    protected override void Highlight()
    {
        transform.SetAsLastSibling();
    }

    protected override void Unhighlight()
    {
        transform.SetSiblingIndex(_originSiblingIndex);
    }

    protected override void DefaultState()
    {
        Unhighlight();
    }
}
