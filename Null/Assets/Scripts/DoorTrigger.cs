using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    private DoorSlide Door;

    private void Awake()
    {
        Door = FindFirstObjectByType<DoorSlide>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Collider>(out Collider controller))
        {
            if (!Door.IsOpen)
            {
                Door.Open(other.transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Collider>(out Collider controller))
        {
            if (Door.IsOpen)
            {
                Door.Close();
            }
        }
    }
    

}
