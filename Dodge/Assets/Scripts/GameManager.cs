using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UI
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;  // 게임 실행 도중 텍스트를 실행하지 않으므로 오브젝트 타입으로 변수 선언
    public Text timeText;  // 게임 실행 도중에 텍스트 변경할 것이므로 텍스트 타입으로 선언
    public Text recordText;

    private float surviveTime;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If game is still played
        if(!isGameOver) {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
        }
        // If game is over
        else {
            if(Input.GetKeyDown(KeyCode.R)) {  // If R key is pressed
                SceneManager.LoadScene("SampleScene");  // Reload the scene
            }
        }
    }

    public void EndGame(){
        isGameOver = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime > bestTime) {
            bestTime = surviveTime;

            PlayerPrefs.SetFloat("BestTime", bestTime);

            recordText.text = "Best Time: " + (int)bestTime;
        }
    }
}
