using UnityEngine;
using System.Collections;

public class Enemy : MovingObject {

    int p = 0;

    public override void nextTurn()
    {
        RaycastHit hit;
        switch (p++ % 4)
        {
            case 0:
                Move(1, 0, out hit);
                break;
            case 1:
                Move(0, 1, out hit);
                break;
            case 2:
                Move(-1, 0, out hit);
                break;
            case 3:
                Move(0, -1, out hit);
                break;
        }
    }

    protected override void OnCantMove(Transform blockingObject)
    {
        if(blockingObject.tag == "Player")
        {
            //Attack
            Debug.Log("Catiau");
            //Redo last move
        }
    }
}
