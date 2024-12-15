using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DI;
using GameEngine;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveSystem
{
    public class ResourcesSaveLoader : ISaveLoader
    {
        private const string RESOURCE_SAVE_NAME = "Resources";
        private ResourceService _resourceService;

        [Inject]
        public void Construct(ResourceService resourceService)
        {
            _resourceService = resourceService;
        }
        
        void ISaveLoader.SaveData()
        {
            List<ResourceData> dataToSave = new();
            var resourceData = _resourceService.GetResources();
            foreach (var record in resourceData)
            {
                var pos = record.transform.position;
                dataToSave.Add(new ResourceData()
                {
                    Id = record.ID,
                    Amount = record.Amount,
                    Position = (pos.x, pos.y, pos.z)
                });
            }
            string destination = $"{Application.persistentDataPath}/{RESOURCE_SAVE_NAME}.txt";//Application.persistentDataPath + "/save.sav";
            FileStream file;

            if (File.Exists(destination))
            {
                file = File.OpenWrite(destination);
            }
            else
            {
                file = File.Create(destination);
            }

            var json = JsonConvert.SerializeObject(dataToSave);
            var bytes = Encoding.UTF8.GetBytes(json);
            var length = bytes.Length;
            file.Write(bytes, 0, length);
            file.Flush();
            file.Dispose();
            Debug.Log("Resources saved!");
        }

        void ISaveLoader.LoadData()
        {
            string destination = $"{Application.persistentDataPath}/{RESOURCE_SAVE_NAME}.txt";//Application.persistentDataPath + "/save.sav";
            FileStream file;

            if (File.Exists(destination))
            {
                file = File.OpenRead(destination);
            }
            else
            {
                Debug.LogError("File not found");
                return;
            }

            var buffer = new byte[file.Length];
            while (file.Read(buffer, 0, buffer.Length) == 1)
            {
                
            }

            var jsonString = Encoding.UTF8.GetString(buffer);
            var list = JsonConvert.DeserializeObject<List<ResourceData>>(jsonString);
            var resources = _resourceService.GetResources();
            List<Resource> newResources = new();
            foreach (var record in list)
            {
                Vector3 position = new Vector3(record.Position.Item1, record.Position.Item2, record.Position.Item3);
                var res = resources.FirstOrDefault(r => r.ID == record.Id);
                res.transform.position = position;
                res.Amount = record.Amount;
                newResources.Add(res);
            }
            _resourceService.SetResources(newResources);
        }
    }
}