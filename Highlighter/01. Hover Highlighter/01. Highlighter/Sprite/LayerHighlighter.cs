using UnityEngine;

public class LayerHighlighter : HoverHighlighter
{
    [Header("GameObjects")]
    [SerializeField] private GameObject[] applyGameObjects;

    [Header("Layer")]
    [SerializeField] private LayerMask highlightLayer;
    [SerializeField] private LayerMask unhighlightLayer;
    [SerializeField] private LayerMask defaultLayer;

    protected override void Highlight()
    {
        for(int i = 0; i < applyGameObjects.Length; i++)
        {
            applyGameObjects[i].layer = Mathf.RoundToInt(Mathf.Log(highlightLayer.value, 2));
        }
    }

    protected override void Unhighlight()
    {
        for (int i = 0; i < applyGameObjects.Length; i++)
        {
            applyGameObjects[i].layer = Mathf.RoundToInt(Mathf.Log(unhighlightLayer.value, 2));
        }
    }

    protected override void DefaultState()
    {
        for (int i = 0; i < applyGameObjects.Length; i++)
        {
            applyGameObjects[i].layer = Mathf.RoundToInt(Mathf.Log(defaultLayer.value, 2));
        }
    }
}
