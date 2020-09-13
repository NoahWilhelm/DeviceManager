using DeviceManager.Core.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManager.Core.Devices.Models
{
    public class Device : BaseEntityModel<int>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DeviceTypeId { get; set; }
        public bool Failsafe { get; set; }
        public int TempMin { get; set; }
        public int TempMax { get; set; }
        public string InstallationPosition { get; set; }
        public bool InsertInto19InchCabinet { get; set; }
        public bool MotionEnable { get; set; }
        public bool SiplusCatalog { get; set; }
        public bool SimaticCatalog { get; set; }
        public int RotationAxisNumber { get; set; }
        public int PositionAxisNumber { get; set; }
        public bool? AdvancedEnvironmentalConditions { get; set; }
        public bool? TerminalElement { get; set; }
    }
}
