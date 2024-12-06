using UnityEngine;

public class FrontHighlighter : HoverHighlighter
{
    [Header("Sprite")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Order")]
    [SerializeField] private int _highlightOrder;
    [SerializeField] private int _unhighlightOrder;
    [SerializeField] private int _defaultOrder;

    protected override void Highlight()
    {
        spriteRenderer.sortingOrder = _highlightOrder;
    }

    protected override void Unhighlight()
    {
        spriteRenderer.sortingOrder = _unhighlightOrder;
    }

    protected override void DefaultState()
    {
        spriteRenderer.sortingOrder = _defaultOrder;
    }
}
