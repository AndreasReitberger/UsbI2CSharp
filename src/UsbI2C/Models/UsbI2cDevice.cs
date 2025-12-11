namespace AndreasReitberger.Interface.UsbI2C.Models
{
    public class UsbI2cDevice
    {
        #region Properties
        public int Id { get; set; }
        public string SerialNumber { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        #endregion
    }
}
