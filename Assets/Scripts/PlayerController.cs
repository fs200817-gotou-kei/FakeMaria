using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private float jumpForce = 680.0f;

    void Start()
    {
        // アタッチを行ったオブジェトのRigidコンポーネントにアクセス
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // スペースボタンが押されたか
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }

    void jump()
    {
        this.rigid2D.AddForce(transform.up * this.jumpForce);
    }
}
