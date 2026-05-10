using System.Collections;
using UnityEngine;

public class DoorSlide : MonoBehaviour
{
    public bool IsOpen = false;
    [SerializeField]
    private Vector3 SlideDirection = Vector3.back;
    [SerializeField]
    private float SlideAmount = 4f;

    private Vector3 StartPos;
    private Vector3 EndPos;
    [SerializeField]
    private float Speed;

    private Coroutine AnimationCoroutine;

    private void Awake()
    {
        StartPos = transform.position;
    }

    public void Open(Vector3 UserPosition)
    {
        if (!IsOpen)
        {
            if(AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
                
            }
            AnimationCoroutine = StartCoroutine(DoSlidingOpen());
        }
    }

    private IEnumerator DoSlidingOpen()
    {
        Vector3 endPosition = StartPos + SlideAmount * SlideDirection;
        Vector3 startPosition = transform.position;

        float time = 0;
        IsOpen = true;
        while(time < 1)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }

    public void Close()
    {
        if (IsOpen)
        {
            if(AnimationCoroutine != null)
            {
                StopCoroutine (AnimationCoroutine);
            }

            AnimationCoroutine = StartCoroutine(DoSlidingClosed());
        }
    }

    private IEnumerator DoSlidingClosed()
    {
        Vector3 endPosition = StartPos;
        Vector3 startPosition = transform.position;
        float time = 0;

        IsOpen = false;

        while(time < 1)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }
    }
}

/*bool open;

    float doorOpenHeight = 4.5f;
    float openSpeed = 2.0f;
    float defaultYposition;
    float currentYposition;
    float openTime = 0;

    void Start()
    {
        defaultYposition = transform.localPosition.y;
        currentYposition = transform.localPosition.y;
    }

    void DoorSlideWithoutKeyCard()
    {
        if(openTime < 1)
        {
            openTime += Time.deltaTime * openSpeed;
        }
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(currentYposition, defaultYposition + (open ? doorOpenHeight : 0), openTime), transform.localPosition.z);
    }

    void DoorSlideKeyCard()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) { 
            DoorSlideWithoutKeyCard();
            currentYposition = transform.localPosition.y;
        }
    }*/
