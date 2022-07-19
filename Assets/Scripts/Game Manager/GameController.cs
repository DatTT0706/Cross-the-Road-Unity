using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOverPanel,hubContainer,playerRef,playerCam;
    public bool isPlaying { get; private set; }
    public int countDown;
<<<<<<< HEAD
    public Text countdownText, timeText, overGameText;
    private float startTime, elapsedTime;
    TimeSpan timePlaying;
    private Vector3 currentCamPosition;
    public float maxDistanceToShow;
    public List<GameObject> spawnList { get; private set; }
=======
    public Text countdownText;
    public List<GameObject> spawnPoints;
>>>>>>> master

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnList = new List<GameObject>();
        isPlaying = false;
<<<<<<< HEAD
        currentCamPosition = playerCam.transform.position;
        GetAllSpawnPoint();
=======
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint").ToList();
>>>>>>> master
        StartCoroutine(CountToStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            currentCamPosition = playerCam.transform.position;
            elapsedTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string playingTime = "Time:" + timePlaying.ToString("mm':'ss'.'ff");
            timeText.text = playingTime;
            UpdateLaneCondition();
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

    public void GetAllSpawnPoint()
    {
        spawnList.Clear();
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoint");
        if (spawnPoints != null)
        {
            foreach (var spawnPoint in spawnPoints)
            {
                spawnList.Add(spawnPoint);
            }
        }
    }

    IEnumerator OnPreGameStart()
    {
        int initTime = 10;
        while(initTime > 0)
        {
            yield return new WaitForSeconds(1f);
            initTime--;
        }
        
    }

    private void UpdateLaneCondition()
    {
        if(spawnList.Count > 0)
        {
            foreach(var spawnPoint in spawnList)
            {
                if (IsLaneActive(spawnPoint))
                {
                    spawnPoint.GetComponent<CarFactory>().cars.ForEach(car =>
                        car.gameObject.SetActive(true)
                    );
                    spawnPoint.SetActive(true);
                }
                else
                {
                    spawnPoint.GetComponent<CarFactory>().cars.ForEach(car =>
                        car.gameObject.SetActive(false)
                    );
                    spawnPoint.SetActive(false);
                }
            }
        }
    }

    private bool IsLaneActive(GameObject spawnPoint)
    {
        float distance = Mathf.Abs( spawnPoint.transform.position.y - currentCamPosition.y);
        return (distance < maxDistanceToShow);
    }
}
