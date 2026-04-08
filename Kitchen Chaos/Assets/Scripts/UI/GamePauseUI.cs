using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(()=>
        {
            GameManager.Instance.TogglePauseGame();
        });
        mainMenuButton.onClick.AddListener(()=>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }
     private void Start()
    {
        GameManager.Instance.OnGamePause += GameMangager_OnGamePause;
        GameManager.Instance.OnGameUnpause += GameMangager_OnGameUnPause;
        Hide();
    }

    private void GameMangager_OnGamePause(object sender, System.EventArgs e)
    {
        Show();
    }
    private void GameMangager_OnGameUnPause(object sender, System.EventArgs e)
    {
        Hide();
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
