using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_camera : MonoBehaviour
{

    GameObject TargetPlayer;
    SetStage setStage;
    float set_rectx;

    // Start is called before the first frame update
    void Start()
    {

        TargetPlayer = GameObject.Find("player");
        setStage = GameObject.Find("system").GetComponent<SetStage>();

        set_rectx = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {



        //メインカメラが画面の外を捉える領域に入ったら縮小
        //左ループ
        if (TargetPlayer.transform.position.x - (GetComponent<Camera>().orthographicSize + 1) < 0 - setStage.GetStageSize().x / 2)
        {

            set_rectx = (TargetPlayer.transform.position.x + setStage.GetStageSize().x / 2) / (GetComponent<Camera>().orthographicSize + 1);

            GetComponent<Camera>().rect = new Rect(1 - set_rectx, 0.0f, 1.0f, 1.0f);

            Debug.Log(GetComponent<Camera>().rect);

        }
        //右ループ
        else if (TargetPlayer.transform.position.x + (GetComponent<Camera>().orthographicSize + 1) > setStage.GetStageSize().x * 3 / 2)
        {

            set_rectx = (setStage.GetStageSize().x * 3 / 2 - TargetPlayer.transform.position.x) / (GetComponent<Camera>().orthographicSize + 1);

            GetComponent<Camera>().rect = new Rect(0.0f, 0.0f, set_rectx, 1.0f);

            Debug.Log(GetComponent<Camera>().rect);

        }
        else
        {
            set_rectx = 0.0f;
            GetComponent<Camera>().rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);

        }

        transform.position = new Vector3(TargetPlayer.transform.position.x, TargetPlayer.transform.position.y, -10);

    }

    public float GetPlayerCameraRectX()
    {
        return set_rectx;

    }

}
