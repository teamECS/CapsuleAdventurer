using UnityEngine;
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

    private Timer timer;
    private CameraController cameraController;
    private GaugeController gaugeController;
    private FillterController fillterController;
    private PlayerController playerController;

    private GameObject pauseMenu;
    
	// Use this for initialization
	void Start () {
        gameState = GameState.START;

        timer = GameObject.Find("Timer").GetComponent<Timer>();
        cameraController = GameObject.Find("MainCamera").GetComponent<CameraController>();
        gaugeController = GameObject.Find("Gauge").GetComponent<GaugeController>();
        fillterController = GameObject.Find("Fillter").GetComponent<FillterController>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        pauseMenu = GameObject.Find("PauseMenu");

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
                ////PLAYING状態への遷移
                //if (Input.GetMouseButtonUp(0))
                //    ResumeGame();
                //break;

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
        timer.ResetTimer();
        fillterController.Change2Clear();
        pauseMenu.SetActive(false);

        //playerの初期化
        playerController.Restart();
        //カメラの初期化
        cameraController.Restart();
        //タイムゲージの更新
        gaugeController.UpdateGauge(timer.GetRateOfTimeRemaining());
    }
}
