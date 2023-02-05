using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance = _instance;

    private List<string> _itemList = new List<string>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    public void PauseGame(bool isPaused)
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
            return;
        }
        Time.timeScale = 1f;
    }

    public void AddItemToList(string itemName)
    {
        _itemList.Add(itemName);
    }

    public bool IsItemInList(string itemName)
    {
        return _itemList.Contains(itemName);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
