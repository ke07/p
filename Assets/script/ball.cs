using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : Bchara
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {

        TriggerCheck();

        //ループ処理
        CharaLoop();

        TriggerInitialize();

    }


}
