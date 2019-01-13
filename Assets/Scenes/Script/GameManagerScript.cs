using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {
    public static GameManagerScript instant;


    public GameObject playerA;
    public GameObject playerB;

    public static int optItem;
    public float timer = 1200f;
    public Text timerText;

    public List<GameObject> players;
    private bool once;


    public GameObject winCanvas;
    public Text resultText;

    public static int scoreA;
    public static int scoreB;
    public Text scoreAText;
    public Text scoreBText;

    public GameObject cameraObj;
    public Toggle toggle3D;


    private void Awake()
    {
        if (instant == null)
        {
            instant = this;
        }
    }
    // Use this for initialization
    void Start () {
        winCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (toggle3D.isOn)
        {
            cameraObj.GetComponent<Camera>().orthographic = false;
        }
        else
        {
            cameraObj.GetComponent<Camera>().orthographic = true;
        }
        scoreAText.text = "ScoreA :" + scoreA;

        scoreBText.text = "ScoreB :" + scoreB;

        timerText.text = "" + Mathf.Floor(timer/60f).ToString("00") +":" + Mathf.Floor(timer % 60f).ToString("00");
        if (!once)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                winCanvas.SetActive(true);
                resultText.text = "Draw";
                if (playerA != null)
                {
                    playerA.GetComponent<PlayerControllerScript>().enabled = false;
                }
                if (playerB != null)
                {
                    playerB.GetComponent<PlayerControllerScript>().enabled = false;
                }
            }
        }
        if (players.Count > 0)
        {
            winCanvas.SetActive(true);
            once = true;
            if (players.Count == 1)
            {
                if (players[0].name == "Player_A")
                {
                    resultText.text = "Win B";
                }
                else
                {
                    resultText.text = "Win A";
                }
                if (playerA != null)
                {
                    playerA.GetComponent<PlayerControllerScript>().enabled = false;
                }
                if (playerB != null)
                {
                    playerB.GetComponent<PlayerControllerScript>().enabled = false;
                }
            }
            else
            {
                resultText.text = "Draw";
                if (playerA != null)
                {
                    playerA.GetComponent<PlayerControllerScript>().enabled = false;
                }
                if (playerB != null)
                {
                    playerB.GetComponent<PlayerControllerScript>().enabled = false;
                }
            }
        }
	}

    public void RestartGame()
    {
        Application.LoadLevel(0);
    }
}
