using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public int damp = 5;
    public bool canMove = true;

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {



            if (target != null)
            {
                float angle = 0;

                Vector3 relative = transform.InverseTransformPoint(target.position);
                angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
                transform.Rotate(0, 0, -angle);
            }

            Vector3 w = target.position;


            GetComponent<NavMeshAgent2D>().destination = w;
        }

    }
}
