using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingNode : Node
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public override int UpdateNode(EnemyAbstract con)
    {
        con.anim.SetBool("walking", true);
        Debug.Log("Chase");
        if (Vector3.Distance(con.transform.position, con.player.transform.position) > 1f)
        {
            //con.transform.position = Vector3.MoveTowards(con.transform.position, con.player.transform.position, con.speed * Time.deltaTime);
            //con.transform.LookAt(con.player.transform);
            con.Move(con.player.transform.position);
            return 1;
        }
        return 2;
    }
}
