using UnityEngine;

public class HorrorObjectRotation : MonoBehaviour
{
    [SerializeField] private Transform customTarget;
    [SerializeField] private bool isCustom = false;

    private const float rotationTime = 20f;

    private Transform target;

    public Quaternion CurrentRotation { get; private set; } 

    private void Start()
    {
        if (isCustom == false)
        {
            target = FindObjectOfType<PlayerManager>().gameObject.transform;
        } else
        {
            return;
        }
    }

    void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        direction = new Vector3(direction.x, 0, direction.z);
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationTime * Time.deltaTime);

        CurrentRotation = rotation;
    }
}
