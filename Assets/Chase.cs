using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    public Transform player;

    void Update()
    {
        if(Vector3.Distance(player.position, this.transform.position) < 13)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            if(direction.magnitude > 7)
            {
                this.transform.position = Vector3.Lerp(transform.position, player.position, .05f);
                
            }
           
        }

    }
}
