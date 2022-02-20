using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bracket : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed = 30f;

    [SerializeField] private string axis;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = Input.GetAxisRaw(axis);

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v * speed);
    }
}
