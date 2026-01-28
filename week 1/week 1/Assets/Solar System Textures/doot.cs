using UnityEngine;

public class doot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float YawSpeedPerSecond = 45;
    void Start()
    {
        Debug.Log("Unity Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        Transform MyTransform = GetComponent<Transform>();
        MyTransform.Rotate(new Vector3(0f, YawSpeedPerSecond* Time.deltaTime,0f));
    }
}
