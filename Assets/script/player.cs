using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PLAYER_DIRECTION
{
    LEFT,
    RIGHT
}



public class player : Bchara
{

    PLAYER_DIRECTION direction;

    Vector3 respawn_point;


    // Start is called before the first frame update
    new void Start()
    {

        base.Start();


        respawn_point = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //キー入力
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity.x = move_speed;
            direction = PLAYER_DIRECTION.RIGHT;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity.x = -move_speed;
            direction = PLAYER_DIRECTION.LEFT;
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            Jump();
        }

        //リスポーン位置に戻る
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = respawn_point;
        }



        //移動
        transform.Translate(velocity.x, velocity.y, 0.0f);


        //減速
        velocity *= decel_correct;

        //スプライト反転
        if (velocity.x > 0.01f) transform.localScale = new Vector3(1, 1, 1);
        else if (velocity.x < -0.01f) transform.localScale = new Vector3(-1, 1, 1); ;

        //アニメーション
        GetComponent<Animator>().SetFloat("speed", Mathf.Abs(velocity.x));


        Debug.Log(GetComponent<Animator>().speed);
    }

    private void LateUpdate()
    {

        TriggerCheck();

        //ループ処理
        CharaLoop();

        TriggerInitialize();

    }


}
