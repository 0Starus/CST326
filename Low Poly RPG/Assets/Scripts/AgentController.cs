using UnityEngine;
using UnityEngine.InputSystem;

public class AgentController : MonoBehaviour
{
    public Transform destinationMarker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Mouse.current.position.value);
            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo))
            {
                destinationMarker.position = hitInfo.point;
            }
        }
    }
}
