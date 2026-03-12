using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Enemy enemy;
    public delegate void EnemiesCanShootFunc();

    public static EnemiesCanShootFunc OnEnemiesCanShoot;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void loadGame(){
        StartCoroutine(_LoadGame());
        

        IEnumerator _LoadGame()
        {
            AsyncOperation loadOperation= SceneManager.LoadSceneAsync("Schmup");
            Debug.Log("loading...");
            while(!loadOperation!.isDone) yield return null;
            // wait until scene is loaded and ready and then find the player
            GameObject playerObj = GameObject.Find("Player");
            Debug.Log(playerObj.name);
            OnEnemiesCanShoot.Invoke();    
        }
    }
}
