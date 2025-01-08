using System.Collections.Generic;

namespace SaveSystem
{
    public sealed class ResourceSaveData
    {
        public List<ResourceData> ResourcesDataList { get; set; }
    }
    public sealed class ResourceData
    {
        public string Id { get; set; }
        public int Amount { get; set; }
        
        public PositionData Position { get; set; }
        public RotationData Rotation { get; set; }
    }
}