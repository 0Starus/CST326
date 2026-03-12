using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class CreditsManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(WaitForCredits());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitForCredits()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("5 seconds have passed!");
        SceneManager.LoadScene("Title");
    }
}
