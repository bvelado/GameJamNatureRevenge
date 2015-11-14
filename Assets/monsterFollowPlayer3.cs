using UnityEngine;
using System.Collections;

public class monsterFollowPlayer3 : monstersFollow
{

    void OnTriggerStay(Collider col)
    {
        if ((col.tag == "Player") && (base.fsm.CurrentStateID == StateID.FollowingPath))
        {
            RaycastHit hit;
            if (Physics.Linecast(transform.position, col.transform.position, out hit))
            {
                if (hit.collider.tag == "Player")
                {
                    GetComponent<monstersFollow>().SetTransition(Transition.SawPlayer);
                }
            }
        }
    }
}
