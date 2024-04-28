using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWithMoveDirection : LevelInterface
{
    [SerializeField] private Vector3 moveVector = Vector3.forward;
    [SerializeField] private Player player;

    public Vector3 GetMoveVector()
    {
        return moveVector;
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    protected float PlayerFromgameObjectDistance(GameObject go)
    {
        return Vector3.Distance(go.transform.position, player.gameObject.transform.position);
    }
}
