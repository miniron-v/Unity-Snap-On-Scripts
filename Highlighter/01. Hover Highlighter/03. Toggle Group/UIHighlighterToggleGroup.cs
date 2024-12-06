using System.Collections.Generic;
using UnityEngine;

public class UIHighlighterToggleGroup : MonoBehaviour
{
    private List<UIHighlighterHandler> _uiHighlighterHandlers = new List<UIHighlighterHandler>();
    [SerializeField] private int _currentHighlightedIndex = -1;

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        for (int i = 0; i < _uiHighlighterHandlers.Count; i++)
        {
            _uiHighlighterHandlers[i].SetHighlightIndex(i);
        }
    }

    public void SetCurrentHighlightIndex(int selected)
    {
        _currentHighlightedIndex = selected;
        UpdateAllHighlighter(selected, true);
    }

    public void ClearCurrentHighlightIndex(int selected)
    {
        if (_currentHighlightedIndex != selected) return;

        _currentHighlightedIndex = -1;
        UpdateAllHighlighter(selected, false);
    }

    private void UpdateAllHighlighter(int selected, bool isHighlight)
    {
        if (isHighlight)
        {
            for(int i = 0; i < _uiHighlighterHandlers.Count; ++i)
            {
                if (i == selected) continue;
                _uiHighlighterHandlers[i]._onUnhighlight.Invoke();
            }
        }
        else if(_currentHighlightedIndex == -1)
        {
            for (int i = 0; i < _uiHighlighterHandlers.Count; ++i)
            {
                _uiHighlighterHandlers[i]._onDefaultState.Invoke();
            }
        }
    }

    public void AddUIHighlighterHandler(UIHighlighterHandler uIHighlighterHandler)
    {
        _uiHighlighterHandlers.Add(uIHighlighterHandler);
    }
}
