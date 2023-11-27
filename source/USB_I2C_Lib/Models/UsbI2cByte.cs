using System.Collections;
using AndreasReitberger.Interface.UsbI2C.Enums;

namespace AndreasReitberger.Interface.UsbI2C.Models
{
    public class UsbI2cByte
    {
        #region Static
        public static UsbI2cByte Default = new UsbI2cByte();
        #endregion

        #region Properties
        public UsbI2cBit Bit0 { get; set; } = UsbI2cBit.Keep;
        public UsbI2cBit Bit1 { get; set; } = UsbI2cBit.Keep;
        public UsbI2cBit Bit2 { get; set; } = UsbI2cBit.Keep;
        public UsbI2cBit Bit3 { get; set; } = UsbI2cBit.Keep;
        public UsbI2cBit Bit4 { get; set; } = UsbI2cBit.Keep;
        public UsbI2cBit Bit5 { get; set; } = UsbI2cBit.Keep;
        public UsbI2cBit Bit6 { get; set; } = UsbI2cBit.Keep;
        public UsbI2cBit Bit7 { get; set; } = UsbI2cBit.Keep;
        #endregion

        #region Constructor

        public UsbI2cByte() { }
        public UsbI2cByte(bool initialState)
        {
            if (initialState)
            {
                Bit0 = UsbI2cBit.Set;
                Bit1 = UsbI2cBit.Set;
                Bit2 = UsbI2cBit.Set;
                Bit3 = UsbI2cBit.Set;
                Bit4 = UsbI2cBit.Set;
                Bit5 = UsbI2cBit.Set;
                Bit6 = UsbI2cBit.Set;
                Bit7 = UsbI2cBit.Set;
            }
            else
            {
                Bit0 = UsbI2cBit.Reset;
                Bit1 = UsbI2cBit.Reset;
                Bit2 = UsbI2cBit.Reset;
                Bit3 = UsbI2cBit.Reset;
                Bit4 = UsbI2cBit.Reset;
                Bit5 = UsbI2cBit.Reset;
                Bit6 = UsbI2cBit.Reset;
                Bit7 = UsbI2cBit.Reset;
            }
        }
        #endregion

        #region Methods
        public void UpdateFromByte(byte state)
        {
            BitArray array = new BitArray(new byte[] { state });
            for (int i = 0; i < array?.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        Bit0 = array[i] ? UsbI2cBit.Set : UsbI2cBit.Reset;
                        break;
                    case 1:
                        Bit1 = array[i] ? UsbI2cBit.Set : UsbI2cBit.Reset;
                        break;
                    case 2:
                        Bit2 = array[i] ? UsbI2cBit.Set : UsbI2cBit.Reset;
                        break;
                    case 3:
                        Bit3 = array[i] ? UsbI2cBit.Set : UsbI2cBit.Reset;
                        break;
                    case 4:
                        Bit4 = array[i] ? UsbI2cBit.Set : UsbI2cBit.Reset;
                        break;
                    case 5:
                        Bit5 = array[i] ? UsbI2cBit.Set : UsbI2cBit.Reset;
                        break;
                    case 6:
                        Bit6 = array[i] ? UsbI2cBit.Set : UsbI2cBit.Reset;
                        break;
                    case 7:
                        Bit7 = array[i] ? UsbI2cBit.Set : UsbI2cBit.Reset;
                        break;
                    default:
                        break;
                }
            }
        }

        public void UpdateFromArray(UsbI2cBit[] array)
        {
            for (int i = 0; i < array?.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        Bit0 = array[i];
                        break;
                    case 1:
                        Bit1 = array[i];
                        break;
                    case 2:
                        Bit2 = array[i];
                        break;
                    case 3:
                        Bit3 = array[i];
                        break;
                    case 4:
                        Bit4 = array[i];
                        break;
                    case 5:
                        Bit5 = array[i];
                        break;
                    case 6:
                        Bit6 = array[i];
                        break;
                    case 7:
                        Bit7 = array[i];
                        break;
                    default:
                        break;
                }
            }
        }

        public UsbI2cBit[] ToArray()
        {
            return new UsbI2cBit[]
            {
                Bit0,
                Bit1,
                Bit2,
                Bit3,
                Bit4,
                Bit5,
                Bit6,
                Bit7
            };
        }

        #endregion
    }
}
