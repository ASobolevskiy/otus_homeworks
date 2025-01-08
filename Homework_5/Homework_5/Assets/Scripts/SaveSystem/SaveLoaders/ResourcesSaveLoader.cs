using System.Collections.Generic;
using System.Linq;
using DI;
using GameEngine;
using UnityEngine;

namespace SaveSystem
{
    public class ResourcesSaveLoader : ISaveLoader
    {
        private ResourceService _resourceService;

        [Inject]
        public void Construct(ResourceService resourceService)
        {
            _resourceService = resourceService;
        }
        
        void ISaveLoader.SaveData(IGameRepository gameRepository)
        {
            List<ResourceData> dataToSave = new();
            var resourceData = _resourceService.GetResources();
            foreach (var record in resourceData)
            {
                var transform = record.transform;
                var pos = transform.position;
                var rot = transform.eulerAngles;
                dataToSave.Add(new ResourceData()
                {
                    Id = record.ID,
                    Amount = record.Amount,
                    Position = new PositionData(pos.x, pos.y, pos.z),
                    Rotation = new RotationData(rot.x, rot.y, rot.z)
                });
            }

            var resourceSaveData = new ResourceSaveData()
            {
                ResourcesDataList = dataToSave
            };
            gameRepository.SetData(resourceSaveData);
        }

        void ISaveLoader.LoadData(IGameRepository gameRepository)
        {
            if (!gameRepository.TryGetData(out ResourceSaveData data))
            {
                return;
            }

            var resourceData = data.ResourcesDataList;
            var currentResources = _resourceService.GetResources();
            List<Resource> newResources = new();
            foreach (var record in resourceData)
            {
                Vector3 position = new Vector3(record.Position.X, record.Position.Y, record.Position.Z);
                Vector3 eulerAngles = new Vector3(record.Rotation.X, record.Rotation.Y, record.Rotation.Z);
                var res = currentResources.FirstOrDefault(r => r.ID == record.Id);
                if (res != null)
                {
                    var transform = res.transform;
                    transform.position = position;
                    transform.eulerAngles = eulerAngles;
                    res.Amount = record.Amount;
                    newResources.Add(res);
                }
            }
            _resourceService.SetResources(newResources);
        }
    }
}