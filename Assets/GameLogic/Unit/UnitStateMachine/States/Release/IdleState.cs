using System;
using UnityEngine;

using TestProject.DevOOP.Units.Events;

namespace TestProject.DevOOP.Units.USM
{
    internal sealed class IdleState : BaseState
    {
        public override void EnterState()
        {
            //TODO idle event for module - don't move!
            _Debug.Log("Enter - Idle Stae!");
            owner.ExecutUnitEvent(typeof(UnitMovementEventArgs), new UnitMovementEventArgs(Vector3.zero, GameConst.IdleUnitSpeed));
        }

        public override Type ExecuteState()
        {
            Type resultStateType = this.GetType();
            //TODO check something trans-events
            //move - transition
            var distance = (owner.UnitData.GetCurrentMovePoint() - owner.transform.position).magnitude;
            if(distance > 0.5f)
            {
                resultStateType = typeof(MoveState);
            }

            return resultStateType;
        }

        public override void ExiteState()
        {
            _Debug.Log("Exit - Idle State!");
        }
    }
}