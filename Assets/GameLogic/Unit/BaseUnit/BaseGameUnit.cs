using UnityEngine;
using System.Collections;

using TestProject.DevOOP.Settings;
using TestProject.DevOOP.Units.Events;

namespace TestProject.DevOOP.Units
{
    /// <summary>
    /// Main Class all unit in game.
    /// </summary>
    /// <remarks>
    /// Subdivided on partial class:
    /// <list type="number">
    /// <item>
    /// <description>BaseGameUnit_Module - create all module path <see cref="CreateUnitModules"/>.</description>
    /// </item>
    /// <item>
    /// <description>BaseGameUnit_Event - create all unit-event for work path <see cref="CreateUnitEvent"/>.</description>
    /// </item>
    /// </list>
    /// </remarks>
    public abstract partial class BaseGameUnit : MonoBehaviour, IUpdatable
    {
        [SerializeField] private UnitSettingSO _unitSetting;
        public int MovepointIndex { get => _movepointIndex; }
        [SerializeField] private int _movepointIndex;
        [SerializeField] private bool _isMove;

        //TODO Сделать остальные раширения класса
        #region Partial Function
        partial void CreateUnitEvent();
        partial void CreateUnitModules();

        #endregion

        private void Awake()
        {
            CreateUnitEvent();
            CreateUnitModules();
        }
        //test!
        private void Start()
        {
            StartCoroutine(TestMoveState());

        }
        //TODO Сделать STM для юнита
        IEnumerator TestMoveState()
        {
            yield return new WaitForSeconds(2f);
            while (true)
            {
                yield return new WaitForFixedUpdate();
                if (_isMove)
                {

                }
                else
                {
                    _Debug.Log($"test - { Core.GameInstanceHandler.Instance.GetMovePointForUnit?.Invoke(this)}");
                    ExecutUnitEvent(typeof(UnitMovementEventArgs), new UnitMovementEventArgs(Core.GameInstanceHandler.Instance.GetMovePointForUnit.Invoke(this), 1f));
                    _isMove = true;
                }
            }
            
        }

        #region Absttract Function

        public abstract void OnFixedUpdate();
        public abstract void OnUpdate();
        #endregion

        #region Virtual Function

        public virtual UnitType GetUnitType()
        {
            return _unitSetting.UnitType;
        }

        #endregion
    }
}

