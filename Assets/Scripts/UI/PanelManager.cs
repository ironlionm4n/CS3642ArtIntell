using UnityEngine;

namespace DefaultNamespace.UI
{
    public class PanelManager : MonoBehaviour
    {
        [SerializeField] private ImageSelectionHandler currentlySelected;
        public ImageSelectionHandler GetCurrentlySelected => currentlySelected;

        public ImageSelectionHandler GetImageSelectionHandler => currentlySelected;
        
        public void SetSelected(ImageSelectionHandler newSelection)
        {
            if (currentlySelected)
            {
                currentlySelected.DeSelect();
            }

            currentlySelected = newSelection;
        }
    }
}