using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMe : MonoBehaviour
{

    [SerializeField] GameObject followobject;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(followobject.transform);
    }
}
