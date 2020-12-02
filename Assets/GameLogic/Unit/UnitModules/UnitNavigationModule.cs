using System;
using UnityEngine;
using UnityEngine.AI;

namespace TestProject.DevOOP.Units.Modules
{
    /// <summary>
    /// This class is unit module for navigation in game.
    /// </summary>
    /// <remarks>Use Unity-component <see cref="NavMeshAgent"/></remarks>
    public sealed class UnitNavigationModule : BaseUnitModule
    {
        //TODO добавть настройки по-умолчани для всех типов юнитов в игре - смотрим по красоте!
        #region Override Function
        public override void AddModule(Action<Type, EventHandler> addEventHandler, GameObject owner)
        {
            addEventHandler(typeof(Events.UnitMovementEventArgs), MoveToPoint);
            base.AddModule(addEventHandler, owner);
        }

        public override void RemoveModule(Action<Type, EventHandler> removeEventHandler)
        {
            removeEventHandler(typeof(Events.UnitMovementEventArgs), MoveToPoint);
            base.RemoveModule(removeEventHandler);
        }

        protected override Type[] GetRequireComponents()
        {
            return new Type[] { typeof(NavMeshAgent) };
        }
        #endregion

        private void MoveToPoint(object sender, EventArgs eventArgs)
        {
            _Debug.Log("Nav Module Callback");
            var message = (Events.UnitMovementEventArgs)eventArgs;
            TryGetComponentInModule<NavMeshAgent>().SetDestination(message.MovePoint);
        }
    }
}