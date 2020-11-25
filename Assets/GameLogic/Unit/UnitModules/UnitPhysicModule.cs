using System;
using UnityEngine;

namespace TestProject.DevOOP.Units.Modules
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]
    public sealed class UnitPhysicModule : BaseUnitModule
    {
        private Rigidbody _rigidbody;
        private SphereCollider _collider;

        #region Interface Function
        public override void AddModule(Action<Type, EventHandler> addEventHandler)
        {
            addEventHandler(typeof(Events.UnitMovementEventArgs), MovementEventCallback);
        }

        public override void RemoveModule(Action<Type, EventHandler> removeventHandler)
        {
            removeventHandler(typeof(Events.UnitMovementEventArgs), MovementEventCallback);
        }
        #endregion

        protected override void SetupModule()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.useGravity = false;

            _collider = GetComponent<SphereCollider>();
        }

        private void SetUnitForce(float force)
        {
            _rigidbody.velocity = _rigidbody.transform.forward * force;
        }

        private void MovementEventCallback(object sender, EventArgs eventArgs)
        {
            Debug.Log("TEST MOVE!");
            Debug.Log($"Module HASH = {this.GetHashCode()}");
            var message = (Events.UnitMovementEventArgs)eventArgs;
            Debug.Log(message.MoveSpeed);
            //SetUnitForce(eventArgs.MoveSpeed);
        }
    }
}