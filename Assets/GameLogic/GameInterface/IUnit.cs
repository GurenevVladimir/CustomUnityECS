using UnityEngine;

namespace TestProject.DevOOP.Units
{
    public interface IUnit
    {
        T CreateUnitModule<T>(Transform parent) where T: MonoBehaviour;
    }
}