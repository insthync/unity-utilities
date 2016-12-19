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
