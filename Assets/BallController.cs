using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //�{�[���̌�����Z���̍ŏ��l
    private float visiblePosZ = -6.5f;

    //�X�R�A�̏����l
    private int score = 0;

    //�Q�[���I�[�o�[��\������e�L�X�g
    private GameObject gameoverText;
    //�X�R�A��\������e�L�X�g
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
        else if (other.gameObject.tag == "LargeStatTag") //�^�O�̒Ԃ�~�X
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
