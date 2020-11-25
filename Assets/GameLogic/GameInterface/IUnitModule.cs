using System;

namespace TestProject.DevOOP.Units.Modules
{
    public interface IUnitModule
    {
        void AddModule(Action<Type, EventHandler> addEventHandler);
        void RemoveModule(Action<Type, EventHandler> removeEventHandler);
    }
}