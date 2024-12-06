using System.Collections.Generic;
using UnityEngine;

public class HighlighterToggleGroup : MonoBehaviour
{
    [SerializeField] private List<HighlighterHandler> _highlighterHandlers = new List<HighlighterHandler>();
    [SerializeField] private int _currentHighlightedIndex = -1;

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        for (int i = 0; i < _highlighterHandlers.Count; i++)
        {
            _highlighterHandlers[i].SetHighlightIndex(i);
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
            for(int i = 0; i < _highlighterHandlers.Count; ++i)
            {
                if (i == selected) continue;
                _highlighterHandlers[i]._onUnhighlight.Invoke();
            }
        }
        else if(_currentHighlightedIndex == -1)
        {
            for (int i = 0; i < _highlighterHandlers.Count; ++i)
            {
                _highlighterHandlers[i]._onDefaultState.Invoke();
            }
        }
    }

    public void AddHighlighterHandler(HighlighterHandler highlighterHandler)
    {
        _highlighterHandlers.Add(highlighterHandler);
    }
}
