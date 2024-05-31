using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuEvents : MonoBehaviour
{
    private Button playButton;

    private Button quitButton;

    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        playButton = root.Q<Button>("StartGame");
        quitButton = root.Q<Button>("ExitGame");

        playButton.RegisterCallback<ClickEvent>(OnPressPlay);
    }

    private void OnPressPlay(ClickEvent click)
    {
        SceneManager.LoadScene("SampleScene");
    }
}
