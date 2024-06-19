using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door connectedDoor; // 연결된 문 오브젝트
    public float speed = 2f; // 문이 움직이는 속도

    private int collidingCount = 0; // 현재 접촉하고 있는 콜라이더의 수
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position; // 시작 시 초기 위치를 현재 위치로 설정
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collidingCount == 0) // 첫 번째 콜라이더가 접촉했을 때만 문을 엽니다.
        {
            connectedDoor.OpenDoor(speed);
        }
        collidingCount++; // 접촉하는 콜라이더의 수를 증가시킵니다.
    }

    private void OnTriggerExit(Collider other)
    {
        collidingCount--; // 접촉하는 콜라이더의 수를 감소시킵니다.
        if (collidingCount == 0) // 마지막 콜라이더가 벗어났을 때만 문을 닫습니다.
        {
            connectedDoor.CloseDoor(speed);
        }
    }
}

// using System.Collections;
// using UnityEngine;

// public class DoorTrigger : MonoBehaviour
// {
//     public Door connectedDoor; // 연결된 문 오브젝트
//     public float speed = 2f; // 문이 움직이는 속도
//     public string ignoreTag = "Ignore"; // 충돌을 무시할 태그

//     private Collider doorCollider;

//     void Start()
//     {
//         doorCollider = GetComponent<Collider>(); // 문 오브젝트의 콜라이더를 가져옴
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (doorCollider == null)
//         {
//             doorCollider = GetComponent<Collider>();
//             if (doorCollider == null)
//             {
//                 Debug.LogError("DoorTrigger: Door collider not found.");
//                 return;
//             }
//         }

//         if (other.CompareTag(ignoreTag))
//         {
//             if (other != null)
//             {
//                 // Ignore collisions with objects that have the "Ignore" tag
//                 Physics.IgnoreCollision(doorCollider, other);
//             }
//         }
//         else
//         {
//             // Call the method to open the door when another object enters the trigger
//             connectedDoor.OpenDoor(speed);
//         }
//     }


//     private void OnTriggerExit(Collider other)
//     {
//         if (!other.CompareTag(ignoreTag))
//         {
//             // 트리거에서 다른 오브젝트가 나가면 문을 닫는 메소드를 호출
//             connectedDoor.CloseDoor(speed);
//         }
//     }
// }
