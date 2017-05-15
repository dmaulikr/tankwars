using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGameBehaviour : MonoBehaviour {


    void Start() {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ExitGame);
    }

    private void ExitGame() {
        Application.Quit();
    }
}
