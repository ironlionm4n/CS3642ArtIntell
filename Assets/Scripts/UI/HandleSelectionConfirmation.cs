using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.UI;
using UnityEngine;
using UnityEngine.UI;

public class HandleSelectionConfirmation : MonoBehaviour
{
    [SerializeField] private PanelManager shapePanelManager;
    [SerializeField] private PanelManager colorPanelManager;
    [SerializeField] private GameObject canvas;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    private void Update()
    {
        _button.interactable = shapePanelManager.GetCurrentlySelected != null &
                               colorPanelManager.GetCurrentlySelected != null;
    }

    public void TestData()
    {
        Debug.Log($"Shape: {shapePanelManager.GetImageSelectionHandler.GetShape}\tColor: {colorPanelManager.GetImageSelectionHandler.GetColor}");
        canvas.SetActive(false);
        ConveyorManager.canStart = true;
    }
}
