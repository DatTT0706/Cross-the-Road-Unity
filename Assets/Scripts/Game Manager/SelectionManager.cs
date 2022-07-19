using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> characters = new List<Sprite>();

    private int selectedCharacter;
    public GameObject playerSkin;

    public void NextOption()
    {
        selectedCharacter += 1;
        if (selectedCharacter == characters.Count)
        {
            selectedCharacter = 0;
        }

        sr.sprite = characters[selectedCharacter];
    }

    public void BackOption()
    {
        selectedCharacter -= 1;
        if (selectedCharacter < 0)
        {
            selectedCharacter = characters.Count - 1;
        }

        sr.sprite = characters[selectedCharacter];
    }

    public void PlayGame()
    {
        PrefabUtility.SaveAsPrefabAsset(playerSkin, "Assets/Prefabs/main_character.prefab");
        SceneManager.LoadScene("SampleScene");
    }
}