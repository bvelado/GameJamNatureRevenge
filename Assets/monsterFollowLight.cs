using UnityEngine;
using System.Collections;

public class monster : monsterFollow
{
    void OnTriggerStay(Collider col)
    {
        if ((col.tag == "Light") && (base.fsm.CurrentStateID == StateID.FollowingPath))
        {
            RaycastHit hit;
            if (Physics.Linecast(transform.position, col.transform.position, out hit))
            {
                if (hit.collider.tag == "Light")
                {
                    GetComponent<monsterFollow>().SetTransition(Transition.SawPlayer);
                }
            }
        }
    }
}
