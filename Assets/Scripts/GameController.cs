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

    public Timer timer;
    public CameraController cameraController;
    public GaugeController gaugeController;
    public FillterController fillterController;
    public PlayerController playerController;

    public GameObject pauseMenu;
    public GameObject pauseFirstButton;

    public GameObject timeUpMenu;
    public GameObject timeUpFirstButton;
    
	// Use this for initialization
	void Start () {
        gameState = GameState.START;

        if (timer == null) timer = GameObject.Find("Timer").GetComponent<Timer>();
        if (cameraController == null) cameraController = GameObject.Find("MainCamera").GetComponent<CameraController>();
        if (gaugeController == null) gaugeController = GameObject.Find("Gauge").GetComponent<GaugeController>();
        if (fillterController == null) fillterController = GameObject.Find("Fillter").GetComponent<FillterController>();
        if (playerController == null) playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        if (pauseMenu == null) pauseMenu = GameObject.Find("PauseMenu");
        if (pauseFirstButton == null) pauseFirstButton = pauseMenu.transform.FindChild("Buttons/Resume").gameObject;

        if (timeUpMenu == null) timeUpMenu = GameObject.Find("TimeUpMenu");
        if (timeUpFirstButton == null) timeUpFirstButton = timeUpMenu.transform.FindChild("Buttons/Reset").gameObject;

        HideMenus();
	}
	
	// Update is called once per frame
	void Update () {
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
                gaugeController.UpdateGauge(timer.GetRateOfTimeRemaining());
                //赤色フィルター点滅のon
                if (timer.GetRateOfTimeRemaining() <= 0.1)
                    fillterController.StartBlinking();

                //GOAL状態への遷移
                //PAUSE状態への遷移
                if (Input.GetKeyDown(KeyCode.S))
                    PauseGame();
                //TIMEUP状態への遷移
                if (timer.GetRateOfTimeRemaining() == 0)
                {
                    gameState = GameState.TIMEUP;
                    //timer.StopTimer();
                    fillterController.StopBlinking();
                    fillterController.Change2Black();
                    timeUpMenu.SetActive(true);
                }
                break;

            case GameState.PAUSE:
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
        pauseMenu.SetActive(true);
        FocusGameObject(pauseFirstButton);
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
        Application.LoadLevel(Application.loadedLevel);
    }
    //public void ResetGame()
    //{
    //    gameState = GameState.START;
    //    fillterController.Change2Clear();
    //    HideMenus();

    //    //playerの初期化(ポーズ状態の速度、加速度も初期化)
    //    timer.StartTimer();
    //    playerController.Reset();
    //    timer.ResetTimer();
    //    //カメラの初期化
    //    cameraController.Reset();
    //    //タイムゲージの更新
    //    gaugeController.UpdateGauge(timer.GetRateOfTimeRemaining());
    //}
    public void FinishGame()
    {
        gameState = GameState.FINISH;
        timer.StopTimer();
        fillterController.StopBlinking();

        fillterController.Change2Black();
    }

    void FocusGameObject(GameObject focusedObj)
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
