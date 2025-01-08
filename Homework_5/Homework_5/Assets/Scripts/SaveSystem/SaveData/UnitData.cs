using System.Collections.Generic;

namespace SaveSystem
{
    public sealed class UnitSaveData
    {
        public List<UnitData> UnitDataList { get; set; }
    }
    public sealed class UnitData
    {
        public int Id { get; set; }
        public int HP { get; set; }
        public PositionData Position { get; set; }
        public RotationData Rotation { get; set; }
    }
}