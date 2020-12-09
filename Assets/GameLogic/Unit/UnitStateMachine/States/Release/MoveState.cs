using System;
using System.Collections;
using UnityEngine;

using TestProject.DevOOP.Units.Events;

namespace TestProject.DevOOP.Units.USM
{
    internal sealed class MoveState : BaseState
    {
        public override void EnterState()
        {
            _Debug.Log("Enter - Move State!");
            owner.ExecutUnitEvent(typeof(UnitMovementEventArgs), new UnitMovementEventArgs(owner.UnitData.GetCurrentMovePoint(), GameConst.MoveUnitSpeed));
        }

        public override Type ExecuteState()
        {
            Type resultStateType = this.GetType();
            //TODO check something trans-events
            //idle - transition
            var distance = (owner.UnitData.GetCurrentMovePoint() - owner.transform.position).magnitude;
            if (distance <= 0.25f)
            {
                resultStateType = typeof(IdleState);
            }

            return resultStateType;
        }

        public override void ExiteState()
        {
            _Debug.Log("Exit - Move State!");
            owner.UnitData.MovementComplite();
        }
    }
}