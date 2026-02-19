using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    public LevelParser level;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Clicked");
            Vector2 screenPos = Mouse.current.position.ReadValue();
            //Debug.DrawRay(new Vector3(screenPos.x,screenPos.y,-1f),Vector3.forward,Color.red);
            Ray ray = Camera.main.ScreenPointToRay(screenPos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log($"Clicked on something: {hit}");
                if (hit.collider.CompareTag("brick"))
                {
                    Destroy(hit.collider.gameObject);    
                }
                else if (hit.collider.CompareTag("gold_brick"))
                {
                    level.gainCoin();
                }
                
            }
        }
    }
}
