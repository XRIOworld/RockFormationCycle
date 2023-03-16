using UnityEngine;
using OculusSampleFramework;

public class Magnet : MonoBehaviour
{
    public float snapDistance = 0.1f; // distance between the two objects for snap to occur
    public Vector3 snapPositionOffset = Vector3.zero; // offset from the snapping object's position
    public Quaternion snapRotationOffset = Quaternion.identity; // offset from the snapping object's rotation

    public OVRGrabbable grabbable;
    private Collider[] colliders;

    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
        colliders = GetComponents<Collider>();
    }

    void FixedUpdate()
    {
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, snapDistance);
        foreach (Collider collider in collidersInRange)
        {
            if (collider.gameObject != gameObject && collider.GetComponent<Magnet>())
            {
                Vector3 snapPosition = transform.position - collider.transform.position + snapPositionOffset;
                Quaternion snapRotation = Quaternion.Inverse(transform.rotation) * collider.transform.rotation * snapRotationOffset;
                Snap(collider.transform, snapPosition, snapRotation);
                break;
            }
        }
    }

    void Snap(Transform target, Vector3 snapPosition, Quaternion snapRotation)
    {
        Rigidbody targetRigidbody = target.GetComponent<Rigidbody>();

        targetRigidbody.velocity = Vector3.zero;
        targetRigidbody.angularVelocity = Vector3.zero;

        target.position = snapPosition;
        target.rotation = snapRotation;

        foreach (Collider collider in colliders)
        {
            Physics.IgnoreCollision(collider, target.GetComponent<Collider>());
        }

        Destroy(target.GetComponent<Magnet>());
        Destroy(GetComponent<Magnet>());
    }
}
