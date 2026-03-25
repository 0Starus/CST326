using UnityEngine;
using System;
public class GameInput : MonoBehaviour{  
    private InputSystem_Actions inputSystem_Actions;
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    private void Awake(){
        inputSystem_Actions = new InputSystem_Actions();
        inputSystem_Actions.Player.Enable();
        inputSystem_Actions.Player.Interact.performed += Interact_performed;
        inputSystem_Actions.Player.InteractAlternate.performed += InteractAlternate_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj){
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }
    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj){
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }
    public Vector2 GetMovementVectorNormalized(){
        Vector2 inputVector= inputSystem_Actions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
