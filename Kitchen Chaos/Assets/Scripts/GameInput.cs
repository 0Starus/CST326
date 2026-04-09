using UnityEngine;
using System;
using UnityEngine.InputSystem;
public class GameInput : MonoBehaviour{  
    private const string PLAYER_PREFS_BINDINGS = "InputBindings";
    public static GameInput Instance {get; private set;}
    private InputSystem_Actions inputSystem_Actions;
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnPauseAction;
    public event EventHandler OnBindingRebind;
    public enum Binding
    {
        Move_Up,
        Move_Down,
        Move_Left,
        Move_Right,
        Interact,
        InteractAlternate,
        Pause,
        Gamepad_Interact,
        Gamepad_InteractAlternate,
        Gamepad_Pause,
    }
    private void Awake(){
        Instance = this;
        inputSystem_Actions = new InputSystem_Actions();

        if (PlayerPrefs.HasKey(PLAYER_PREFS_BINDINGS))
        {
            inputSystem_Actions.LoadBindingOverridesFromJson(PlayerPrefs.GetString(PLAYER_PREFS_BINDINGS));
        }
        
        inputSystem_Actions.Player.Enable();
        inputSystem_Actions.Player.Interact.performed += Interact_performed;
        inputSystem_Actions.Player.InteractAlternate.performed += InteractAlternate_performed;
        inputSystem_Actions.Player.Pause.performed += Pause_performed;

        
    }

    private void OnDestroy()
    {
        inputSystem_Actions.Player.Interact.performed -= Interact_performed;
        inputSystem_Actions.Player.InteractAlternate.performed -= InteractAlternate_performed;
        inputSystem_Actions.Player.Pause.performed -= Pause_performed;

        inputSystem_Actions.Dispose();
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj){
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }
    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj){
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }
    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj){
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }
    public Vector2 GetMovementVectorNormalized(){
        Vector2 inputVector= inputSystem_Actions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
    public string GetBindingText(Binding binding)
    {
        switch (binding)
        {
            default:
            case Binding.Interact:
                return inputSystem_Actions.Player.Interact.bindings[0].ToDisplayString();
            case Binding.InteractAlternate:
                return inputSystem_Actions.Player.InteractAlternate.bindings[0].ToDisplayString();
            case Binding.Pause:
                return inputSystem_Actions.Player.Pause.bindings[0].ToDisplayString();
            case Binding.Move_Up:
                return inputSystem_Actions.Player.Move.bindings[1].ToDisplayString();
            case Binding.Move_Down:
                return inputSystem_Actions.Player.Move.bindings[2].ToDisplayString();
            case Binding.Move_Left:
                return inputSystem_Actions.Player.Move.bindings[3].ToDisplayString();
            case Binding.Move_Right:
                return inputSystem_Actions.Player.Move.bindings[4].ToDisplayString();
            case Binding.Gamepad_Interact:
                return inputSystem_Actions.Player.Interact.bindings[1].ToDisplayString();
            case Binding.Gamepad_InteractAlternate:
                return inputSystem_Actions.Player.InteractAlternate.bindings[1].ToDisplayString();
            case Binding.Gamepad_Pause:
                return inputSystem_Actions.Player.Pause.bindings[1].ToDisplayString();
        }
    }
    public void RebindBinding(Binding binding, Action onActionReBound)
    {
        inputSystem_Actions.Player.Disable();
        InputAction inputAction;
        int bindingIndex;
        switch (binding)
        {
            default:
            case Binding.Move_Up:
                inputAction = inputSystem_Actions.Player.Move;
                bindingIndex = 1;
                break;
            case Binding.Move_Down:
                inputAction = inputSystem_Actions.Player.Move;
                bindingIndex = 2;
                break;
            case Binding.Move_Left:
                inputAction = inputSystem_Actions.Player.Move;
                bindingIndex = 3;
                break;
            case Binding.Move_Right:
                inputAction = inputSystem_Actions.Player.Move;
                bindingIndex = 4;
                break;
            case Binding.Interact:
                inputAction = inputSystem_Actions.Player.Interact;
                bindingIndex = 0;
                break;
            case Binding.InteractAlternate:
                inputAction = inputSystem_Actions.Player.InteractAlternate;
                bindingIndex = 0;
                break;
            case Binding.Pause:
                inputAction = inputSystem_Actions.Player.Pause;
                bindingIndex = 0;
                break;
            case Binding.Gamepad_Interact:
                inputAction = inputSystem_Actions.Player.Interact;
                bindingIndex = 1;
                break;
            case Binding.Gamepad_InteractAlternate:
                inputAction = inputSystem_Actions.Player.InteractAlternate;
                bindingIndex = 1;
                break;
            case Binding.Gamepad_Pause:
                inputAction = inputSystem_Actions.Player.Pause;
                bindingIndex = 1;
                break;
        }
        inputAction.PerformInteractiveRebinding(bindingIndex)
            .OnComplete(callback =>
            {
                callback.Dispose();
                inputSystem_Actions.Player.Enable();
                onActionReBound();

                
                PlayerPrefs.SetString(PLAYER_PREFS_BINDINGS,inputSystem_Actions.SaveBindingOverridesAsJson());
                PlayerPrefs.Save();

                OnBindingRebind?.Invoke(this, EventArgs.Empty);
            })
            .Start();
    }
}
