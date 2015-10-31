using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class GameController : MonoBehaviour {

    public enum GameState
    {
        START,
        PLAYING,
        PAUSE,
        TIMEUP,
        FINISH
    }

    private GameState gameState;

    public GameManager gameManager;

    public Timer timer;
    public CameraController cameraController;
    public GaugeController gaugeController;
    public FillterController fillterController;
    public PlayerController playerController;

    public GameObject pauseMenu;
    public GameObject timeUpMenu;
    
	// Use this for initialization
	void Start () {
        gameState = GameState.START;

        if (gameManager == null) gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (timer == null) timer = GameObject.Find("Timer").GetComponent<Timer>();
        if (cameraController == null) cameraController = GameObject.Find("MainCamera").GetComponent<CameraController>();
        if (gaugeController == null) gaugeController = GameObject.Find("Gauge").GetComponent<GaugeController>();
        if (fillterController == null) fillterController = GameObject.Find("Fillter").GetComponent<FillterController>();
        if (playerController == null) playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        if (pauseMenu == null) pauseMenu = GameObject.Find("PauseMenu");
        if (timeUpMenu == null) timeUpMenu = GameObject.Find("TimeUpMenu");

        HideMenus();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.C)) Application.CaptureScreenshot("screenshot.png");

        switch (gameState)
        {
            case GameState.START:
                //PLAYING状態への遷移
                if (Input.GetKeyDown(KeyCode.S))
                    ResumeGame();
                break;

            case GameState.PLAYING:
                //カメラの更新
                cameraController.UpdateCamera();
                //タイムゲージの更新
                gaugeController.UpdateGauge(timer.GetRateOfRemainingTime());
                //赤色フィルター点滅のon
                if (timer.GetRateOfRemainingTime() <= 0.1)
                    fillterController.StartBlinking();

                //PAUSE状態への遷移
                if (Input.GetKeyDown(KeyCode.S)){
                    PauseGame();
                    PrintPauseMenu();
                }
                //TIMEUP状態への遷移
                if (timer.GetRateOfRemainingTime() == 0)
                    TimeUpGame();
                break;

            default:
                break;

        }
	}

    public void PauseGame()
    {
        gameState = GameState.PAUSE;
        timer.StopTimer();
        fillterController.StopBlinking();
        fillterController.Change2Black();
    }
    private void PrintPauseMenu()
    {
        pauseMenu.SetActive(true);
        FocusGameObject(pauseMenu.transform.FindChild("Buttons/Resume").gameObject);
    }
    public void ResumeGame()
    {
        gameState = GameState.PLAYING;
        timer.StartTimer();
        fillterController.Change2Clear();
        HideMenus();
    }
    public void ResetGame()
    {
        gameManager.LoadScene(Application.loadedLevelName);
    }
    public void FinishGame()
    {
        gameState = GameState.FINISH;
        timer.StopTimer();

        gameManager.SetRemainingTime(timer.GetRemainingTime());
        gameManager.LoadScene("Result");
    }
    public void TimeUpGame()
    {
        gameState = GameState.TIMEUP;
        //timer.StopTimer();
        fillterController.StopBlinking();
        fillterController.Change2Black();
        timeUpMenu.SetActive(true);
        FocusGameObject(timeUpMenu.transform.FindChild("Buttons/Reset").gameObject);
    }

    public void FocusGameObject(GameObject focusedObj)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(focusedObj);
    }

    void HideMenus()
    {
        pauseMenu.SetActive(false);
        timeUpMenu.SetActive(false);
    }
}
