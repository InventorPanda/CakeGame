using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject background;

    bool paused;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        background.SetActive(paused);

        if (paused)
        {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }
}
