using System;
using UnityEngine;

namespace TestProject.DevOOP.Units.Modules
{
    /// <summary>
    /// This class release unit physc.
    /// <para>Use Unity-component <see cref="Rigidbody"/></para>
    /// <para>Use Unity-component <see cref="SphereCollider"/></para>
    /// </summary>
    public sealed class UnitPhysicModule : BaseUnitModule
    {
        #region Interface Function
        public override void AddModule(Action<Type, EventHandler> addEventHandler, GameObject owner)
        {
            //addEventHandler(typeof(Events.UnitMovementEventArgs), MovementEventCallback);
            base.AddModule(addEventHandler, owner);
        }

        public override void RemoveModule(Action<Type, EventHandler> removeEventHandler)
        {
            removeEventHandler(typeof(Events.UnitMovementEventArgs), MovementEventCallback);
            base.RemoveModule(removeEventHandler);
        }
        #endregion
        protected override void SetupModule(GameObject owner)
        {
            base.SetupModule(owner);
            TryGetComponentInModule<Rigidbody>().useGravity = false;
        }

        private void SetUnitForce(float force)
        {
            //_rigidbody.velocity = _rigidbody.transform.forward * force;
        }

        private void MovementEventCallback(object sender, EventArgs eventArgs)
        {
            var message = (Events.UnitMovementEventArgs)eventArgs;
            Debug.Log(message.MoveSpeed);
            //SetUnitForce(eventArgs.MoveSpeed);
        }

        protected override Type[] GetRequireComponents()
        {
            return new Type[] { typeof(Rigidbody), typeof(SphereCollider) };
        }
    }
}