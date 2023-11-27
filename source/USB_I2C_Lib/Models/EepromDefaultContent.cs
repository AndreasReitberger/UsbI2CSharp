using System;
using System.Collections.Generic;
using System.Text;

namespace AndreasReitberger.Interface.UsbI2C.Models
{
    public class EepromDefaultContent
    {
        #region Properties
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public bool UseExtOsc { get; set; }
        public byte Cbus4 { get; set; }
        public byte Cbus3 { get; set; }
        public byte Cbus2 { get; set; }
        public byte Cbus1 { get; set; }
        public byte Cbus0 { get; set; }
        public bool InvertRI { get; set; }
        public bool InvertDCD { get; set; }
        public bool InvertDSR { get; set; }
        public bool InvertDTR { get; set; }
        public bool InvertCTS { get; set; }
        public bool InvertRTS { get; set; }
        public bool InvertRXD { get; set; }
        public bool InvertTXD { get; set; }
        public bool SerNumEnable { get; set; }
        public bool PullDownEnable { get; set; }
        public byte EndpointSize { get; set; }
        public bool HighDriveIOs { get; set; }
        public bool RIsD2XX { get; set; }
        #endregion
    }
}
