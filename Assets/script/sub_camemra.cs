using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sub_camemra : MonoBehaviour
{

    GameObject TargetPlayer;
    SetStage setStage;
    player_camera player_Camera;

    float set_rectx;

    // Start is called before the first frame update
    void Start()
    {
        TargetPlayer = GameObject.Find("player");
        setStage = GameObject.Find("system").GetComponent<SetStage>();
        player_Camera = GameObject.Find("Main_Camera").GetComponent<player_camera>();
    }

    // Update is called once per frame
    void Update()
    {

        //メインカメラが画面の外を捉える領域に入ったら変動
        //左ループ
        if (TargetPlayer.transform.position.x - (GetComponent<Camera>().orthographicSize + 1) < 0 - setStage.GetStageSize().x / 2)
        {

            transform.position = new Vector3(TargetPlayer.transform.position.x + setStage.GetStageSize().x * 2 - (GetComponent<Camera>().orthographicSize + 1), TargetPlayer.transform.position.y, -10);


            //set_rectx = (TargetPlayer.transform.position.x + setStage.GetStageSize().x / 2) / GetComponent<Camera>().orthographicSize;

            set_rectx = player_Camera.GetPlayerCameraRectX();

            //GetComponent<Camera>().rect = new Rect(set_rectx, 0.0f, 1.0f, 1.0f);
            GetComponent<Camera>().rect = new Rect(0.0f, 0.0f, 1 - set_rectx, 1.0f);


            Debug.Log(GetComponent<Camera>().rect);

        }
        //左ループ
        else if (TargetPlayer.transform.position.x + (GetComponent<Camera>().orthographicSize + 1) > setStage.GetStageSize().x * 3 / 2)
        {

            transform.position = new Vector3(TargetPlayer.transform.position.x - setStage.GetStageSize().x * 2 + (GetComponent<Camera>().orthographicSize + 1), TargetPlayer.transform.position.y, -10);


            set_rectx = player_Camera.GetPlayerCameraRectX();

            //GetComponent<Camera>().rect = new Rect(set_rectx, 0.0f, 1.0f, 1.0f);
            GetComponent<Camera>().rect = new Rect(set_rectx, 0.0f, 1.0f, 1.0f);


            Debug.Log(GetComponent<Camera>().rect);

        }
        else
        {
            GetComponent<Camera>().rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);

        }




    }
}
