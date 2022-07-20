using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMessage : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("MiniGame");
    }
    public void NextLevelButton()
    {
        GameData gameData = new GameData();
        if (File.Exists(Application.persistentDataPath + "/gamedata.json"))
        {
            string fileContents = File.ReadAllText(Application.persistentDataPath + "/gamedata.json");
            gameData = JsonUtility.FromJson<GameData>(fileContents);
        }
        gameData.blinkCount = gameData.blinkCount + 1;
        if(gameData.blinkTime - 0.15f >= 0.1f)
        {
            gameData.blinkTime -= 0.15f;
        }
        print(gameData.blinkCount + " - " + gameData.blinkTime);
        string jsonString = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/gamedata.json", jsonString);

        SceneManager.LoadScene("MiniGame");
    }
    public void Level1Button()
    {
        GameData gameData = new GameData();
        print(gameData.blinkCount + " - " + gameData.blinkTime);
        string jsonString = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/gamedata.json", jsonString);

        SceneManager.LoadScene("MiniGame");
    }
}
