using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float moveSpeed;
    public float scorePoint;
    bool scoreUpdated = false;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.velocity = Vector2.left * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x < scorePoint)&& !scoreUpdated)
        {
            GameManager.instance.IncrementScore();
            scoreUpdated = true;
        }
        if (transform.position.x < -15f)
        {
            Debug.Log("Destroying obstacle");
            Destroy(gameObject);
        }
        
    }
}
