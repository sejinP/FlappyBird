using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        if(transform.position.x < -4f) Destroy(gameObject);
        if(!GameManager.GetInstance().isOver) transform.Translate(new Vector2(-1 * speed, 0) * Time.deltaTime);
    }
}
