using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private InputField playerNameInput;
    private string playerName;
    private Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("Start Button").GetComponent<Button>();
        playerNameInput = GameObject.Find("Player Name").GetComponent<InputField>();
        startButton.onClick.AddListener(LoadScene);
    }

    // Update is called once per frame
    void Update()
    {
        GlobalControl.Instance.savedData.currentPlayerName = playerNameInput.text;
    }

    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
