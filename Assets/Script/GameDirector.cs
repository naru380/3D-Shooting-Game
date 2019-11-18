using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    private GameObject timerText;
    private GameObject scoreText;
    private float time = 60.0f;
    private int killedNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.scoreText = GameObject.Find("KilledNum");
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<Text>().text = "残り時間：" + this.time.ToString("F1");
        this.scoreText.GetComponent<Text>().text = "倒した数：" + this.killedNum.ToString();

        if(this.time <= 0)
        {
            SceneManager.LoadScene("TittleScene");
        }
    }

    public void killZombie()
    {
        this.killedNum++;
    }
}
