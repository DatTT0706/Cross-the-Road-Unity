using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOverPanel, hubContainer, playerRef, playerCam;
    public bool isPlaying { get; private set; }
    public int countDown;
    public Text countdownText, timeText, overGameText;
    private float startTime, elapsedTime;
    TimeSpan timePlaying;
    private Vector3 currentCamPosition;
    public float maxDistanceToShow;
    public List<GameObject> spawnPoints;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = new List<GameObject>();
        isPlaying = false;
        currentCamPosition = playerCam.transform.position;
        GetAllSpawnPoint();
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
            if (playerRef == null)
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
        spawnPoints.Clear();
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint").ToList();
    }

    IEnumerator OnPreGameStart()
    {
        int initTime = 10;
        while (initTime > 0)
        {
            yield return new WaitForSeconds(1f);
            initTime--;
        }
    }

    private void UpdateLaneCondition()
    {
        if (spawnPoints.Count > 0)
        {
            foreach (var spawnPoint in spawnPoints)
            {
                bool isActive = IsLaneActive(spawnPoint);
                Console.WriteLine(spawnPoint.ToString() + isActive);
                spawnPoint.GetComponent<CarFactory>().activeCars.ForEach(car =>
                    car.gameObject.SetActive(isActive)
                );
                spawnPoint.SetActive(isActive);
            }
        }
    }

    private bool IsLaneActive(GameObject spawnPoint)
    {
        float distance = Mathf.Abs(spawnPoint.transform.position.y - currentCamPosition.y);
        return (distance < maxDistanceToShow);
    }

    //chiskie
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameOver();
        }
    }
}