using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDetectionNode : Node
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public override int UpdateNode(EnemyAbstract con)
    {
        if (con.playerDetected == true)
        {
                if(con.playerCode.soundMade >= 5)
                {
                    Debug.Log("Heard");
                    return 2;
                }
            
        }
        return 0;
    }
}
