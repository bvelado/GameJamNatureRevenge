using UnityEngine;
using System.Collections;

public class monsterFollowPlayer : monstersFollow
{
    void OnTriggerStay(Collider col)
    {
        if ((col.tag == "Player") && (base.fsm.CurrentStateID == StateID.FollowingPath))
        {
            RaycastHit hit;
            if (Physics.Linecast(transform.position, col.transform.position, out hit))
            {
                if (hit.collider.tag == "Player" && hit.distance < 15f)
                {
                    GetComponent<monstersFollow>().SetTransition(Transition.SawPlayer);
                }
            }
        }
    }


    void OnTriggerExit(Collider col)
    {
        if ((col.tag == "Player") && (base.fsm.CurrentStateID == StateID.ChasingPlayer))
        {
            GetComponent<monstersFollow>().SetTransition(Transition.LostPlayer);
        }
    }

}
