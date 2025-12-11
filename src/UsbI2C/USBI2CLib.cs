using FTD2XX_NET;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AndreasReitberger.Interface.UsbI2C.Enums;
using AndreasReitberger.Interface.UsbI2C.Models;

namespace AndreasReitberger.Interface.UsbI2C
{
    public class USBI2CLib
    {
        #region Variables

        readonly FTDI _handler = new ();

        // ###### I2C Library defines ######
        const byte I2C_Dir_SDAin_SCLin = 0x00;
        const byte I2C_Dir_SDAin_SCLout = 0x01;
        const byte I2C_Dir_SDAout_SCLout = 0x03;
        const byte I2C_Dir_SDAout_SCLin = 0x02;
        const byte I2C_Data_SDAhi_SCLhi = 0x03;
        const byte I2C_Data_SDAlo_SCLhi = 0x01;
        const byte I2C_Data_SDAlo_SCLlo = 0x00;
        const byte I2C_Data_SDAhi_SCLlo = 0x02;
        // MPSSE clocking commands
        const byte MSB_FALLING_EDGE_CLOCK_BYTE_IN = 0x24;
        const byte MSB_RISING_EDGE_CLOCK_BYTE_IN = 0x20;
        const byte MSB_FALLING_EDGE_CLOCK_BYTE_OUT = 0x11;
        const byte MSB_DOWN_EDGE_CLOCK_BIT_IN = 0x26;
        const byte MSB_UP_EDGE_CLOCK_BYTE_IN = 0x20;
        const byte MSB_UP_EDGE_CLOCK_BYTE_OUT = 0x10;
        const byte MSB_RISING_EDGE_CLOCK_BIT_IN = 0x22;
        const byte MSB_FALLING_EDGE_CLOCK_BIT_OUT = 0x13;
        public const byte VCNL40x0_ADDRESS = 0x13;//0x13 is 7 bit address, 0x26 is 8bit address
        // registers
        public const byte REGISTER_COMMAND = 0x80;
        public const byte REGISTER_ID = 0x81;
        public const byte REGISTER_PROX_RATE = 0x82;
        public const byte REGISTER_PROX_CURRENT = 0x83;
        public const byte REGISTER_AMBI_PARAMETER = 0x84;
        public const byte REGISTER_AMBI_VALUE = 0x85;
        public const byte REGISTER_PROX_VALUE = 0x87;
        public const byte REGISTER_INTERRUPT_CONTROL = 0x89;
        public const byte REGISTER_INTERRUPT_LOW_THRES = 0x8a;
        public const byte REGISTER_INTERRUPT_HIGH_THRES = 0x8c;
        public const byte REGISTER_INTERRUPT_STATUS = 0x8e;
        public const byte REGISTER_PROX_TIMING = 0xf9;
        // Bits in the registers defined above
        public const byte COMMAND_SELFTIMED_MODE_ENABLE = 0x01;
        public const byte COMMAND_PROX_ENABLE = 0x02;
        public const byte COMMAND_AMBI_ENABLE = 0x04;
        public const byte COMMAND_MASK_PROX_DATA_READY = 0x20;
        public const byte PROX_MEASUREMENT_RATE_31 = 0x04;
        public const byte AMBI_PARA_AVERAGE_32 = 0x05; // DEFAULT
        public const byte AMBI_PARA_AUTO_OFFSET_ENABLE = 0x08; // DEFAULT enable
        public const byte AMBI_PARA_MEAS_RATE_2 = 0x10; // DEFAULT
        public const byte INTERRUPT_THRES_SEL_PROX = 0x00;
        public const byte INTERRUPT_THRES_ENABLE = 0x02;
        public const byte INTERRUPT_COUNT_EXCEED_1 = 0x00; // DEFAULT
        #endregion

        #region Properties
        UsbI2cTypes _type = UsbI2cTypes.FT232RL;
        public UsbI2cTypes Type
        {
            get => _type;
            set
            {
                if (_type == value) return;
                _type = value;
            }
        }

        #region Device
        string _manufacturer = string.Empty;
        public string Manufacturer
        {
            get => _manufacturer;
            set
            {
                if (_manufacturer == value) return;
                _manufacturer = value;
            }
        }

        EepromDefaultContent? eeprom;
        public EepromDefaultContent? EEPROM
        {
            get => eeprom;
            set
            {
                if (eeprom == value) return;
                eeprom = value;
            }
        }

        #endregion

        #region Clock
        uint _clockDivisor = 49;
        public uint ClockDivisor
        {
            get => _clockDivisor;
            set
            {
                if (_clockDivisor == value) return;
                _clockDivisor = value;
            }
        }

        #endregion

        #region GPIO
        byte _GPIO_Low_Dat = 0;
        public byte GPIO_Low_Dat
        {
            get => _GPIO_Low_Dat;
            set
            {
                if (_GPIO_Low_Dat == value) return;
                _GPIO_Low_Dat = value;
            }
        }
        byte _GPIO_Low_Dir = 0;
        public byte GPIO_Low_Dir
        {
            get => _GPIO_Low_Dir;
            set
            {
                if (_GPIO_Low_Dir == value) return;
                _GPIO_Low_Dir = value;
            }
        }
        byte _ADbusReadVal = 0;
        public byte ADbusReadVal
        {
            get => _ADbusReadVal;
            set
            {
                if (_ADbusReadVal == value) return;
                _ADbusReadVal = value;
            }
        }
        byte _ACbusReadVal = 0;
        public byte ACbusReadVal
        {
            get => _ACbusReadVal;
            set
            {
                if (_ACbusReadVal == value) return;
                _ACbusReadVal = value;
            }
        }
        #endregion

        #region I2C

        bool _I2C_Ack = false;
        public bool I2C_Ack
        {
            get => _I2C_Ack;
            set
            {
                if (_I2C_Ack == value) return;
                _I2C_Ack = value;
            }
        }

        uint _bytesAvailable = 0;
        public uint BytesAvailable
        {
            get => _bytesAvailable;
            set
            {
                if (_bytesAvailable == value) return;
                _bytesAvailable = value;
            }
        }

        uint _numBytesRead = 0;
        public uint NumBytesRead
        {
            get => _numBytesRead;
            set
            {
                if (_numBytesRead == value) return;
                _numBytesRead = value;
            }
        }

        uint _numBytesSent = 0;
        public uint NumBytesSent
        {
            get => _numBytesSent;
            set
            {
                if (_numBytesSent == value) return;
                _numBytesSent = value;
            }
        }

        uint _numBytesToSend = 0;
        public uint NumBytesToSend
        {
            get => _numBytesToSend;
            set
            {
                if (_numBytesToSend == value) return;
                _numBytesToSend = value;
            }
        }

        uint _numBytesToRead = 0;
        public uint NumBytesToRead
        {
            get => _numBytesToRead;
            set
            {
                if (_numBytesToRead == value) return;
                _numBytesToRead = value;
            }
        }

        byte[] _MPSSEbuffer = new byte[500];
        public byte[] MPSSEbuffer
        {
            get => _MPSSEbuffer;
            set
            {
                if (_MPSSEbuffer == value) return;
                _MPSSEbuffer = value;
            }
        }

        byte[] _InputBuffer = new byte[500];
        public byte[] InputBuffer
        {
            get => _InputBuffer;
            set
            {
                if (_InputBuffer == value) return;
                _InputBuffer = value;
            }
        }

        byte[] _InputBuffer2 = new byte[500];
        public byte[] InputBuffer2
        {
            get => _InputBuffer2;
            set
            {
                if (_InputBuffer2 == value) return;
                _InputBuffer2 = value;
            }
        }

        #endregion

        #endregion

        #region Ctor
        public USBI2CLib() { }
        public USBI2CLib(UsbI2cTypes type)
        {
            Type = type;
        }
        #endregion

        #region Methods

        #region Public

        #region Initialize
        public bool Initialize(uint index = 0)
        {
            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_DEVICE_NOT_FOUND;
            uint devcount = 0;
            try
            {
                // See if driver is loaded
                ftStatus = _handler.GetNumberOfDevices(ref devcount);
            }
            catch (Exception)
            {
                return false;
            }

            // Open device by index
            ftStatus = _handler.OpenByIndex(index);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                return false;
            }
            var eeprom = ReadEEPROM(Type);
            if (eeprom != null)
            {
                EEPROM = eeprom;
                Manufacturer = EEPROM.Manufacturer;
            }
            else
            {
                return false;
            }
            // Configure handler
            ConfigureHandler();
            // Configure i2c device
            //byte result = ConfigerI2CMpsse();
            //return result == 0;
            return true;
        }
        public bool Initialize(string serialNumber)
        {
            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_DEVICE_NOT_FOUND;
            uint devcount = 0;
            try
            {
                // See if driver is loaded
                ftStatus = _handler.GetNumberOfDevices(ref devcount);
            }
            catch (Exception)
            {
                return false;
            }

            // Open device by index
            ftStatus = _handler.OpenBySerialNumber(serialNumber);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                return false;
            }

            var eeprom = ReadEEPROM(Type);
            if (eeprom != null)
            {
                EEPROM = eeprom;
                Manufacturer = EEPROM.Manufacturer;
            }
            else
            {
                return false;
            }
            // Configure handler
            ConfigureHandler();
            // Configure i2c device
            //byte result = ConfigerI2CMpsse();
            //return result == 0;
            return true;
        }

        public bool Close()
        {
            FTDI.FT_STATUS? result = _handler?.Close();
            return result == FTDI.FT_STATUS.FT_OK;
        }
        #endregion

        #region Devices
        public int GetNumberOfDevices()
        {
            try
            {
                uint devcount = 0;
                FTDI.FT_STATUS result = _handler.GetNumberOfDevices(ref devcount);
                if (result == FTDI.FT_STATUS.FT_OK)
                {
                    return (int)devcount;
                }
                else
                    return -1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<UsbI2cDevice>? GetAllDevices(int maxBufferSize = 10)
        {
            List<FTDI.FT_DEVICE_INFO_NODE> nodes = GetAllDeviceNodes(maxBufferSize);
            return nodes?
                .Select(node => new UsbI2cDevice()
                {

                    Id = (int)node.ID,
                    SerialNumber = node.SerialNumber,
                    Type = node.Type.ToString(),
                })
                .ToList();
        }

        public bool OpenDevice(FTDI.FT_DEVICE_INFO_NODE device)
        {
            FTDI.FT_STATUS res = _handler.OpenBySerialNumber(device?.SerialNumber);
            return res == FTDI.FT_STATUS.FT_OK;
        }

        public EepromDefaultContent ReadEEPROM(UsbI2cTypes type)
        {
            EepromDefaultContent eeprom = new();
            switch (type)
            {
                case UsbI2cTypes.FT232RL:
                    var ft232r = new FTDI.FT232R_EEPROM_STRUCTURE();
                    _handler.ReadFT232REEPROM(ft232r);
                    eeprom = new EepromDefaultContent()
                    {
                        Manufacturer = ft232r.Manufacturer,
                        Description = ft232r.Description,
                        SerialNumber = ft232r.SerialNumber,

                        Cbus0 = ft232r.Cbus0,
                        Cbus1 = ft232r.Cbus1,
                        Cbus2 = ft232r.Cbus2,
                        Cbus3 = ft232r.Cbus3,
                        Cbus4 = ft232r.Cbus4,

                        PullDownEnable = ft232r.PullDownEnable,
                        RIsD2XX = ft232r.RIsD2XX,
                        SerNumEnable = ft232r.SerNumEnable,
                        UseExtOsc = ft232r.UseExtOsc,

                        EndpointSize = ft232r.EndpointSize,
                        HighDriveIOs = ft232r.HighDriveIOs,

                        InvertCTS = ft232r.InvertCTS,
                        InvertDCD = ft232r.InvertDCD,
                        InvertDSR = ft232r.InvertDSR,
                        InvertDTR = ft232r.InvertDTR,
                        InvertRI = ft232r.InvertRI,
                        InvertRTS = ft232r.InvertRTS,
                        InvertRXD = ft232r.InvertRXD,
                        InvertTXD = ft232r.InvertTXD,
                    };
                    break;
                case UsbI2cTypes.FT232H:
                    var ft232h = new FTDI.FT232H_EEPROM_STRUCTURE();
                    _handler.ReadFT232HEEPROM(ft232h);
                    break;
                case UsbI2cTypes.FT2232H:
                    var ft2232h = new FTDI.FT2232H_EEPROM_STRUCTURE();
                    _handler.ReadFT2232HEEPROM(ft2232h);
                    break;
                case UsbI2cTypes.FT4232H:
                    var ft4232h = new FTDI.FT4232H_EEPROM_STRUCTURE();
                    _handler.ReadFT4232HEEPROM(ft4232h);
                    break;
                default:
                    break;
            }
            return eeprom;
        }
        #endregion

        #region Write & Read
        public bool WriteOutput(uint slaveAddress, byte address, byte port_a, byte port_b, byte port_c, byte port_d, byte port_e)
        {
            byte[] data = new byte[]
            {
                address,
                port_a,
                port_b,
                port_c,
                port_d,
                port_e,
            };
            return WriteDataOutput(slaveAddress, data);
        }
        public bool WriteDataOutput(byte[] data)
        {
            uint writtenBytes = 0;
            FTDI.FT_STATUS result = _handler.Write(data, data.Length, ref writtenBytes);
            return result == FTDI.FT_STATUS.FT_OK;
        }
        public bool WriteDataOutput(uint slaveAddress, byte[] data)
        {
            //Write n-bytes to I2C
            //S CHAR  Slave - Adr. + W   Anz.Bytes Data 0  …	Data N  P CHAR
            //uint slaveAddress = 32;
            slaveAddress *= 2;

            string dataString = Encoding.ASCII.GetString(data);
            string addressString = Encoding.ASCII.GetString(new byte[] { (byte)slaveAddress });
            string lengthString = Encoding.ASCII.GetString(new byte[] { (byte)data.Length });

            // Create data buffer
            List<byte> buffer =
            [
                .. Encoding.ASCII.GetBytes("S"),
                .. Encoding.ASCII.GetBytes(addressString),    // Add addresss
                .. Encoding.ASCII.GetBytes(lengthString),     // Add length
            ];
            for (int i = 0; i < data.Length; i++)
            {
                buffer.Add(data[i]);
            }
            buffer.AddRange(Encoding.ASCII.GetBytes("P"));

            return Write(buffer.ToArray());
        }
        public bool WriteReadDataOutput(
            uint slaveAddress,
            uint address,
            byte port_a,
            byte port_b,
            byte port_c,
            byte port_d,
            byte port_e,
            byte[] readBuffer,
            uint bytesToRead)
        {
            byte[] data = new byte[]
            {
                (byte)address,
                port_a,
                port_b,
                port_c,
                port_d,
                port_e,
            };
            return WriteReadDataOutput(slaveAddress, data, readBuffer, bytesToRead);
        }

        public bool WriteReadDataOutput(uint slaveAddress, byte[] data, byte[] readBuffer, uint bytesToRead)
        {
            //Write n-bytes to I2C
            //S CHAR	Slave-Adr. +W	Anz. Bytes	Data 0	…	Data N	P CHAR
            //uint slaveAddress = 32;
            slaveAddress *= 2;
            string dataString = Encoding.ASCII.GetString(data);
            string addressString = Encoding.ASCII.GetString(new byte[] { (byte)slaveAddress });
            string lengthString = Encoding.ASCII.GetString(new byte[] { (byte)data.Length });
            string readAddressString = Encoding.ASCII.GetString(new byte[] { (byte)(slaveAddress + 1) });
            string bytesToReadString = Encoding.ASCII.GetString(new byte[] { (byte)(bytesToRead) });

            List<byte> buffer =
            [
                .. Encoding.ASCII.GetBytes("S"),
                .. Encoding.ASCII.GetBytes(addressString),    // Add addresss
                .. Encoding.ASCII.GetBytes(lengthString),     // Add length
            ];
            for (int i = 0; i < data.Length; i++)
            {
                buffer.Add(data[i]);
            }
            buffer.AddRange(Encoding.ASCII.GetBytes("S"));
            buffer.AddRange(Encoding.ASCII.GetBytes(readAddressString));
            buffer.AddRange(Encoding.ASCII.GetBytes(bytesToReadString));
            buffer.AddRange(Encoding.ASCII.GetBytes("P"));

            bool result = Write(buffer.ToArray());
            if (result)
            {
                uint bytesAvailable = 0;
                FTDI.FT_STATUS resultHandler = _handler.GetRxBytesAvailable(ref bytesAvailable);
                if (resultHandler == FTDI.FT_STATUS.FT_OK && bytesAvailable > 0)
                {
                    uint bytesRead = 0;
                    //byte[] buffer = new byte[bytesToRead + 1];
                    resultHandler = _handler.Read(readBuffer, bytesToRead, ref bytesRead);
                }
            }
            return result;
        }

        public bool ReadOutput(byte[] dataBuffer, uint bytesToRead)
        {
            uint bytesAvailable = 0;
            uint readBytes = 0;
            FTDI.FT_STATUS ftStatus = _handler.GetRxBytesAvailable(ref bytesAvailable);
            if (bytesAvailable > 0 && ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                FTDI.FT_STATUS result = _handler.Read(dataBuffer, bytesToRead, ref readBytes);
                return result == FTDI.FT_STATUS.FT_OK;
            }
            else
                return true;
        }
        #endregion

        #region Reset
        public void Reset(uint slaveAddress)
        {
            // Reset registers
            ResetRegister(slaveAddress, UsbI2cRegisters.IOConfig);
            ResetRegister(slaveAddress, UsbI2cRegisters.OutputPort);
        }
        public bool ResetRegister(uint slaveAddress, UsbI2cRegisters register)
        {
            return ResetRegister(slaveAddress, (uint)register);
        }
        public bool ResetRegister(uint slaveAddress, uint registerAddress)
        {
            uint baseAddress = 128;
            byte[] data = new byte[]
            {
                (byte)(baseAddress + registerAddress),
                0,  // Port
                0,  // Port_a
                0,  // Port_b
                0,  // Port_c
                0,  // Port_d
            };

            return WriteDataOutput(slaveAddress, data);
        }
        #endregion

        #region Outputs
        public bool SetSingleOutput(uint slaveAddress, uint registerAddress, uint output, bool state)
        {
            uint maxOutputs = (8 * 5) - 1; // 5 ports, each 8 bits
            if (output > maxOutputs)
            {
                throw new IndexOutOfRangeException($"The target output index '{output}' exceeds the number of available outputs of '{maxOutputs}'!");
            }
            // Prepare ports and set all to keep (default)
            UsbI2cByte[] ports = new UsbI2cByte[] {
                new(),   // Port A
                new(),   // Port B
                new(),   // Port C
                new(),   // Port D
                new(),   // Port E
            };
            int portIndex = (int)(output / 8);          // See in which port the target output is 
            int bit = (int)(output - (portIndex * 8));  // Get the bit on the current port

            var array = ports[portIndex].ToArray();
            array[bit] = state ? UsbI2cBit.Set : UsbI2cBit.Reset;

            ports[portIndex].UpdateFromArray(array);
            return SetOutput(slaveAddress, registerAddress, ports[0], ports[1], ports[2], ports[3], ports[4]);
        }

        public bool SetSinglePort(uint slaveAddress, uint registerAddress, uint port, byte state)
        {
            uint maxPorts = 4;      // 5 ports, 0..4
            if (port > maxPorts)    // 0..4
            {
                throw new IndexOutOfRangeException($"The target port index '{port}' exceeds the number of available outputs of '{maxPorts}'!");
            }
            // Prepare ports and set all to keep (default)
            UsbI2cByte[] ports = new UsbI2cByte[] {
                new(),   // Port A
                new(),   // Port B
                new(),   // Port C
                new(),   // Port D
                new(),   // Port E
            };
            ports[port].UpdateFromByte(state);
            return SetOutput(slaveAddress, registerAddress, ports[0], ports[1], ports[2], ports[3], ports[4]);
        }

        public bool SetOutput(uint slaveAddress, uint registerAddress,
            UsbI2cByte portA,
            UsbI2cByte portB,
            UsbI2cByte portC,
            UsbI2cByte portD,
            UsbI2cByte portE
            )
        {
            byte[] dataBuffer = new byte[7];
            // Read back current value set
            WriteReadDataOutput(slaveAddress, new byte[] { (byte)registerAddress }, dataBuffer, (uint)dataBuffer.Length);
            // Convert the tristate bytes into real bytes
            byte portAConverted = TristateByteToByte(portA, dataBuffer[2]);
            byte portBConverted = TristateByteToByte(portB, dataBuffer[3]);
            byte portCConverted = TristateByteToByte(portC, dataBuffer[4]);
            byte portDConverted = TristateByteToByte(portD, dataBuffer[5]);
            byte portEConverted = TristateByteToByte(portE, dataBuffer[6]);
            // Write new data to output
            return WriteOutput(slaveAddress, (byte)registerAddress,
                portAConverted,
                portBConverted,
                portCConverted,
                portDConverted,
                portEConverted);
        }

        public byte[] GetOutput(uint slaveAddress, uint registerAddress, int dataBufferSize = 7)
        {
            byte[] dataBuffer = new byte[dataBufferSize];
            // Read back current value set
            WriteReadDataOutput(slaveAddress, new byte[] { (byte)registerAddress }, dataBuffer, (uint)dataBuffer.Length);
            return dataBuffer;
        }

        public bool ClearOutput(uint slaveAddress, uint registerAddress)
        {
            return SetOutput(slaveAddress, registerAddress,
                new UsbI2cByte(false),     // Port a
                new UsbI2cByte(false),     // Port b
                new UsbI2cByte(false),     // Port c
                new UsbI2cByte(false),     // Port d
                new UsbI2cByte(false)      // Port e
                );
        }
        #endregion

        #endregion

        #region Private

        #region Devices
        List<FTDI.FT_DEVICE_INFO_NODE> GetAllDeviceNodes(int maxBufferSize = 10)
        {
            FTDI.FT_DEVICE_INFO_NODE[] buffer = new FTDI.FT_DEVICE_INFO_NODE[maxBufferSize];
            FTDI.FT_STATUS result = _handler.GetDeviceList(buffer);
            if (result == FTDI.FT_STATUS.FT_OK)
            {
                List<FTDI.FT_DEVICE_INFO_NODE> devices = [];
                for (int i = 0; i < buffer?.Length; i++)
                {
                    if (buffer?[i] is FTDI.FT_DEVICE_INFO_NODE node)
                    {
                        //devices.Add(buffer[i]);
                        devices.Add(node);
                    }
                }
                return devices;
            }
            else
                return [];
        }

        public bool OpenDeviceNode(FTDI.FT_DEVICE_INFO_NODE device)
        {
            FTDI.FT_STATUS res = _handler.OpenBySerialNumber(device?.SerialNumber);
            return res == FTDI.FT_STATUS.FT_OK;
        }

        void ConfigureHandler()
        {
            string port;
            _handler.GetCOMPort(out port);
            _handler.SetBaudRate(9600);
            // http://www.ftdichip.com/Support/Documents/AppNotes/AN_232R-01_Bit_Bang_Mode_Available_For_FT232R_and_Ft245R.pdf
            _handler.SetBitMode(
                0xCC, // 
                (byte)UsbI2cBitModes.CBUSBitBang  // CBUS Bit Bang
                );
            _handler.SetBitMode(
               0xC8, // 
               (byte)UsbI2cBitModes.CBUSBitBang  // CBUS Bit Bang
               );
            _handler.SetTimeouts(2000, 2000);
        }
        #endregion

        #region D2xxLayer
        byte FlushBuffer()
        {
            FTDI.FT_STATUS ftStatus = _handler.GetRxBytesAvailable(ref _bytesAvailable);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
                return 1;

            if (BytesAvailable > 0)
            {
                ftStatus = _handler.Read(InputBuffer, BytesAvailable, ref _numBytesRead);  	//Read out the data from receive buffer
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                    return 1;       // error
                else
                    return 0;       // all bytes successfully read
            }
            else
            {
                return 0;           // there were no bytes to read
            }
        }
        byte ReceiveData(uint BytesToRead)
        {
            uint NumBytesInQueue = 0;
            uint QueueTimeOut = 0;
            uint Buffer1Index = 0;
            uint Buffer2Index = 0;
            uint TotalBytesRead = 0;
            bool QueueTimeoutFlag = false;
            uint NumBytesRxd = 0;

            // Keep looping until all requested bytes are received or we've tried 5000 times (value can be chosen as required)
            while ((TotalBytesRead < BytesToRead) && (QueueTimeoutFlag == false))
            {
                FTDI.FT_STATUS ftStatus = _handler.GetRxBytesAvailable(ref NumBytesInQueue);       // Check bytes available

                if ((NumBytesInQueue > 0) && (ftStatus == FTDI.FT_STATUS.FT_OK))
                {
                    ftStatus = _handler.Read(InputBuffer, NumBytesInQueue, ref NumBytesRxd);  // if any available read them

                    if ((NumBytesInQueue == NumBytesRxd) && (ftStatus == FTDI.FT_STATUS.FT_OK))
                    {
                        Buffer1Index = 0;

                        while (Buffer1Index < NumBytesRxd)
                        {
                            InputBuffer2[Buffer2Index] = InputBuffer[Buffer1Index];     // copy into main overall application buffer
                            Buffer1Index++;
                            Buffer2Index++;
                        }
                        TotalBytesRead = TotalBytesRead + NumBytesRxd;                  // Keep track of total
                    }
                    else
                        return 1;

                    QueueTimeOut++;
                    if (QueueTimeOut == 5000)
                        QueueTimeoutFlag = true;
                    else
                        Thread.Sleep(0);                                                // Avoids running Queue status checks back to back
                }
            }
            // returning globals NumBytesRead and the buffer InputBuffer2
            NumBytesRead = TotalBytesRead;

            if (QueueTimeoutFlag == true)
                return 1;
            else
                return 0;
        }
        byte SendData(uint BytesToSend)
        {

            NumBytesToSend = BytesToSend;

            // Send data. This will return once all sent or if times out
            FTDI.FT_STATUS ftStatus = _handler.Write(MPSSEbuffer, NumBytesToSend, ref _numBytesSent);

            // Ensure that call completed OK and that all bytes sent as requested
            if ((NumBytesSent != NumBytesToSend) || (ftStatus != FTDI.FT_STATUS.FT_OK))
                return 1;   // error   calling function can check NumBytesSent to see how many got sent
            else
                return 0;   // success
        }

        bool Write(byte[] writeBuffer)
        {
            uint bytesWritten = 0;
            FTDI.FT_STATUS result = _handler.Write(writeBuffer, writeBuffer.Length, ref bytesWritten);
            return result == FTDI.FT_STATUS.FT_OK;
        }

        bool Read(byte[] readBuffer, uint bytesToRead)
        {
            uint bytesAvailable = 0;
            FTDI.FT_STATUS resultHandler = _handler.GetRxBytesAvailable(ref bytesAvailable);
            if (resultHandler == FTDI.FT_STATUS.FT_OK && bytesAvailable > 0)
            {
                uint bytesRead = 0;
                //byte[] buffer = new byte[bytesToRead + 1];
                resultHandler = _handler.Read(readBuffer, bytesToRead, ref bytesRead);
            }
            return resultHandler == FTDI.FT_STATUS.FT_OK;
        }

        void ResetGPIO(byte value = 0)
        {
            //Write the byte directly to the GPIO - port
            //O CHAR  Data P CHAR
            string dataString = $"O{value}P";
            byte[] writeBuffer = Encoding.ASCII.GetBytes(dataString);
            WriteDataOutput(writeBuffer);
        }
        void ResetI2CRegister(int register, byte value = 0x55)
        {
            //Write the byte directly to the GPIO - port
            //O CHAR  Data P CHAR
            string dataString = $"W{register}{value}P";
            byte[] writeBuffer = Encoding.ASCII.GetBytes(dataString);
            WriteDataOutput(writeBuffer);
        }
        #endregion

        #region ByteConversion
        byte TristateByteToByte(UsbI2cByte tristateByte, byte currentValue, bool swap = false)
        {
            byte[] result = new byte[1];
            BitArray conversionByte = new(new byte[1]);
            BitArray currentByte = new(new byte[] { currentValue });
            UsbI2cBit[] mask = tristateByte.ToArray();

            for (int i = 0; i < currentByte.Length; i++)
            {
                var bit = currentByte[i];
                var target = mask[i];
                if (target == UsbI2cBit.Reset)
                {
                    // Reset = low
                    conversionByte[i] = swap ? true : false;
                }
                else if (target == UsbI2cBit.Set)
                {
                    // Set = high
                    conversionByte[i] = swap ? false : true;
                }
                else
                {
                    // Keep current state
                    conversionByte[i] = bit;
                }
                //if()
            }
            conversionByte.CopyTo(result, 0);
            return result[0];
        }
        #endregion

        #endregion

        #endregion

    }
}
