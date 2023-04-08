using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Playerの操作一覧
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private float jumpForce;
    private float runForce;

    void Start()
    {
        // アタッチを行ったオブジェトのRigidコンポーネントにアクセス
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.jumpForce = 600.0f;
        this.walkForce = 30.0f;
    }

    void Update()
    {
        // ジャンプボタンクリック時の処理
        caseJumpButton();

        // 左右ボタンクリック時の処理
        caseMoveSideButton();
    }

    void caseJumpButton()
    {
        // スペースボタンが押されたか
        if(isJumpButton())
        {
            float haight = calculateJumpHaight();
            jump(haight);
        }
    }

    float calculateJumpHaight()
    {
        return this.jumpForce * 0.01;
    }

    void caseMoveSideButton()
    {
        if(isRightButton())
        {
            float speedx = calculateMoveSpeedX();
            moveRight(speedx);
        }

        if(isLeftButton())
        {
            float speedx = calculateMoveSpeedX();
            moveLeft(speedx);
        }
    }

    float calculateSpeedX()
    {
        return Mathf.Abs(this.rigid2D.velocity.x);
    }


    void isJumpButton()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    void moveLeft(float speed)
    {
        this.rigid2D.AddForce(transform.left * speed);
    }

    void moveRight()
    {
        this.rigid2D.AddForce(transform.right * speed);
    }

    bool isRight()
    {
        return false;
    }

    bool isLeft()
    {
        return false;
    }

    void jump()
    {
        this.rigid2D.AddForce(transform.up * this.jumpForce);
    }
}
