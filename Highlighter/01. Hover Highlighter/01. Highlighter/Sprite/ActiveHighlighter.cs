using UnityEngine;

public class ActiveHighlighter : HoverHighlighter
{
    [Header("Active Object")]
    [SerializeField] private GameObject activeObject;
    [Header("Active bool")]
    [SerializeField] private bool highlightActive;
    [SerializeField] private bool unhighlightActive;
    [SerializeField] private bool defaultActive;

    protected override void Highlight()
    {
        activeObject.SetActive(highlightActive);
    }

    protected override void Unhighlight()
    {
        activeObject.SetActive(unhighlightActive);
    }

    protected override void DefaultState()
    {
        activeObject.SetActive(defaultActive);
    }
}
