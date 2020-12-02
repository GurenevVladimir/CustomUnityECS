using System;
using System.Collections;
using System.ComponentModel;
using UnityEngine;

using TestProject.DevOOP.Units.Events;

namespace TestProject.DevOOP.Units
{
    public abstract partial class BaseGameUnit : MonoBehaviour, IUpdatable
    {
        // текущий список всех событий модулей Юнита, декомпозиция по типу события
        private EventHandlerList _unitEventList;


        partial void CreateUnitEvent()
        {
            _unitEventList = new EventHandlerList();
        }
        /// <summary>
        /// Function add unit workable event. 
        /// <para>Used <see cref="EventHandler"/></para>
        /// </summary>
        /// <param name="eventKey">Unique event key == EventArgs child type.</param>
        /// <param name="eventCallback">Event delegate.</param>
        private void AddUnitEvent(Type eventKey, EventHandler eventCallback)
        {
            _unitEventList.AddHandler(eventKey, eventCallback);
        }
        /// <summary>
        /// Function execute unit workable event depending on state.
        /// </summary>
        /// <param name="eventkey">Unique event key == EventArgs child type.</param>
        /// <param name="eventArg">Module use even data. </param>
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
    }
}