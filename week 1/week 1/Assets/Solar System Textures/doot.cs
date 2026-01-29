using UnityEngine;

public class doot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform centerPoint;
    public Vector3 axis =Vector3.up;
    public float YawSpeedPerSecond = 45f;
    void Start()
    {
        Debug.Log("Unity Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(centerPoint.position, axis,YawSpeedPerSecond* Time.deltaTime );
        Transform MyTransform = GetComponent<Transform>();
        MyTransform.Rotate(new Vector3(0f, YawSpeedPerSecond* Time.deltaTime,0f));
    }
}
