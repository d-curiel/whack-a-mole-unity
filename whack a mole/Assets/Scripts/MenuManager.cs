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
    [SerializeField]
    private Button _optionsButton;
    [SerializeField]
    private Button _backButton;
    [SerializeField]
    private GameObject _selectionLanguage;
    [SerializeField]
    private Texture2D crosshair; 
    

    private void Awake() {
        _menuManager = this;
    }

    private void Start() {        
        Vector2 cursorOffset = new Vector2(crosshair.width/2, crosshair.height/2);
        Cursor.SetCursor(crosshair, cursorOffset, CursorMode.Auto);
        _newGameButton.onClick.AddListener(() => {
            this.NewGame();
        });
        _optionsButton.onClick.AddListener(() => {
            this.Options();
        });
        _backButton.onClick.AddListener(() => {
            this.Back();
        });

    }

    public void NewGame() {
        SceneManager.LoadScene(1);
    }

    public void Options() {
        _newGameButton.gameObject.SetActive(false);
        _optionsButton.gameObject.SetActive(false);
        _backButton.gameObject.SetActive(true);
        _selectionLanguage.gameObject.SetActive(true);
    }

    public void Back() {
        _newGameButton.gameObject.SetActive(true);
        _optionsButton.gameObject.SetActive(true);
        _backButton.gameObject.SetActive(false);
        _selectionLanguage.gameObject.SetActive(false);
    }
}
