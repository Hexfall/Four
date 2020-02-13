using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Restart();
        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            if (SceneManager.GetSceneAt(0).isLoaded) {
                Application.Quit();
            } else {
                SceneManager.LoadScene(0);
            }
        }
    }

    public static void Restart() {
        SceneManager.LoadSceneAsync(1);
    }
}
