using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public MenuManager _menuManager;

    [SerializeField]
    private Button _newGameButton;

    private void Awake() {
        _menuManager = this;
    }

    private void Start() {
        _newGameButton.onClick.AddListener(() => {
            this.NewGame();
        });
    }

    public void NewGame() {
        SceneManager.LoadScene(1);
    }
}
