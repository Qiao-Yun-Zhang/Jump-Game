using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;
    public float moveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            m_rigidbody2D.velocity = new Vector3(moveSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            m_rigidbody2D.velocity = new Vector3(-moveSpeed, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            m_rigidbody2D.velocity = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space) == true)
        {
            m_rigidbody2D.velocity = new Vector3(0, 5, 0);
        }

        //transform.position = transform.position + new Vector3(1, 0, 0) * Time.deltaTime; // 遊戲執行中，外星人不斷往X軸移動1
        //transform.position += new Vector3(1, 0, 0) * Time.deltaTime; // 這樣的寫法和上一段是一樣的
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
        }
    }
}
