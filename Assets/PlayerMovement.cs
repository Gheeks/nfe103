using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float rotateSpeedMovement = .2f;
    public float rotateVelocity;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            // If use navmesh
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity);
            if (hit.collider.tag == "Enemy")
            {

            }
            else
            {
                // Move player to hit point
                agent.SetDestination(hit.point);

                agent.speed = 4;

                // Dont affect combats
                agent.stoppingDistance = 0;

                // Rotate the player
                Quaternion rotationToLook = Quaternion.LookRotation(hit.point - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLook.eulerAngles.y, ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime * 10));

                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }
        }
    }
}
