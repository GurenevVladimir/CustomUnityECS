using System;
using UnityEngine;

namespace TestProject.DevOOP.Units.Events
{
    public sealed class UnitMovementEventArgs : EventArgs
    {
        public UnitMovementEventArgs(Vector3 movePoint, float moveSpeed)
        {
            MovePoint = movePoint;
            MoveSpeed = moveSpeed;
        }

        public Vector3 MovePoint { set; get; }
        public float MoveSpeed { set; get; }
    }
}