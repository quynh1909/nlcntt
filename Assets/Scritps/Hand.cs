using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hand : MonoBehaviour
{
    public bool isLeft;
    public SpriteRenderer sprite;

    SpriteRenderer player;
    GameManager gameManager;

    Vector3 rightPos = new Vector3(0.35f, -0.15f, 0);
    Vector3 rightPosReverse = new Vector3(-0.15f, -0.15f, 0);
    Quaternion leftRot = Quaternion.Euler(0, 0, -35);
    Quaternion leftRotReverse = Quaternion.Euler(0, 0, -135);

    private void Awake()
    {
        player = transform.parent.GetComponentInParent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>(); // Tìm đối tượng GameManager trong scene
    }

    private void LateUpdate()
    {
        bool isReverse = player.flipX;

        // Kiểm tra trạng thái sống còn của trò chơi từ GameManager
        if (!gameManager.isLive)
        {
            // Nếu trò chơi không còn sống, ẩn hand
            gameObject.SetActive(false);
            return;
        }

        if (isLeft)
        {
            transform.localRotation = isReverse ? leftRotReverse : leftRot;
            sprite.flipY = isReverse;
            sprite.sortingOrder = isReverse ? 4 : 6;
        }
        else
        {
            transform.localPosition = isReverse ? rightPosReverse : rightPos;
            sprite.flipX = isReverse;
            sprite.sortingOrder = isReverse ? 6 : 4;
        }
    }
}
