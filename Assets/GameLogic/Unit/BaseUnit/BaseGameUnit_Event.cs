using System;
using System.Collections;
using System.ComponentModel;
using UnityEngine;

using TestProject.DevOOP.Units.Events;

namespace TestProject.DevOOP.Units
{
    public abstract partial class BaseGameUnit : MonoBehaviour, IUpdatable
    {
        //test
        public float test_timer;
        // текущий список всех событий модулей Юнита, декомпозиция по типу события
        private EventHandlerList _unitEventList;


        partial void CreateUnitEvent()
        {
            _unitEventList = new EventHandlerList();
        }

        private void AddUnitEvent(Type eventKey, EventHandler eventCallback)
        {
            _unitEventList.AddHandler(eventKey, eventCallback);
        }

        private void ExecutUnitEvent(Type eventkey, EventArgs eventArg)
        {
            EventHandler copyEvent = (EventHandler)_unitEventList[eventkey];
            if (copyEvent is null) return;
            copyEvent(this, eventArg);
        }

        private void RemoveUnitEvent(Type eventKey, EventHandler eventCallback)
        {
            _unitEventList.RemoveHandler(eventKey, eventCallback);
        }

        private IEnumerator Test()
        {
            yield return new WaitForSeconds(test_timer);

            var eventArg = new UnitMovementEventArgs(Vector3.zero, 0f);
            ExecutUnitEvent(typeof(UnitMovementEventArgs), eventArg);

            yield return new WaitForSeconds(test_timer + 3);
            ExecutUnitEvent(typeof(UnitMovementEventArgs), eventArg);
        }
    }
}