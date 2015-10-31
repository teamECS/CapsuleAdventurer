using UnityEngine;
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
    public MenuController menuController;
    
	// Use this for initialization
	void Start () {
        gameState = GameState.START;

        if (gameManager == null) gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (timer == null) timer = GameObject.Find("Timer").GetComponent<Timer>();
        if (cameraController == null) cameraController = GameObject.Find("MainCamera").GetComponent<CameraController>();
        if (gaugeController == null) gaugeController = GameObject.Find("Gauge").GetComponent<GaugeController>();
        if (fillterController == null) fillterController = GameObject.Find("Fillter").GetComponent<FillterController>();
        if (playerController == null) playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        if (menuController == null) menuController = GameObject.Find("Menus").GetComponent<MenuController>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.C)) Application.CaptureScreenshot("screenshot.png");

        switch (gameState)
        {
            case GameState.START:
                //PLAYING状態への遷移
                if (Input.GetKeyDown(KeyCode.S)) {
                    ResumeGame();
                    menuController.HideMenus();
                }
                break;

            case GameState.PLAYING:
                //カメラの更新
                cameraController.UpdateCamera();
                //タイムゲージの更新
                gaugeController.UpdateGauge(timer.GetRateOfRemainingTime());
                //赤色フィルター点滅のon
                if (timer.GetRateOfRemainingTime() <= 0.1)
                    fillterController.StartBlinking();
                else
                    fillterController.StopBlinking();

                //PAUSE状態への遷移
                if (Input.GetKeyDown(KeyCode.S)) {
                    PauseGame();
                    menuController.DisplayPauseMenu();
                }
                //TIMEUP状態への遷移
                if (timer.GetRateOfRemainingTime() == 0) {
                    TimeUpGame();
                    menuController.DisplayTimeUpMenu();
                }
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
    public void ResumeGame()
    {
        gameState = GameState.PLAYING;
        timer.StartTimer();
        fillterController.Change2Clear();
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
    }


}
