using System;
using UnityEngine;

namespace TestProject.DevOOP.Units.Modules
{
    public abstract class BaseUnitModule : MonoBehaviour, IUnitModule
    {
        private void Awake()
        {
            SetupModule();
        }
        public abstract void AddModule(Action<Type, EventHandler> addEventHandler);
        public abstract void RemoveModule(Action<Type, EventHandler> removeEventHandler);
        protected abstract void SetupModule();
    }
}