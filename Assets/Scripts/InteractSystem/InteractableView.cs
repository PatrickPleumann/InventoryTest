using TMPro;
using UnityEngine;

public class InteractableView : MonoBehaviour
{
    public TMP_Text actionText;
    public TMP_Text keybindingText;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Setup(string _actionText, string _keybindingText)
    {
        actionText.text = _actionText;
        keybindingText.text = _keybindingText;
    }

    public void Show()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
    public void Hide()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
