using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageSelectionHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PanelManager panelManager;
    [SerializeField] private Image highlightImage;
    [SerializeField] private AvailableShapes shape;
    public AvailableShapes GetShape => shape;
    [SerializeField] private AvailableColors color;
    public AvailableColors GetColor => color;

    public void OnPointerClick(PointerEventData eventData)
    {
        panelManager.SetSelected(this);

        Select();
    }

    private void Select()
    {
        if (highlightImage)
        {
            highlightImage.gameObject.SetActive(true);
        }
    }

    public void DeSelect()
    {
        if (highlightImage)
        {
            highlightImage.gameObject.SetActive(false);
        }
    }
}
