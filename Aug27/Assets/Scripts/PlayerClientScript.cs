using UnityEngine;
using Unity.Netcode;
using StarterAssets;
using UnityEngine.InputSystem;

public class PlayerClientScript : NetworkBehaviour
{
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] StarterAssetsInputs _starterAssetInputs;
    [SerializeField] ThirdPersonController _thirdPersonController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
            _thirdPersonController.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
