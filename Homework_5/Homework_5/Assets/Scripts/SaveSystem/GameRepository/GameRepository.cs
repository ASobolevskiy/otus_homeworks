using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SaveSystem.CryptographicUtils;
using UnityEngine;

namespace SaveSystem
{
    public sealed class GameRepository : IGameRepository
    {
        private const string SAVE_FILE_NAME = "GameState.txt";
        
        private Dictionary<string, string> gameState = new();
        
        public bool TryGetData<T>(out T data)
        {
            var key = typeof(T).ToString();
            if (!gameState.ContainsKey(key))
            {
                data = default;
                return false;
            }

            var dataJson = gameState[key];
            data = JsonConvert.DeserializeObject<T>(dataJson);
            return true;
        }

        public void SetData<T>(T data)
        {
            var key = typeof(T).ToString();
            var dataJson = JsonConvert.SerializeObject(data);
            gameState[key] = dataJson;
        }

        public void SaveState()
        {
            var gameStateJson = JsonConvert.SerializeObject(gameState);
            var destination = $"{Application.persistentDataPath}/{SAVE_FILE_NAME}";
            FileStream file;
            
            if (File.Exists(destination))
            {
                File.Delete(destination);
            }
            
            file = File.Create(destination);

            var bytes = CryptoUtilities.Encrypt(gameStateJson);
            
            var length = bytes.Length;
            file.Write(bytes, 0, length);
            file.Flush();
            file.Dispose();
            Debug.Log("Game data saved!");
        }

        public void LoadState()
        {
            var destination = $"{Application.persistentDataPath}/{SAVE_FILE_NAME}";
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
            while (file.Read(buffer, 0, buffer.Length) != 0)
            {
                Debug.Log($"Reading save data");
            }
            file.Flush();
            file.Dispose();
            
            var jsonString = CryptoUtilities.Decrypt(buffer);
            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
            gameState = data;
        }
    }
}