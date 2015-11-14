using UnityEngine;
using System.Collections;

public class monterFollowPlayer2Mesh : monsterFollow
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
                    GetComponent<monsterFollow>().SetTransition(Transition.SawPlayer);
                }
            }
        }
    }
}
