using UnityEngine;

public enum MOVE_TYPE
{
    UP, DOWN, LEFT, RIGHT,
    DIAG_UPRIGHT, DIAG_UPLEFT,
    DIAG_DOWNRIGHT, DIAG_DOWNLEFT,
    FOLLOW, WAIT,
    N_TYPES
};

public abstract class MovingObject : MonoBehaviour {

    [SerializeField]
    private LayerMask blockingLayer_;

    private CapsuleCollider capsuleCollider_;

    void Start()
    {
        capsuleCollider_ = GetComponent<CapsuleCollider>();
    }

    public abstract void nextTurn();

    protected bool Move(int xDir, int yDir, out RaycastHit hit)
    {
        Vector3 end = transform.position + new Vector3(xDir, 0f, yDir);
        Physics.Linecast(transform.position, end, out hit, blockingLayer_);

        if (hit.transform == null)
        {
            transform.Translate(xDir, 0f, yDir);
            return true;
        }

        return false;
    }

    protected void AttempMove(int xDir, int yDir)
    {
        RaycastHit hit;
        Vector3 end = transform.position + new Vector3(xDir, 0f, yDir);
        Physics.Linecast(transform.position, end, out hit, blockingLayer_);

        Transform blockingObject = hit.transform;

        if (blockingObject == null)
        {
            transform.Translate(xDir, 0f, yDir);
            return;
        }

        OnCantMove(blockingObject);
    }

    protected abstract void OnCantMove(Transform blockingObject);
}