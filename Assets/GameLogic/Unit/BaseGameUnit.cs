using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

using TestProject.DevOOP.Units.Events;
using TestProject.DevOOP.Units.Modules;

namespace TestProject.DevOOP.Units
{
    public abstract class BaseGameUnit : MonoBehaviour, IUnit, IUpdatable
    {
        //test
        public float test_timer;

        // текущий список всех событий модулей Юнита, декомпозиция по типу события
        private EventHandlerList _unitEventList;
        // текущий список всех модулей Юнита
        private IList<IUnitModule> _unitModuleList;

        private void Awake()
        {
            CreaateUnit();
        }

        private void Start()
        {
            //test
            StartCoroutine(Test());
        }

        #region Absttract Function

        public abstract void OnFixedUpdate();
        public abstract void OnUpdate();
        #endregion

        #region Virtual Function

        public virtual void CreaateUnit()
        {
            _unitEventList = new EventHandlerList();
            _unitModuleList = new List<IUnitModule>();
            //toda take modules from SO unit settings
            for(int i = 0; i < 2; ++i)//2 - is test
            {
                _unitModuleList.Add(CreateUnitModule<UnitPhysicModule>(this.transform));
                _unitModuleList[i].AddModule(AddUnitEvent);
            }
        }

        #endregion

        internal void ExecuteUnitState<T>(ref EventHandler<T> unitEvent, T eventMessage)
        {
            var eventCopy = unitEvent;
            if (eventCopy is null) return;
            eventCopy(this, eventMessage);
        }

        public T CreateUnitModule<T>(Transform parent)
            where T : MonoBehaviour
        {
            var module = new GameObject(typeof(T).ToString()).AddComponent<T>();
            module.transform.SetParent(parent);
            module.transform.localPosition = Vector3.zero;
            return module;
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

            yield return new WaitForSeconds(test_timer + 1);
            var rndIndex = UnityEngine.Random.Range(0, _unitModuleList.Count);
            _unitModuleList[rndIndex].RemoveModule(RemoveUnitEvent);

            yield return new WaitForSeconds(test_timer + 4);
            ExecutUnitEvent(typeof(UnitMovementEventArgs), eventArg);
        }
    }
}

