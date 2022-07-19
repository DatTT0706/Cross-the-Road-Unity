using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool isPlaying;
    public int countDown;
    public Text countdownText;

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
        
    }

    public void BeginGame()
    {
        isPlaying=true;
    }

    IEnumerator CountToStart()
    {
        while(countDown > 0)
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
}
