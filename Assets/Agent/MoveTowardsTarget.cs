using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{
    private GameObject target;
    public float speed = 5f;
    public float distanceThreshold = 10f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        float squaredDistance = (target.transform.position - transform.position).sqrMagnitude;
        float squaredThreshold = distanceThreshold * distanceThreshold;

        if(squaredDistance > squaredThreshold)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
        else
        {
            Debug.Log("Target is at a small distance");
        }
    }
}
