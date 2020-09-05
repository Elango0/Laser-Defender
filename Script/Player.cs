using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.6f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;


    // Start is called before the first frame update
    void Start()
    {
        setUpMove();
    }

    private void setUpMove()
    {
        Camera GameCamera = Camera.main;
        xMin = GameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = GameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = GameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = GameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXpos, newYpos);


    }
}
