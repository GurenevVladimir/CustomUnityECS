using System;

namespace TestProject.DevOOP
{
    public interface IExecutableEvent
    {
        void ExecutUnitEvent(Type eventkey, EventArgs eventArg);
    }
}