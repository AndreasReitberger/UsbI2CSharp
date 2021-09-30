using System;
using System.Collections.Generic;
using System.Text;

namespace USB_I2C_Lib.Models
{
    public class UsbI2cDevice
    {
        #region Properties
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Type { get; set; }
        #endregion
    }
}
