# UsbI2CSharp
A library to communicate with the USB to UART IC FT232RL using the wrapper FTD2XX_NET.dll and
a connected I2C controller (PCA9505D66).

# How to use
In order to communicate with the `FT232RL`, create a new handler as shown below.

## Initialize
```cs
USBI2CLib handler = new USBI2CLib(UsbI2cTypes.FT232RL);
List<UsbI2cDevice> devices = handler.GetAllDevices();
```

Then, to enable communication to the device, call the `Initialize()` function.
```cs
// Initializes the first device found
bool success = handler.Initialize(0);

// Initializes the device with the provided serial number
success = handler.Initialize("UIDxxxxx");
```

## Reset
To reset all output states, call the Reset() function.
```cs
// SlaveAddresss: 32
handler.Reset(32);
```

## Outputs
To control the outputs, call one of these functions.
```cs
byte address = (byte)(128 + (int)UsbI2cRegisters.OutputPort);
// Set single bit
handler.SetSingleOutput(32, address, 7, true);

// Set single port
handler.SetSinglePort(32, address, 2, 0b11110000);

// Set all
bool setAll = handler.SetOutput(
   32,
   address,
   new UsbI2cByte(false) { Bit0 = UsbI2cBit.Keep, Bit1 = UsbI2cBit.Keep, Bit2 = UsbI2cBit.Keep, Bit3 = UsbI2cBit.Keep },
   new UsbI2cByte(true),   // Port b
   new UsbI2cByte(true),   // Port c
   new UsbI2cByte(true),   // Port d
   new UsbI2cByte(true)    // Port e
   );
```
