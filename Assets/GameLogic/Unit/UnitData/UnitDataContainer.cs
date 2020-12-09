using UnityEngine;

using TestProject.DevOOP.Core;

namespace TestProject.DevOOP.Units
{
    internal sealed class UnitDataContainer
    {
        internal UnitType UnitType { get => _unitType; }
        private UnitType _unitType = UnitType.None;
        //TODO запонить контейнер всеми типами данными
        private Vector3 _currentMovePoint;
        internal int CurrentMovePointIndex { get => _currentMovePointIndex; }
        private int _currentMovePointIndex;

        internal UnitDataContainer(Settings.UnitSettingSO setting)
        {
            _unitType = setting.UnitType;

            ResetUnitData();
        }

        internal void ResetUnitData()
        {
            _currentMovePointIndex = 1;
        }

        internal Vector3 GetCurrentMovePoint()
        {
            return Mediator.Instance.GetInstanceByType<NavigationHandler>().GetMovePoint(this);
        }

        internal void MovementComplite()
        {
            _currentMovePointIndex++;
            _currentMovePoint = Mediator.Instance.GetInstanceByType<NavigationHandler>().GetMovePoint(this);
        }
    }
}