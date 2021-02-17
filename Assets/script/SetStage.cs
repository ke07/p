using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStage : MonoBehaviour
{

    [SerializeField] GameObject bg_f;
    [SerializeField] GameObject bg_b;

    GameObject bg_front;
    GameObject bg_back;

    [SerializeField] float stage_width;//ステージ片面分の幅
    [SerializeField] float stage_height;//ステージの高さ

    GameObject TargetPlayer;

    // Start is called before the first frame update
    void Start()
    {

        //背景設置

        //bg_front = Instantiate(bg_f, new Vector3(0,0,5), Quaternion.identity);
        //bg_back = Instantiate(bg_b, new Vector3(stage_width, 0, 5), Quaternion.identity);


        // bg_back.name = "bg_back";

        //bg_front.transform.localScale = new Vector3(stage_width * bg_front.transform.localScale.x, stage_height * bg_front.transform.localScale.y, 1);
        //bg_back.transform.localScale = new Vector3(stage_width * bg_back.transform.localScale.x, stage_height * bg_back.transform.localScale.y, 1);

        Application.targetFrameRate = 60;

        for (int i=0;i<stage_height;i++)
        {
            for (int j = 0; j < stage_width; j++)
            {

                bg_front = Instantiate(bg_f, new Vector3(-stage_width / 2.0f + j + 0.5f, -stage_height / 2 + i, 5), Quaternion.identity);

                bg_front.name = "bg_front";
                Debug.Log(-stage_width / 2 + j + 0.5f);
            }

        }


        for (int i = 0; i < stage_height; i++)
        {
            for (int j = 0; j < stage_width; j++)
            {

                bg_back = Instantiate(bg_b, new Vector3(-stage_width / 2.0f + j + stage_width + 0.5f,  -stage_height / 2 + i, 5), Quaternion.identity);

                bg_back.name = "bg_back";

            }

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetStageSize()
    {
        return new Vector2(stage_width,stage_height);

    }

}
