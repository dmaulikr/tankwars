using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnToMenuBehaviour : MonoBehaviour {

    // Use this for initialization
    void Start() {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(StartNewGame);
    }

    private void StartNewGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
