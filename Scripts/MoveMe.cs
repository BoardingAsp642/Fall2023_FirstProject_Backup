using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMe : MonoBehaviour
{

    //get the target position - the first position
    [SerializeField] GameObject firstPosition;

    [SerializeField] GameObject secondPosition;

    [SerializeField] GameObject thirdPosition;
    private GameObject nextPosition;

    [SerializeField] float speed;

    private Renderer sphereRenderer;
    private Renderer cubeRenderer;
    // Start is called before the first frame update
    void Start()
    {
        sphereRenderer = firstPosition.GetComponent<Renderer>();
        cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.material.color = Color.green;
        Debug.Log("Color start");

        // assign the first position as the next position
        nextPosition = firstPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // move the cube towards the sphere
        transform.position = Vector3.MoveTowards(transform.position, nextPosition.transform.position, speed);
        //when the object arrives at the first position change the color
        if(transform.position == firstPosition.transform.position)
        {
            cubeRenderer.material.color = sphereRenderer.material.color;
            nextPosition = secondPosition;
        }
        else if(transform.position == secondPosition.transform.position)
        {
            nextPosition = thirdPosition;
            cubeRenderer.material.color = Color.red;
        }
        else if (transform.position == thirdPosition.transform.position)
        {
            nextPosition = firstPosition;
            cubeRenderer.material.color = Color.yellow;
        }
    }
}
