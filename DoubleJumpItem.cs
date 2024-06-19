using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpItem : MonoBehaviour
{
    private ItemManager itemManager;

    void Start()
    {
        itemManager = FindObjectOfType<ItemManager>(); // ItemManager 찾기
    }

    public void HandleItem()
    {
        Vector3 currentPosition = transform.position; // 현재 위치 저장
        Quaternion currentRotation = transform.rotation; // 현재 회전 저장
        itemManager.RespawnItem(currentPosition, currentRotation); // 현재 위치와 회전을 전달하여 아이템 재생성 요청

        // 사운드 재생
        itemManager.PlayPickUpSound();

        Destroy(gameObject); // 현재 아이템 삭제
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Jump jumpComponent = other.gameObject.GetComponent<Jump>();
            if (jumpComponent != null)
            {
                jumpComponent.AddDoubleJump(); // EnableDoubleJump 대신 AddDoubleJump 호출
                HandleItem(); // 아이템 처리 (삭제 등)
            }
        }
    }
}
