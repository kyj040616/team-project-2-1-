using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject itemPrefab; // 아이템 프리팹
    public AudioClip pickUpSound; // 아이템을 먹었을 때 재생할 사운드 클립
    private AudioSource audioSource; // AudioSource 컴포넌트

    // 위치와 회전을 함께 저장하는 클래스 정의
    private class ItemTransform
    {
        public Vector3 position;
        public Quaternion rotation;

        public ItemTransform(Vector3 pos, Quaternion rot)
        {
            position = pos;
            rotation = rot;
        }
    }

    private List<ItemTransform> itemTransforms = new List<ItemTransform>(); // 아이템 위치와 회전 리스트

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // AudioSource 컴포넌트 추가
        // 게임 시작 시 아이템을 생성합니다.
        // 초기 생성 위치와 회전 설정
    }

    public void RespawnItem(Vector3 position, Quaternion rotation)
    {
        itemTransforms.Add(new ItemTransform(position, rotation)); // 위치와 회전을 리스트에 추가
        StartCoroutine(RespawnItemCoroutine(position, rotation));
    }

    private IEnumerator RespawnItemCoroutine(Vector3 position, Quaternion rotation)
    {
        yield return new WaitForSeconds(2.0f); // 3초 대기
        SpawnItem(position, rotation); // 리스트에 저장된 위치와 회전에 아이템 재생성
        itemTransforms.RemoveAll(item => item.position == position && item.rotation == rotation); // 리스트에서 위치와 회전 제거
    }

    private void SpawnItem(Vector3 position, Quaternion rotation)
    {
        Instantiate(itemPrefab, position, rotation); // 지정된 위치와 회전에 아이템 생성
    }

    public void PlayPickUpSound()
    {
        if (audioSource != null && pickUpSound != null)
        {
            audioSource.PlayOneShot(pickUpSound);
        }
    }
}
