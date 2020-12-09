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
            var arg = Mediator.Instance.GetInstanceByType<GamePool.UnitEventArgsPool>().Get(typeof(UnitMovementEventArgs)) as UnitMovementEventArgs;
            arg.MoveSpeed = GameConst.IdleUnitSpeed;
            arg.MovePoint = Vector3.zero;
            owner.ExecutUnitEvent(arg);
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