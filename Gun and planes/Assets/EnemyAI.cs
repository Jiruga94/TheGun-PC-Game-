using Pathfinding;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Seeker))]
public class EnemyAI : MonoBehaviour {

    public Transform target;
    public float updateRate = 2f;
    private Seeker seeker;
    private Rigidbody2D rb;

    public Path path;

    public float speed = 300f;
    public ForceMode2D fMode;
	[HideInInspector]
    public bool pathIsEnded=false;
    // the max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;
    private int currentWayPoint = 0;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        if (target==null)
        {
            Debug.Log("No player found");
            return;
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        StartCoroutine(UpdatePath());
    }
    IEnumerator UpdatePath()
    {
        if (target==null)
        {
            
            yield return false;
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }
    public void OnPathComplete(Path p) {
        Debug.Log("We got a path. Did it have an error" + p.error);
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }
     void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }
        if (path==null)
        
            return;
        if (currentWayPoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;

                pathIsEnded = true;
                return;
            }
            pathIsEnded = false;

            Vector3 dir = (path.vectorPath[currentWayPoint] - transform.position).normalized;
            dir *= speed * Time.fixedDeltaTime;
            rb.AddForce(dir, fMode);
            float distance = Vector3.Distance(transform.position, path.vectorPath[currentWayPoint]);
            if (distance<nextWaypointDistance)
            {
                currentWayPoint++;
                return;
            }
        }
        

               
    }
    private bool zwrocF()
    {
        return false;
    }
    
}
