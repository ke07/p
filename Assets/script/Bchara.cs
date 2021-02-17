using System.Collections;
using System.Collections.Generic;
using UnityEngine;



enum STAGE_STATE{

    ENTER,//入っている状態
    EXIT,//出た状態
    NONE,//入っていない状態
};

enum STAGE_KIND
{

    FRONT,
    BACK
};

public class Bchara : MonoBehaviour
{
    protected Vector2 velocity;
    bool isJump;

    [SerializeField] protected float move_speed;
    [SerializeField] protected float jump_power;

    [SerializeField] protected float decel_correct;

    STAGE_STATE stagefront_state;
    STAGE_STATE stageback_state;

    bool[] enter_flag = new bool[2];
    bool[] exit_flag = new bool[2];

    const float LoopAddLength = 0.25f;

    //int front_stagedata = new int
    //{
    //    { 0,0,0,0,0,0,0,0,0,0},


    //};



    SetStage setStage;


    protected void Start()
    {
        stagefront_state = STAGE_STATE.NONE;
        stageback_state = STAGE_STATE.NONE;

       setStage = GameObject.Find("system").GetComponent<SetStage>();

        TriggerInitialize();
    }

    protected void Jump()
    {
        if (!isJump)
        {
            isJump = true;
            velocity.y = jump_power;
        }
    }


    protected void OnCollisionEnter2D(Collision2D collision)
    {

        isJump = false;

    }

    protected void CharaLoop()
    {

        //Debug.Log(transform.position.x);


        //横ループ
        if (transform.position.x < -setStage.GetStageSize().x/2)
         {
            //Debug.Log("front " + stagefront_state);
            //Debug.Log("back " + stageback_state);
            //Debug.Log("3");

            //Debug.Break();

            transform.position = new Vector3(transform.position.x + setStage.GetStageSize().x * 2 - 0.5f - LoopAddLength, transform.position.y, transform.position.z);
            //enter_flag[(int)STAGE_KIND.BACK] = true;
            //exit_flag[(int)STAGE_KIND.FRONT] = false;
            stagefront_state = STAGE_STATE.NONE;
            stageback_state = STAGE_STATE.ENTER;

            //Debug.Log(setStage.GetStageSize().x * 2);
            //Debug.Log(transform.position.x);
        }
        else if (transform.position.x > setStage.GetStageSize().x * 3 / 2)
        {
            //Debug.Log("front " + stagefront_state);
            //Debug.Log("back " + stageback_state);
            //Debug.Log("4");

            //Debug.Break();

            transform.position = new Vector3(transform.position.x - setStage.GetStageSize().x * 2 + 0.5f + LoopAddLength, transform.position.y, transform.position.z);
            //enter_flag[(int)STAGE_KIND.FRONT] = true;
            //exit_flag[(int)STAGE_KIND.BACK] = false;
            stagefront_state = STAGE_STATE.ENTER;
            stageback_state = STAGE_STATE.NONE;
        }
        //縦ループ
        //表から出たとき
        else if (stagefront_state == STAGE_STATE.EXIT && stageback_state == STAGE_STATE.NONE)
        {
            //Debug.Log("front " + stagefront_state);
            //Debug.Log("back " + stageback_state);
            //Debug.Log("1");

            //Debug.Break();

            //上から出るか下から出るか
            float set_y = transform.position.y;
            if(transform.position.y > setStage.GetStageSize().y / 2 - 0.5f) set_y = transform.position.y - setStage.GetStageSize().y;
            else if (transform.position.y < -setStage.GetStageSize().y / 2 + 0.5f) set_y = transform.position.y + setStage.GetStageSize().y;

            transform.position = new Vector3(transform.position.x + setStage.GetStageSize().x, set_y, transform.position.z);


        }
        else if (stageback_state == STAGE_STATE.EXIT && stagefront_state == STAGE_STATE.NONE)
        {
            //Debug.Log("front " + stagefront_state);
            //Debug.Log("back " + stageback_state);
            //Debug.Break();
            float set_y = transform.position.y;
            if (transform.position.y > setStage.GetStageSize().y / 2 - 0.5f) set_y = transform.position.y - setStage.GetStageSize().y;
            else if (transform.position.y < -setStage.GetStageSize().y / 2 + 0.5f) set_y = transform.position.y + setStage.GetStageSize().y;


            transform.position = new Vector3(transform.position.x - setStage.GetStageSize().x, set_y, transform.position.z);

            //Debug.Log("2");

        }

        if (stagefront_state == STAGE_STATE.EXIT)
        {
            stagefront_state = STAGE_STATE.NONE;
        }
        if (stageback_state == STAGE_STATE.EXIT)
        {
            stageback_state = STAGE_STATE.NONE;
        }

    }



    protected void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.transform.name == "bg_front")
        {
            exit_flag[(int)STAGE_KIND.FRONT] = true;
            //stagefront_state = STAGE_STATE.EXIT;
            //Debug.Log("exit_front");
        }
        else if (collision.transform.name == "bg_back")
        {
            exit_flag[(int)STAGE_KIND.BACK] = true;
            //stageback_state = STAGE_STATE.EXIT;
            //Debug.Log("exit_back");
        }
    }


    protected void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.name == "bg_front")
        {
            enter_flag[(int)STAGE_KIND.FRONT] = true;
            //stagefront_state = STAGE_STATE.ENTER;
            //Debug.Log("stay_front");
        }
        else if (collision.name == "bg_back")
        {
            enter_flag[(int)STAGE_KIND.BACK] = true;
            //stageback_state = STAGE_STATE.ENTER;
            //Debug.Log("stay_back");
        }

    }

    protected void TriggerCheck()
    {

        //設定

        if (exit_flag[(int)STAGE_KIND.FRONT]) stagefront_state = STAGE_STATE.EXIT;
        if (exit_flag[(int)STAGE_KIND.BACK]) stageback_state = STAGE_STATE.EXIT;

        if (enter_flag[(int)STAGE_KIND.FRONT]) stagefront_state = STAGE_STATE.ENTER;
        if (enter_flag[(int)STAGE_KIND.BACK]) stageback_state = STAGE_STATE.ENTER;



    }


    protected void TriggerInitialize()
    {

        //初期化
        enter_flag[(int)STAGE_KIND.FRONT] = false;
        enter_flag[(int)STAGE_KIND.BACK] = false;
        exit_flag[(int)STAGE_KIND.FRONT] = false;
        exit_flag[(int)STAGE_KIND.BACK] = false;

    }


}
