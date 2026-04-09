using UnityEngine;
using TMPro;
using System;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moveUpTutorialText;
    [SerializeField] private TextMeshProUGUI moveDownTutorialText;
    [SerializeField] private TextMeshProUGUI moveLeftTutorialText;
    [SerializeField] private TextMeshProUGUI moveRightTutorialText;
    [SerializeField] private TextMeshProUGUI interactTutorialText;
    [SerializeField] private TextMeshProUGUI interactAlternateTutorialText;
    [SerializeField] private TextMeshProUGUI pauseTutorialText;
    [SerializeField] private TextMeshProUGUI gamepadInteractTutorialText;
    [SerializeField] private TextMeshProUGUI gamepadInteractAlternateTutorialText;
    [SerializeField] private TextMeshProUGUI gamepadPauseTutorialText;
    private void Start()
    {
        Show();
        UpdateVisual();
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }
    private void UpdateVisual()
    {
        moveUpTutorialText.text= GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        moveDownTutorialText.text= GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        moveLeftTutorialText.text= GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        moveRightTutorialText.text= GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        interactTutorialText.text= GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        interactAlternateTutorialText.text= GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlternate);
        pauseTutorialText.text= GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
        gamepadInteractTutorialText.text= GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        gamepadInteractAlternateTutorialText.text= GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlternate);
        gamepadPauseTutorialText.text= GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
    }
    private void GameInput_OnBindingRebind(object sender, EventArgs e)
    {
        UpdateVisual();
    }
    private void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        if(GameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
