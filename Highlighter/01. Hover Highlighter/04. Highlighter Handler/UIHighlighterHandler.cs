using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIHighlighterHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] 
    public UnityEvent _onHighlight;
    [HideInInspector] 
    public UnityEvent _onUnhighlight;
    [HideInInspector]
    public UnityEvent _onDefaultState;

    [SerializeField] private UIHighlighterToggleGroup _toggleGroup;
    //[HideInInspector]
    public int _highlightIndex = -1;

    [SerializeField] private bool _isClicked = false;

    private void Awake()
    {
        if(_toggleGroup != null)
        {
            _toggleGroup.AddUIHighlighterHandler(this);
        }
    }

    private void Start()
    {
        _onDefaultState.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(_isClicked) return;

        if (_toggleGroup != null)
        {
            _toggleGroup.SetCurrentHighlightIndex(_highlightIndex);
        }

        _onHighlight.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
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
