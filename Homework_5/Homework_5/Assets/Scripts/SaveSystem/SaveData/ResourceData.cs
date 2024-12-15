using Newtonsoft.Json;
using UnityEngine;

namespace SaveSystem
{
    public class ResourceData
    {
        public string Id { get; set; }
        public int Amount { get; set; }
        
        public (float, float, float) Position { get; set; }
    }
}