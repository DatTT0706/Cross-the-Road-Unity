using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject choiceGameObject;
    public GameObject correctGameObject;
    public GameObject pointText;
    public GameMessage GameOver;
    public GameMessage GameComplete;

    Queue<GameObject> queue;
    GameObject[] icons;
    string saveFile;
    GameData gameData = new GameData();
    int count;


    // Start is called before the first frame update
    private void Awake()
    {
        queue = new Queue<GameObject>();
        icons = GameObject.FindGameObjectsWithTag("icon");
        saveFile = Application.persistentDataPath + "/gamedata.json";
        readFile();
        count = gameData.blinkCount;
    }
    void Start()
    {
        InvokeRepeating("Spawn", gameData.blinkTime, gameData.blinkTime + 0.25f);
    }
    public void Spawn()
    {
        GameObject gameObject = icons[Random.Range(0, icons.Length)];
        GameObject choiceClone = Instantiate(choiceGameObject, gameObject.transform.position, Quaternion.identity);
        Destroy(choiceClone, gameData.blinkTime);
        queue.Enqueue(gameObject);
        count--;
        if (count <= 0)
        {
            CancelInvoke("Spawn");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && count <= 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "icon")
            {
                if (queue.Peek().name == hit.collider.name)
                {
                    pointText.GetComponent<Text>().text = (int.Parse(pointText.GetComponent<Text>().text)+1).ToString();
                    GameObject correctClone = Instantiate(correctGameObject, queue.Peek().transform.position, Quaternion.identity);
                    Destroy(correctClone, 0.3f);
                    queue.Dequeue();
                }
                else
                {
                    pointText.SetActive(false);
                    GameOver.Setup();
                }
            }
        }
        if (queue.Count <= 0 && count <= 0)
        {
            pointText.SetActive(false);
            GameComplete.Setup();
        }
    }
    public void readFile()
    {
        if (File.Exists(saveFile))
        {
            string fileContents = File.ReadAllText(saveFile);
            gameData = JsonUtility.FromJson<GameData>(fileContents);
        }
    }
}
