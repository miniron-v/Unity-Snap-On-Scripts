using UnityEngine;
using UnityEngine.Events;

public class HighlighterHandler : MonoBehaviour
{
    [HideInInspector] 
    public UnityEvent _onHighlight;
    [HideInInspector] 
    public UnityEvent _onUnhighlight;
    [HideInInspector]
    public UnityEvent _onDefaultState;

    [SerializeField] private HighlighterToggleGroup _toggleGroup;
    //[HideInInspector]
    public int _highlightIndex = -1;

    [SerializeField] private bool _isClicked = false;

    private void Awake()
    {
        if(_toggleGroup != null)
        {
            _toggleGroup.AddHighlighterHandler(this);
        }
    }

    public void OnMouseEnter()
    {
        Debug.Log("Entered!");

        if(_isClicked) return;

        _onHighlight.Invoke();

        if (_toggleGroup != null)
        {
            _toggleGroup.SetCurrentHighlightIndex(_highlightIndex);
        }
    }

    public void OnMouseExit()
    {
        if (_isClicked) return;

        _onUnhighlight.Invoke();

        if (_toggleGroup != null)
        {
            _toggleGroup.ClearCurrentHighlightIndex(_highlightIndex);
        }
    }

    public void SetClicked(bool isClicked)
    {
        _isClicked = isClicked;
    }

    public void SetHighlightIndex(int index)
    {
        _highlightIndex = index;
    }
}
