using System.Collections.Generic;
using System.Linq;
using GameEngine;
using UnityEngine;

namespace SaveSystem
{
    public class UnitsSaveLoader : SaveLoader<UnitSaveData, UnitManager>
    {
        protected override UnitSaveData ConvertToSaveData(UnitManager service)
        {
            List<UnitData> dataToSave = new();
            var unitData = service.GetAllUnits();
            foreach (var record in unitData)
            {
                var id = record.GetInstanceID();
                var pos = record.Position;
                var rot = record.Rotation;
                dataToSave.Add(new UnitData()
                {
                    Id = id,
                    HP = record.HitPoints,
                    Position = new PositionData(pos.x, pos.y, pos.z),
                    Rotation = new RotationData(rot.x, rot.y, rot.z)
                });
            }
            
            return new UnitSaveData()
            {
                UnitDataList = dataToSave
            };
        }

        protected override void SetupData(UnitManager service, UnitSaveData data)
        {
            var unitData = data.UnitDataList;
            var currentUnits = service.GetAllUnits();
            List<Unit> newUnits = new();
            foreach (var record in unitData)
            {
                Vector3 position = new Vector3(record.Position.X, record.Position.Y, record.Position.Z);
                Vector3 eulerAngles = new Vector3(record.Rotation.X, record.Rotation.Y, record.Rotation.Z);
                var unit = currentUnits.FirstOrDefault(u => u.GetInstanceID() == record.Id);
                if (unit != null)
                {
                    var transform = unit.transform;
                    transform.position = position;
                    transform.eulerAngles = eulerAngles;
                    unit.HitPoints = record.HP;
                    newUnits.Add(unit);
                }
            }
            
            if (newUnits.Count != 0)
            {
                service.SetupUnits(newUnits);
            }
        }
    }
}