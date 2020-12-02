using System;
using System.Collections.Generic;
using UnityEngine;

using TestProject.DevOOP.Units;

namespace TestProject.DevOOP.Core
{
    public sealed class NavigationHandler
    {
        private IList<Vector3> _gameMovePoint;

        public NavigationHandler()
        {
            FillMovePoint();
        }

        private void FillMovePoint()
        {
            List<GameNavPoint> points = new List<GameNavPoint>(GameObject.FindObjectsOfType<GameNavPoint>());
            int count = points.Count;
            _gameMovePoint = new List<Vector3>();

            //поиск pivot точки
            for (int i = 0; i < points.Count; ++i)
            {
                if (points[i].PointType == PointType.BasePointPlayer)
                {
                    _gameMovePoint.Add(points[i].Position);
                    points.Remove(points[i]);
                    break;
                }
            }
            for (int i = 1; i < count; ++i)
            {
                _gameMovePoint.Add(FindClosestPoint(_gameMovePoint[i - 1]));
            }

            //формируем путь 
            Vector3 FindClosestPoint(Vector3 pivot)
            {
                float minDistance = int.MaxValue;
                float currentDistance = 0f;
                int index = 0;
                for (int i = 0; i < points.Count; ++i)
                {
                    currentDistance = (points[i].Position - pivot).magnitude;
                    if (currentDistance < minDistance)
                    {
                        minDistance = currentDistance;
                        index = i;
                    }
                }
                Vector3 pointPos = points[index].Position;
                points.Remove(points[index]);
                return pointPos;
            }
        }

        internal Vector3 GetMovePoint(BaseGameUnit sender)
        {
            if(sender.GetUnitType() == UnitType.Player)
            {
                return GetMovePointByIndexPlayer(sender.MovepointIndex);
            }
            else
            {
                return GetMovePointByIndexEnemy(sender.MovepointIndex);
            }
        }

        private Vector3 GetMovePointByIndexPlayer(int index)
        {
            if(index > _gameMovePoint.Count)
            {
                index = _gameMovePoint.Count;
            }
            return _gameMovePoint[index];
        }


        private Vector3 GetMovePointByIndexEnemy(int index)
        {
            index = _gameMovePoint.Count - index;
            if (index < 0)
            {
                index = 0;
            }
            return _gameMovePoint[index];
        }
    }
}