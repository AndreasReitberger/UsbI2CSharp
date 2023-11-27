namespace AndreasReitberger.Interface.UsbI2C.Enums
{
    public enum UsbI2cBitModes
    {
        ResetBitMode = 0,
        AsynchronousBitBang = 1,
        MPSSE = 2,
        SynchronousBitBang = 4,
        MCUHostBusEmulation = 8,
        FastOptoIsolatedSerial = 16,
        CBUSBitBang = 32,
        SingleChannel245SynchronousFIFO = 64,
    }
}
