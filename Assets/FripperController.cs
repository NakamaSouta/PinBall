using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJoint�R���|�[�l���g
    private HingeJoint myHingeJoint;

    //�����̌X��
    private float defaultAngle = 20;
    //�e�����Ƃ��̌X��
    private float flickAngle = -20;


    // Start is called before the first frame update
    void Start()
    {
        //HingeJoint�R���|�l���g�̎擾
        this.myHingeJoint = GetComponent<HingeJoint>();

        //�t���b�p�[�̌X���̐ݒ�
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if ( ( (Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.A)) ||
            (Input.GetKeyDown(KeyCode.DownArrow)) || (Input.GetKeyDown(KeyCode.S)) ) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.D)) ||
            (Input.GetKeyDown(KeyCode.DownArrow)) || (Input.GetKeyDown(KeyCode.S))) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        if (((Input.GetKeyUp(KeyCode.LeftArrow)) || (Input.GetKeyUp(KeyCode.A)) ||
            (Input.GetKeyUp(KeyCode.DownArrow)) || (Input.GetKeyUp(KeyCode.S))) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (((Input.GetKeyUp(KeyCode.RightArrow)) || (Input.GetKeyUp(KeyCode.D)) ||
            (Input.GetKeyUp(KeyCode.DownArrow)) || (Input.GetKeyUp(KeyCode.S))) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }

    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
