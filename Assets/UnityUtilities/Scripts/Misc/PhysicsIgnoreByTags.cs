using UnityEngine;

public class PhysicsIgnoreByTags : MonoBehaviour
{
    public string[] ignoreCollisionTags;

    protected Collider physicCollider;
    public virtual Collider PhysicCollider
    {
        get
        {
            if (physicCollider == null)
                physicCollider = GetComponent<Collider>();
            return physicCollider;
        }
    }

    protected CharacterController physicCharacterController;
    public virtual CharacterController PhysicCharacterController
    {
        get
        {
            if (physicCharacterController == null)
                physicCharacterController = GetComponent<CharacterController>();
            return physicCharacterController;
        }
    }

    void IgnoreCollision(Collider collider1, Collider collider2)
    {
        for (int i = 0; i < ignoreCollisionTags.Length; ++i)
        {
            string ignoreCollisionTag = ignoreCollisionTags[i];
            if (ignoreCollisionTag != null && ignoreCollisionTag.Equals(collider1.tag))
            {
                Physics.IgnoreCollision(collider1, collider2, true);
                break;
            }
        }
    }

    void Awake()
    {
        if (PhysicCollider != null)
            IgnoreCollisionByRadius(PhysicCollider, PhysicCollider.bounds.size.x);
        if (PhysicCharacterController != null)
            IgnoreCollisionByRadius(PhysicCharacterController, PhysicCharacterController.bounds.size.x);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if (PhysicCollider != null)
            Gizmos.DrawWireSphere(PhysicCollider.bounds.center, PhysicCollider.bounds.size.x);
        if (PhysicCharacterController != null)
            Gizmos.DrawWireSphere(PhysicCharacterController.bounds.center, PhysicCharacterController.bounds.size.x);
    }

    void IgnoreCollisionByRadius(Collider targetCol, float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(targetCol.bounds.center, radius);
        for (int i = 0; i < colliders.Length; ++i)
        {
            Collider foundCol = colliders[i];
            IgnoreCollision(foundCol, targetCol);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IgnoreCollision(hit.collider, PhysicCharacterController);
    }

    void OnCollisionEnter(Collision collision)
    {
        IgnoreCollision(collision.collider, PhysicCollider);
    }

    void OnTriggerEnter(Collider collider)
    {
        IgnoreCollision(collider, PhysicCollider);
    }
}
