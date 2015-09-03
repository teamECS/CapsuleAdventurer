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
        GOAL
    }

    private GameState gameState;

    public Timer timer;
    public CameraController cameraController;
    public GaugeController gaugeController;
    public FillterController fillterController;
    public PlayerController playerController;

    public GameObject pauseMenu;
    public GameObject pauseFirstButton;
    
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

        pauseMenu.SetActive(false);
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
        //pauseMenu.GetComponent<FocusController>().SelectFirstButton();
        FocusGameObject(pauseFirstButton);
    }
    public void ResumeGame()
    {
        gameState = GameState.PLAYING;
        timer.StartTimer();
        fillterController.Change2Clear();
        pauseMenu.SetActive(false);
    }
    public void RestartGame()
    {
        gameState = GameState.START;
        fillterController.Change2Clear();
        pauseMenu.SetActive(false);

        //playerの初期化(ポーズ状態の速度、加速度も初期化)
        timer.StartTimer();
        playerController.Restart();
        timer.ResetTimer();
        //カメラの初期化
        cameraController.Restart();
        //タイムゲージの更新
        gaugeController.UpdateGauge(timer.GetRateOfTimeRemaining());
    }

    void FocusGameObject(GameObject focusedObj)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(focusedObj);
    }

}
