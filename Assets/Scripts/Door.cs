using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Скорость открывания/закрывания")]
    [Range(0.1f, 10f)]
    public float speed = 1;

    [Header("Дистанция реагирования")]
    [Range(1f, 10)]
    public float activeDistance = 3;

    [Header("Максимальный угол раскрытия")]
    [Range(0, 90)]
    public float angle = 90;

    [Header("Начальный угол раскрытия")]
    [Range(0, 90)]
    public float angle_0 = 0;

    [Header("Прерывать открывание/закрывание")]
    public bool interrupt = true;

    [Header("Обратное открывание")]
    public bool inverce = false;

    private float count = 0;
    private bool isGo = false;
    private float distance;
    private int inverceInt = 1;

    private IEnumerator openDoorCoroutine;
    private IEnumerator closeDoorCoroutine;

    IEnumerator OpenDoor()
    {
        if (closeDoorCoroutine != null)
            StopCoroutine(closeDoorCoroutine);
        isGo = true;

        while (count < angle)
        {
            if (distance > activeDistance && interrupt) break;
            count += speed;
            transform.rotation *= Quaternion.Euler(0, -speed * inverceInt, 0);
            yield return new WaitForSeconds(0.01f);
        }
        if (distance < activeDistance)
        {
            transform.rotation = Quaternion.Euler(0, -angle * inverceInt, 0);
        }
        isGo = false;
    }

    IEnumerator CloseDoor()
    {
        if (openDoorCoroutine != null)
            StopCoroutine(openDoorCoroutine);
        isGo = true;

        while (count > angle_0)
        {
            if (distance < activeDistance && interrupt) break;
            count -= speed;
            transform.rotation *= Quaternion.Euler(0, speed * inverceInt, 0);
            yield return new WaitForSeconds(0.01f);
        }
        if (distance > activeDistance)
        {
            transform.rotation = Quaternion.Euler(0, angle_0, 0);
        }
        isGo = false;
    }

    void Start()
    {
        count = angle_0;
        inverceInt = inverce ? -1 : 1;
    }

    void Update()
    {
        // if (!inverceInt) inverceInt = 1; else inverceInt = -1;

        distance = Vector3.Distance(transform.position, GetPlayerPosition.Instance.playerPosition);

        if (distance < activeDistance && !isGo)
        {
            openDoorCoroutine = OpenDoor();
            StartCoroutine(openDoorCoroutine);
        }

        if (distance > activeDistance && !isGo)
        {
            closeDoorCoroutine = CloseDoor();
            StartCoroutine(closeDoorCoroutine);
        }
    }
}