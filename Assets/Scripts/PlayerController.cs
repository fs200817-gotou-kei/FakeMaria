using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// TODO: Jumpとか基本的な動作を定義したinterfaceとか必要そう
// Playerの操作一覧
public class PlayerController : MonoBehaviour
{
    // PlayerのRigidbodyコンポーネントへアクセス
    private Rigidbody2D rigid2D;

    // ジャンプ力
    private float jumpForce;

    // 走るスピードの上限
    private float maxRunSpeed;

    // 走る力
    private float runForce;

    void Start()
    {
        // アタッチを行ったオブジェトのRigidコンポーネントにアクセス
        this.rigid2D = GetComponent<Rigidbody2D>();

        // 各プロパティ初期化
        this.jumpForce = 600.0f;
        this.maxRunSpeed = 2.0f;
        this.runForce = 30.0f;
    }

    void Update()
    {
        // ジャンプボタンクリック時の処理
        caseJumpButton();

        // 左右ボタンクリック時の処理
        caseMoveSideButton();
    }

    // Playerがゴールの旗と接触した際に呼び出される
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ゴール");
        SceneManager.LoadScene("ClearScene");
    }

    // ジャンプされた場合の処理
    void caseJumpButton()
    {
        // ジャンプボタンが押されたか
        if (isJumpButton())
        {
            Debug.Log("スペースキーが押されました。");

            // ジャンプの高さ計算
            float haight = calculateJumpHaight();

            // ジャンプ
            jump(haight);
        }
    }

    // ジャンプの高さ計算
    float calculateJumpHaight()
    {
        // ジャンプ係数
        float coefficient = 1;
        return this.jumpForce * coefficient;
    }

    // 左右移動の場合の処理
    void caseMoveSideButton()
    {
        // 右矢印が押されたかどうか
        if (isRightButton())
        {
            Debug.Log("右矢印が押されました。");
            moveRight();
        }

        // 左矢印が押されたかどうか
        if (isLeftButton())
        {
            Debug.Log("左矢印が押されました。");
            moveLeft();
        }
    }

    // 走る速さ計算
    Vector2 calculateMoveSpeedX(float direction)
    {
        // 走るスピード計算
        Vector2 speed = transform.right * this.runForce;

        // 走る上限スピードを超えているか
        if (isMaxOver(speed))
        {
            // 走る上限スピードでスピードを計算
            return transform.right * direction * this.maxRunSpeed;
        }

        // 走る方向決定
        return speed * direction;
    }

    // 走る速さの上限を超えているか
    bool isMaxOver(Vector2 speed)
    {
        return speed.x > this.maxRunSpeed;
    }

    // ジャンプボタンを押したか
    bool isJumpButton()
    {
        // Spaceボタン(ジャンプボタン)を押したか
        return Input.GetKeyDown(KeyCode.Space);
    }

    // 左への移動処理
    void moveLeft()
    {

        // 左へ行くための係数
        float leftDirection = -1;

        // プレイヤーを反転
        turnPlayer(leftDirection);

        // スピード計算
        Vector2 speed = calculateMoveSpeedX(leftDirection);

        // 左方向
        this.rigid2D.AddForce(speed);
    }

    // 右への移動処理
    void moveRight()
    {
        // 右へ行くための係数
        float rightDirection = 1;

        // プレイヤーを反転
        turnPlayer(rightDirection);

        // スピード計算
        Vector2 speed = calculateMoveSpeedX(rightDirection);

        // 右方向
        this.rigid2D.AddForce(speed);
    }

    void turnPlayer(float direction)
    {
        float haightScale = 1;
        transform.localScale = new Vector2(direction, haightScale);
    }

    // 右矢印ボタンを押したか判定
    bool isRightButton()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }

    // 左矢印ボタンを押したか判定
    bool isLeftButton()
    {
        return Input.GetKey(KeyCode.LeftArrow);
    }

    // ジャンプ処理
    void jump(float haight)
    {
        this.rigid2D.AddForce(transform.up * haight);
    }
}
