using UnityEngine;
using Unity.Netcode;
using StarterAssets;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class PlayerClientScript : NetworkBehaviour
{
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] StarterAssetsInputs _starterAssetInputs;
    [SerializeField] ThirdPersonController _thirdPersonController;
    void Awake()
    {
        _playerInput.enabled = false;
        _starterAssetInputs.enabled = false;
        _thirdPersonController.enabled = false;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsOwner)
        {
            _playerInput.enabled = true;
            _starterAssetInputs.enabled = true;
        }

        if (IsServer)
        {
            _thirdPersonController.enabled = true;
        }
    }

    [Rpc(SendTo.Server)]
    private void UpdateInputServerRPC(Vector2 move, Vector2 look, bool jump, bool sprint)
    {
        _starterAssetInputs.MoveInput(move);
        _starterAssetInputs.LookInput(look);
        _starterAssetInputs.JumpInput(jump);
        _starterAssetInputs.SprintInput(sprint);
    }

    private void LateUpdate()
    {
        if(!IsOwner){
           return; 
        }

        UpdateInputServerRPC(_starterAssetInputs.move,_starterAssetInputs.look,_starterAssetInputs.jump,_starterAssetInputs.sprint);
    }
}
