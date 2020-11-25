using UnityEngine;
using System.Collections;

namespace TestProject.DevOOP.Units
{
    public abstract partial class BaseGameUnit : MonoBehaviour, IUpdatable
    {
        #region Partial Function
        partial void CreateUnitEvent();
        partial void CreateUnitModules();
        #endregion

        private void Awake()
        {
            CreaateUnitExternal();
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

        public virtual void CreaateUnitExternal()
        {
            CreateUnitEvent();
            CreateUnitModules();
        }

        #endregion
    }
}

