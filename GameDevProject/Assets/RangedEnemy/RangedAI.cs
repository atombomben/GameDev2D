using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RangedAI : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public Transform targetPosition;

    private Seeker seeker;

    public Path path;
    public float speed = 2;
    public float maxDistToWaypoint = 3;     // Max distance for the AI to continue
    private int currentWaypoint = 0;
    public bool reachedEndOfPath;

    public float repathRate = 0.5f;
    private float lastRepath = float.NegativeInfinity;

    public Attack attackScript;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        seeker = GetComponent<Seeker>();

        // Returns a Path object with two lists, Vector3 and GraphNode
        seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
    }

    public void OnPathComplete (Path p)
    {
        //Debug.Log("We got the path, and maybe this:" + p.error);
        //Debug.Log("This is the path length: " + p.vectorPath.Count);
        
        // Path pooling for efficiency, StartPath takes from pool if possible.
        p.Claim(this);

        if(!p.error) {
            if(path != null) path.Release(this); // Release previous path
            path = p;
            currentWaypoint = 0;
        } else {
            p.Release(this);
        }
    }

    void Update()
    {
        if(Time.time > lastRepath + repathRate && seeker.IsDone()) {
            lastRepath = Time.time;
            seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
        }
        // Do nothing if no path is present yet
        if(path == null)
        {
            return;
        }

        reachedEndOfPath = false;
        float distanceToNext;

        // Checks if next waypoint is close enough to switch
        // Loop, since many waypoints might be close to each other and we may reach several in one frame
        while(true) {
            distanceToNext = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if(distanceToNext < maxDistToWaypoint){
                // Checks if it's the last waypoint in the path
                if(currentWaypoint + 1 < path.vectorPath.Count) {
                    currentWaypoint++;
                } else {
                    reachedEndOfPath = true;
                    //ttackScript.Shoot();
                    break;
                }
            } else {
                break;
            }
        }

        // Slow down when approaching last waypoint
        var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToNext / maxDistToWaypoint) : 1f;

        Vector2 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;

        Vector3 velocity = dir * speed * speedFactor;

        transform.position += velocity * Time.deltaTime;
        spriteRenderer.flipX = targetPosition.position.x < transform.position.x;
        animator.SetFloat("speed", 10f);
    }
}
