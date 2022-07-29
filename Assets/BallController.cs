using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールの見えるZ軸の最小値
    private float visiblePosZ = -6.5f;

    //スコアの初期値
    private int score = 0;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;
    //スコアを表示するテキスト
    private GameObject scoreText;


    // Start is called before the first frame update
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

        this.scoreText.GetComponent<Text>().text = "SCORE: " + this.score;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.score += 5;
        }
        else if (other.gameObject.tag == "LargeStatTag") //タグの綴りミス
        {
            this.score += 30;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.score += 10;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.score += 100;
        }
    }
}
