using UnityEngine;

public class Questionblock : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public delegate void QBlockHitFunc();
    public static QBlockHitFunc OnQBlockHit;
    
    public Renderer qBlock;
    int x = -1;
    float y = -.2f;
    int timerPrep = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timerPrep--;
        if(timerPrep == 0)
        {
            timerPrep = 10;
            y-= .2f;
            qBlock = GetComponent<Renderer>();
            qBlock.material.mainTextureOffset = new Vector2(x,y);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        OnQBlockHit.Invoke();
    }
}
