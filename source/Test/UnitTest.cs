using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using USB_I2C_Lib;
using USB_I2C_Lib.Enums;
using USB_I2C_Lib.Models;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            USBI2CLib handler = new USBI2CLib(UsbI2cTypes.FT232RL);
            List<UsbI2cDevice> devices = handler.GetAllDevices();
            if(devices.Count == 0)
            {
                Assert.Fail("No usb device connected!");
                return;
            }
            if (handler.Initialize(0))
            {
                //string teststr = "S@ˆ";
                // SlaveAddresss 32
                handler.Reset(32);

                byte address = (byte)(128 + (int)UsbI2cRegisters.OutputPort);

                handler.SetSingleOutput(32, address, 7, true);
                handler.SetSingleOutput(32, address, 25, true);

                // Set single port
                handler.SetSinglePort(32, address, 2, 0b11110000);

                // Set all
                bool setAll = handler.SetOutput(
                   32,
                   address,
                   new UsbI2cByte(true),    // Port a
                   new UsbI2cByte(true),    // Port b
                   new UsbI2cByte(true),   // Port c
                   new UsbI2cByte(true),   // Port d
                   new UsbI2cByte(true)    // Port e
                   );
                Assert.IsTrue(setAll);

                handler.SetOutput(
                   32,
                   address,
                   new UsbI2cByte(true),    // Port a
                   new UsbI2cByte(false),   // Port b
                   new UsbI2cByte(false),   // Port c
                   new UsbI2cByte(false),   // Port d
                   new UsbI2cByte(false)    // Port e
                   );

                bool keep = handler.SetOutput(
                    32,
                    address,
                    new UsbI2cByte(false) { Bit0 = UsbI2cBit.Keep, Bit1 = UsbI2cBit.Keep, Bit2 = UsbI2cBit.Keep, Bit3 = UsbI2cBit.Keep },    // Port a
                    new UsbI2cByte(false),  // Port b
                    new UsbI2cByte(false),   // Port c
                    new UsbI2cByte(false),   // Port d
                    new UsbI2cByte(false)    // Port e
                    );
                Assert.IsTrue(keep);
                // Resett all
                Assert.IsTrue(handler.ClearOutput(32, address));
                handler.Close();
            }
            else
            {
                Assert.Fail("Initialize failed");
            }
            
        }
    }
}
