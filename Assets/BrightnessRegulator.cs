using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour
{
    //Materialを入れる
    Material myMaterial;

    //Emissionの最小値
    private float minEmission = 0.2f;
    //Emissionの強度
    private float magEmission = 2.0f;
    //角度
    private int degree = 0;
    //発光速度
    private int speed = 5;
    //ターゲットのデフォルトの色
    Color defaultColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        if (tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
        }
        else if (tag == "LargeStatTag") //綴りミス　Tag名後から修正可能？
        {
            this.defaultColor = Color.yellow;
        }
        else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultColor = Color.cyan;
        }

        //オブジェクトにアタッチされているMaterialを取得
        this.myMaterial = GetComponent<Renderer>().material;

        //オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);
    }


    // Update is called once per frame
    void Update()
    {
        if (this.degree >= 0)
        {
            //光らせる強度
            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);
            //エミッションに色を設定
            myMaterial.SetColor("_EmissionColor", emissionColor);
            //現在の角度を小さくする
            this.degree -= this.speed;
        }
        
    }

    void OnCollisionEnter(Collision other)
    {
        this.degree = 180;
    }
}
