using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOverPanel,hubContainer,playerRef;
    public bool isPlaying { get; private set; }
    public int countDown;
    public Text countdownText, timeText, overGameText;
    private float startTime, elapsedTime;
    TimeSpan timePlaying;
    

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false;
        StartCoroutine(CountToStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            elapsedTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string playingTime = "Time:" + timePlaying.ToString("mm':'ss'.'ff");
            timeText.text = playingTime;
            if(playerRef == null)
            {
                GameOver();
            }
        }
    }

    public void BeginGame()
    {
        isPlaying = true;
        startTime = Time.time;

    }

    IEnumerator CountToStart()
    {
        while (countDown > 0)
        {
            countdownText.text = countDown.ToString();
            yield return new WaitForSeconds(1f);
            countDown--;
        }

        BeginGame();
        countdownText.text = "GO!";

        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        isPlaying = false;
        Invoke("GameOverScreen", 1f);
    }

    public void GameOverScreen()
    {
        overGameText.text = timeText.text;
        gameOverPanel.SetActive(true);
        hubContainer.SetActive(false);
    }
}
