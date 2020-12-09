using System.Collections;
using UnityEngine;

using TestProject.DevOOP.Units.Events;
using TestProject.DevOOP.Units.USM;
using TestProject.DevOOP.GamePool;

namespace TestProject.DevOOP.Units
{
    public abstract partial class BaseGameUnit : IUpdatable
    {
        internal UnitDataContainer UnitData { get => _unitData; }
        private UnitDataContainer _unitData;
        private IState<BaseGameUnit> _curentState;

        private void Start()
        {
            _unitData = new UnitDataContainer(_unitSetting);
        }

        #region Absttract Function
        public abstract void OnFixedUpdate();
        public abstract void OnUpdate();
        #endregion

        private void Update()
        {
            _curentState = UnitStateMachine.Instance.ProcessUSM(_curentState, this);
        }
    }
 }