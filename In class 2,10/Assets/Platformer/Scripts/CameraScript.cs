using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    public LevelParser level;
    public GameObject player;
    private Vector3 offset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - player.transform.position;
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
                    level.gainScore(100);
                }
                else if (hit.collider.CompareTag("gold_brick"))
                {
                    level.gainCoin();
                } else if (hit.collider.CompareTag("goal"))
                {
                    level.loadNextLevel();
                    Debug.Log("Level Complete!");
                }
                
            }
        }
    }
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x, transform.position.y,transform.position.z);
    }
}
