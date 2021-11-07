using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using USB_I2C_Lib;
using USB_I2C_Lib.Enums;
using USB_I2C_Lib.Models;
using UsbI2cControlPanel.Utilities;

namespace UsbI2cControlPanel.ViewModels
{
    class ControlPanelViewModel : ViewModelBase
    {
        #region Variables
        USBI2CLib handler;
        #endregion

        #region Properties
        private bool _isWorking = false;
        public bool IsWorking
        {
            get => _isWorking;
            set
            {
                if (_isWorking == value) return;
                _isWorking = value;
                OnPropertyChanged();
            }
        }

        private bool _isConnected = false;
        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                if (_isConnected == value) return;
                _isConnected = value;
                OnPropertyChanged();
            }
        }

        private uint _slaveAddress = 32;
        public uint SlaveAddress
        {
            get => _slaveAddress;
            set
            {
                if (_slaveAddress == value) return;
                _slaveAddress = value;
                OnPropertyChanged();
            }
        }

        private UsbI2cDevice _device;
        public UsbI2cDevice Device
        {
            get => _device;
            set
            {
                if (_device == value) return;
                _device = value;
                OnPropertyChanged();
            }
        }

        private List<UsbI2cDevice> _devices = new List<UsbI2cDevice>();
        public List<UsbI2cDevice> Devices
        {
            get => _devices;
            set
            {
                if (_devices == value) return;
                _devices = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Bytes

        #region Byte0
        private bool _bit0_enabled = false;
        public bool Bit0_Enabled
        {
            get => _bit0_enabled;
            set
            {
                if (_bit0_enabled == value) return;
                _bit0_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit0 = false;
        public bool Bit0
        {
            get => _bit0;
            set
            {
                if (_bit0 == value) return;
                _bit0 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit1_enabled = false;
        public bool Bit1_Enabled
        {
            get => _bit1_enabled;
            set
            {
                if (_bit1_enabled == value) return;
                _bit1_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit1 = false;
        public bool Bit1
        {
            get => _bit1;
            set
            {
                if (_bit1 == value) return;
                _bit1 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit2_enabled = false;
        public bool Bit2_Enabled
        {
            get => _bit2_enabled;
            set
            {
                if (_bit2_enabled == value) return;
                _bit2_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit2 = false;
        public bool Bit2
        {
            get => _bit2;
            set
            {
                if (_bit2 == value) return;
                _bit2 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit3_enabled = false;
        public bool Bit3_Enabled
        {
            get => _bit3_enabled;
            set
            {
                if (_bit3_enabled == value) return;
                _bit3_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit3 = false;
        public bool Bit3
        {
            get => _bit3;
            set
            {
                if (_bit3 == value) return;
                _bit3 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit4_enabled = false;
        public bool Bit4_Enabled
        {
            get => _bit4_enabled;
            set
            {
                if (_bit4_enabled == value) return;
                _bit4_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit4 = false;
        public bool Bit4
        {
            get => _bit4;
            set
            {
                if (_bit4 == value) return;
                _bit4 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit5_enabled = false;
        public bool Bit5_Enabled
        {
            get => _bit5_enabled;
            set
            {
                if (_bit5_enabled == value) return;
                _bit5_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit5 = false;
        public bool Bit5
        {
            get => _bit5;
            set
            {
                if (_bit5 == value) return;
                _bit5 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit6_enabled = false;
        public bool Bit6_Enabled
        {
            get => _bit6_enabled;
            set
            {
                if (_bit6_enabled == value) return;
                _bit6_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit6 = false;
        public bool Bit6
        {
            get => _bit6;
            set
            {
                if (_bit6 == value) return;
                _bit6 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit7_enabled = false;
        public bool Bit7_Enabled
        {
            get => _bit7_enabled;
            set
            {
                if (_bit7_enabled == value) return;
                _bit7_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit7 = false;
        public bool Bit7
        {
            get => _bit7;
            set
            {
                if (_bit7 == value) return;
                _bit7 = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Byte1
        private bool _bit8_enabled = false;
        public bool Bit8_Enabled
        {
            get => _bit8_enabled;
            set
            {
                if (_bit8_enabled == value) return;
                _bit8_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit8 = false;
        public bool Bit8
        {
            get => _bit8;
            set
            {
                if (_bit8 == value) return;
                _bit8 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit9_enabled = false;
        public bool Bit9_Enabled
        {
            get => _bit9_enabled;
            set
            {
                if (_bit9_enabled == value) return;
                _bit9_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit9 = false;
        public bool Bit9
        {
            get => _bit9;
            set
            {
                if (_bit9 == value) return;
                _bit9 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit10_enabled = false;
        public bool Bit10_Enabled
        {
            get => _bit10_enabled;
            set
            {
                if (_bit10_enabled == value) return;
                _bit10_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit10 = false;
        public bool Bit10
        {
            get => _bit10;
            set
            {
                if (_bit10 == value) return;
                _bit10 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit11_enabled = false;
        public bool Bit11_Enabled
        {
            get => _bit11_enabled;
            set
            {
                if (_bit11_enabled == value) return;
                _bit11_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit11 = false;
        public bool Bit11
        {
            get => _bit11;
            set
            {
                if (_bit11 == value) return;
                _bit11 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit12_enabled = false;
        public bool Bit12_Enabled
        {
            get => _bit12_enabled;
            set
            {
                if (_bit12_enabled == value) return;
                _bit12_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit12 = false;
        public bool Bit12
        {
            get => _bit12;
            set
            {
                if (_bit12 == value) return;
                _bit12 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit13_enabled = false;
        public bool Bit13_Enabled
        {
            get => _bit13_enabled;
            set
            {
                if (_bit13_enabled == value) return;
                _bit13_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit13 = false;
        public bool Bit13
        {
            get => _bit13;
            set
            {
                if (_bit13 == value) return;
                _bit13 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit14_enabled = false;
        public bool Bit14_Enabled
        {
            get => _bit14_enabled;
            set
            {
                if (_bit14_enabled == value) return;
                _bit14_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit14 = false;
        public bool Bit14
        {
            get => _bit14;
            set
            {
                if (_bit14 == value) return;
                _bit14 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit15_enabled = false;
        public bool Bit15_Enabled
        {
            get => _bit15_enabled;
            set
            {
                if (_bit15_enabled == value) return;
                _bit15_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit15 = false;
        public bool Bit15
        {
            get => _bit15;
            set
            {
                if (_bit15 == value) return;
                _bit15 = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Byte2
        private bool _bit16_enabled = false;
        public bool Bit16_Enabled
        {
            get => _bit16_enabled;
            set
            {
                if (_bit16_enabled == value) return;
                _bit16_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit16 = false;
        public bool Bit16
        {
            get => _bit16;
            set
            {
                if (_bit16 == value) return;
                _bit16 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit17_enabled = false;
        public bool Bit17_Enabled
        {
            get => _bit17_enabled;
            set
            {
                if (_bit17_enabled == value) return;
                _bit17_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit17 = false;
        public bool Bit17
        {
            get => _bit17;
            set
            {
                if (_bit17 == value) return;
                _bit17 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit18_enabled = false;
        public bool Bit18_Enabled
        {
            get => _bit18_enabled;
            set
            {
                if (_bit18_enabled == value) return;
                _bit18_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit18 = false;
        public bool Bit18
        {
            get => _bit18;
            set
            {
                if (_bit18 == value) return;
                _bit18 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit19_enabled = false;
        public bool Bit19_Enabled
        {
            get => _bit19_enabled;
            set
            {
                if (_bit19_enabled == value) return;
                _bit19_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit19 = false;
        public bool Bit19
        {
            get => _bit19;
            set
            {
                if (_bit19 == value) return;
                _bit19 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit20_enabled = false;
        public bool Bit20_Enabled
        {
            get => _bit20_enabled;
            set
            {
                if (_bit20_enabled == value) return;
                _bit20_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit20 = false;
        public bool Bit20
        {
            get => _bit20;
            set
            {
                if (_bit20 == value) return;
                _bit20 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit21_enabled = false;
        public bool Bit21_Enabled
        {
            get => _bit21_enabled;
            set
            {
                if (_bit21_enabled == value) return;
                _bit21_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit21 = false;
        public bool Bit21
        {
            get => _bit21;
            set
            {
                if (_bit21 == value) return;
                _bit21 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit22_enabled = false;
        public bool Bit22_Enabled
        {
            get => _bit22_enabled;
            set
            {
                if (_bit22_enabled == value) return;
                _bit22_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit22 = false;
        public bool Bit22
        {
            get => _bit22;
            set
            {
                if (_bit22 == value) return;
                _bit22 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit23_enabled = false;
        public bool Bit23_Enabled
        {
            get => _bit23_enabled;
            set
            {
                if (_bit23_enabled == value) return;
                _bit23_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit23 = false;
        public bool Bit23
        {
            get => _bit23;
            set
            {
                if (_bit23 == value) return;
                _bit23 = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Byte3
        private bool _bit24_enabled = false;
        public bool Bit24_Enabled
        {
            get => _bit24_enabled;
            set
            {
                if (_bit24_enabled == value) return;
                _bit24_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit24 = false;
        public bool Bit24
        {
            get => _bit24;
            set
            {
                if (_bit24 == value) return;
                _bit24 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit25_enabled = false;
        public bool Bit25_Enabled
        {
            get => _bit25_enabled;
            set
            {
                if (_bit25_enabled == value) return;
                _bit25_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit25 = false;
        public bool Bit25
        {
            get => _bit25;
            set
            {
                if (_bit25 == value) return;
                _bit25 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit26_enabled = false;
        public bool Bit26_Enabled
        {
            get => _bit26_enabled;
            set
            {
                if (_bit26_enabled == value) return;
                _bit26_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit26 = false;
        public bool Bit26
        {
            get => _bit26;
            set
            {
                if (_bit26 == value) return;
                _bit26 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit27_enabled = false;
        public bool Bit27_Enabled
        {
            get => _bit27_enabled;
            set
            {
                if (_bit27_enabled == value) return;
                _bit27_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit27 = false;
        public bool Bit27
        {
            get => _bit27;
            set
            {
                if (_bit27 == value) return;
                _bit27 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit28_enabled = false;
        public bool Bit28_Enabled
        {
            get => _bit28_enabled;
            set
            {
                if (_bit28_enabled == value) return;
                _bit28_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit28 = false;
        public bool Bit28
        {
            get => _bit28;
            set
            {
                if (_bit28 == value) return;
                _bit28 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit29_enabled = false;
        public bool Bit29_Enabled
        {
            get => _bit29_enabled;
            set
            {
                if (_bit29_enabled == value) return;
                _bit29_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit29 = false;
        public bool Bit29
        {
            get => _bit29;
            set
            {
                if (_bit29 == value) return;
                _bit29 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit30_enabled = false;
        public bool Bit30_Enabled
        {
            get => _bit30_enabled;
            set
            {
                if (_bit30_enabled == value) return;
                _bit30_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit30 = false;
        public bool Bit30
        {
            get => _bit30;
            set
            {
                if (_bit30 == value) return;
                _bit30 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit31_enabled = false;
        public bool Bit31_Enabled
        {
            get => _bit31_enabled;
            set
            {
                if (_bit31_enabled == value) return;
                _bit31_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit31 = false;
        public bool Bit31
        {
            get => _bit31;
            set
            {
                if (_bit31 == value) return;
                _bit31 = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Byte3
        private bool _bit32_enabled = false;
        public bool Bit32_Enabled
        {
            get => _bit32_enabled;
            set
            {
                if (_bit32_enabled == value) return;
                _bit32_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit32 = false;
        public bool Bit32
        {
            get => _bit32;
            set
            {
                if (_bit32 == value) return;
                _bit32 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit33_enabled = false;
        public bool Bit33_Enabled
        {
            get => _bit33_enabled;
            set
            {
                if (_bit33_enabled == value) return;
                _bit33_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit33 = false;
        public bool Bit33
        {
            get => _bit33;
            set
            {
                if (_bit33 == value) return;
                _bit33 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit34_enabled = false;
        public bool Bit34_Enabled
        {
            get => _bit34_enabled;
            set
            {
                if (_bit34_enabled == value) return;
                _bit34_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit34 = false;
        public bool Bit34
        {
            get => _bit34;
            set
            {
                if (_bit34 == value) return;
                _bit34 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit35_enabled = false;
        public bool Bit35_Enabled
        {
            get => _bit35_enabled;
            set
            {
                if (_bit35_enabled == value) return;
                _bit35_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit35 = false;
        public bool Bit35
        {
            get => _bit35;
            set
            {
                if (_bit35 == value) return;
                _bit35 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit36_enabled = false;
        public bool Bit36_Enabled
        {
            get => _bit36_enabled;
            set
            {
                if (_bit36_enabled == value) return;
                _bit36_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit36 = false;
        public bool Bit36
        {
            get => _bit36;
            set
            {
                if (_bit36 == value) return;
                _bit36 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit37_enabled = false;
        public bool Bit37_Enabled
        {
            get => _bit37_enabled;
            set
            {
                if (_bit37_enabled == value) return;
                _bit37_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit37 = false;
        public bool Bit37
        {
            get => _bit37;
            set
            {
                if (_bit37 == value) return;
                _bit37 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit38_enabled = false;
        public bool Bit38_Enabled
        {
            get => _bit38_enabled;
            set
            {
                if (_bit38_enabled == value) return;
                _bit38_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit38 = false;
        public bool Bit38
        {
            get => _bit38;
            set
            {
                if (_bit38 == value) return;
                _bit38 = value;
                OnPropertyChanged();
            }
        }

        private bool _bit39_enabled = false;
        public bool Bit39_Enabled
        {
            get => _bit39_enabled;
            set
            {
                if (_bit39_enabled == value) return;
                _bit39_enabled = value;
                OnPropertyChanged();
            }
        }
        private bool _bit39 = false;
        public bool Bit39
        {
            get => _bit39;
            set
            {
                if (_bit39 == value) return;
                _bit39 = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #endregion

        #region Constructor
        public ControlPanelViewModel()
        {
            handler = new USBI2CLib(UsbI2cTypes.FT232RL);
            Devices = handler?.GetAllDevices();
        }
        #endregion

        #region ICommands
        public ICommand RefreshUsbDevicesCommand
        {
            get => new RelayCommand(cmd => RefreshUsbDevicesAction());
        }
        private void RefreshUsbDevicesAction()
        {
            try
            {
                IsWorking = true;
                Devices = handler?.GetAllDevices();
            }
            catch (Exception exc)
            {
            }
            IsWorking = false;
        }

        public ICommand ConnectToUsbDeviceCommand
        {
            get => new RelayCommand(cmd => ConnectToUsbDeviceAction());
        }
        private void ConnectToUsbDeviceAction()
        {
            try
            {
                IsWorking = true;
                if (Device != null && handler.Initialize(Device.SerialNumber))
                {
                    //string teststr = "S@ˆ";
                    // SlaveAddresss 32
                    handler.Reset(32);
                    IsConnected = true;
                }
            }
            catch (Exception exc)
            {
            }
            IsWorking = false;
        }

        public ICommand DisonnectToUsbDeviceCommand
        {
            get => new RelayCommand(cmd => DisonnectToUsbDeviceAction());
        }
        private void DisonnectToUsbDeviceAction()
        {
            try
            {
                IsWorking = true;
                handler?.Close();
                IsConnected = false;
            }
            catch (Exception exc)
            {
            }
            IsWorking = false;
        }

        public ICommand EnableDisableAllPortsCommand
        {
            get => new RelayCommand(cmd => EnableDisableAllPortsAction(cmd));
        }
        private void EnableDisableAllPortsAction(object paramter)
        {
            try
            {
                if (paramter is string str)
                {
                    IsWorking = true;
                    // Port A
                    Bit0_Enabled = str == "set";
                    Bit1_Enabled = str == "set";
                    Bit2_Enabled = str == "set";
                    Bit3_Enabled = str == "set";
                    Bit4_Enabled = str == "set";
                    Bit5_Enabled = str == "set";
                    Bit6_Enabled = str == "set";
                    Bit7_Enabled = str == "set";
                    // Port B
                    Bit8_Enabled = str == "set";
                    Bit9_Enabled = str == "set";
                    Bit10_Enabled = str == "set";
                    Bit11_Enabled = str == "set";
                    Bit12_Enabled = str == "set";
                    Bit13_Enabled = str == "set";
                    Bit14_Enabled = str == "set";
                    Bit15_Enabled = str == "set";
                    // Port C
                    Bit16_Enabled = str == "set";
                    Bit17_Enabled = str == "set";
                    Bit18_Enabled = str == "set";
                    Bit19_Enabled = str == "set";
                    Bit20_Enabled = str == "set";
                    Bit21_Enabled = str == "set";
                    Bit22_Enabled = str == "set";
                    Bit23_Enabled = str == "set";
                    // Port D
                    Bit24_Enabled = str == "set";
                    Bit25_Enabled = str == "set";
                    Bit26_Enabled = str == "set";
                    Bit27_Enabled = str == "set";
                    Bit28_Enabled = str == "set";
                    Bit29_Enabled = str == "set";
                    Bit30_Enabled = str == "set";
                    Bit31_Enabled = str == "set";
                    // Port E
                    Bit32_Enabled = str == "set";
                    Bit33_Enabled = str == "set";
                    Bit34_Enabled = str == "set";
                    Bit35_Enabled = str == "set";
                    Bit36_Enabled = str == "set";
                    Bit37_Enabled = str == "set";
                    Bit38_Enabled = str == "set";
                    Bit39_Enabled = str == "set";
                }
            }
            catch (Exception exc)
            {
            }
            IsWorking = false;
        }

        public ICommand SetResetPortCommand
        {
            get => new RelayCommand(cmd => SetResetPortAction(cmd));
        }
        private void SetResetPortAction(object paramter)
        {
            try
            {
                if (paramter is string str)
                {
                    IsWorking = true;
                    string[] parts = str.Split('|');
                    switch (parts[0])
                    {
                        case "a":
                            // Port A
                            Bit0 = parts[1] == "set";
                            Bit1 = parts[1] == "set";
                            Bit2 = parts[1] == "set";
                            Bit3 = parts[1] == "set";
                            Bit4 = parts[1] == "set";
                            Bit5 = parts[1] == "set";
                            Bit6 = parts[1] == "set";
                            Bit7 = parts[1] == "set";
                            break;
                        case "b":
                            // Port B
                            Bit8 = parts[1] == "set";
                            Bit9 = parts[1] == "set";
                            Bit10 = parts[1] == "set";
                            Bit11 = parts[1] == "set";
                            Bit12 = parts[1] == "set";
                            Bit13 = parts[1] == "set";
                            Bit14 = parts[1] == "set";
                            Bit15 = parts[1] == "set";
                            break;
                        case "c":
                            // Port C
                            Bit16 = parts[1] == "set";
                            Bit17 = parts[1] == "set";
                            Bit18 = parts[1] == "set";
                            Bit19 = parts[1] == "set";
                            Bit20 = parts[1] == "set";
                            Bit21 = parts[1] == "set";
                            Bit22 = parts[1] == "set";
                            Bit23 = parts[1] == "set";
                            break;
                        case "d":
                            // Port D
                            Bit24 = parts[1] == "set";
                            Bit25 = parts[1] == "set";
                            Bit26 = parts[1] == "set";
                            Bit27 = parts[1] == "set";
                            Bit28 = parts[1] == "set";
                            Bit29 = parts[1] == "set";
                            Bit30 = parts[1] == "set";
                            Bit31 = parts[1] == "set";
                            break;
                        case "e":
                            // Port E
                            Bit32 = parts[1] == "set";
                            Bit33 = parts[1] == "set";
                            Bit34 = parts[1] == "set";
                            Bit35 = parts[1] == "set";
                            Bit36 = parts[1] == "set";
                            Bit37 = parts[1] == "set";
                            Bit38 = parts[1] == "set";
                            Bit39 = parts[1] == "set";
                            break;
                        case "all":
                            // Port A
                            Bit0 = parts[1] == "set";
                            Bit1 = parts[1] == "set";
                            Bit2 = parts[1] == "set";
                            Bit3 = parts[1] == "set";
                            Bit4 = parts[1] == "set";
                            Bit5 = parts[1] == "set";
                            Bit6 = parts[1] == "set";
                            Bit7 = parts[1] == "set";
                            // Port B
                            Bit8 = parts[1] == "set";
                            Bit9 = parts[1] == "set";
                            Bit10 = parts[1] == "set";
                            Bit11 = parts[1] == "set";
                            Bit12 = parts[1] == "set";
                            Bit13 = parts[1] == "set";
                            Bit14 = parts[1] == "set";
                            Bit15 = parts[1] == "set";
                            // Port C
                            Bit16 = parts[1] == "set";
                            Bit17 = parts[1] == "set";
                            Bit18 = parts[1] == "set";
                            Bit19 = parts[1] == "set";
                            Bit20 = parts[1] == "set";
                            Bit21 = parts[1] == "set";
                            Bit22 = parts[1] == "set";
                            Bit23 = parts[1] == "set";
                            // Port D
                            Bit24 = parts[1] == "set";
                            Bit25 = parts[1] == "set";
                            Bit26 = parts[1] == "set";
                            Bit27 = parts[1] == "set";
                            Bit28 = parts[1] == "set";
                            Bit29 = parts[1] == "set";
                            Bit30 = parts[1] == "set";
                            Bit31 = parts[1] == "set";
                            // Port E
                            Bit32 = parts[1] == "set";
                            Bit33 = parts[1] == "set";
                            Bit34 = parts[1] == "set";
                            Bit35 = parts[1] == "set";
                            Bit36 = parts[1] == "set";
                            Bit37 = parts[1] == "set";
                            Bit38 = parts[1] == "set";
                            Bit39 = parts[1] == "set";
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception exc)
            {
            }
            IsWorking = false;
        }

        public ICommand SendBitsToUsbCommand
        {
            get => new RelayCommand(cmd => SendBitsToUsbAction());
        }
        private void SendBitsToUsbAction()
        {
            try
            {
                IsWorking = true;
                UsbI2cByte byte0 = new UsbI2cByte()
                {
                    Bit0 = Bit0_Enabled ? Bit0 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit1 = Bit1_Enabled ? Bit1 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit2 = Bit2_Enabled ? Bit2 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit3 = Bit3_Enabled ? Bit3 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit4 = Bit4_Enabled ? Bit4 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit5 = Bit5_Enabled ? Bit5 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit6 = Bit6_Enabled ? Bit6 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit7 = Bit7_Enabled ? Bit7 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                };
                UsbI2cByte byte1 = new UsbI2cByte()
                {
                    Bit0 = Bit8_Enabled ? Bit8 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit1 = Bit9_Enabled ? Bit9 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit2 = Bit10_Enabled ? Bit10 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit3 = Bit11_Enabled ? Bit11 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit4 = Bit12_Enabled ? Bit12 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit5 = Bit13_Enabled ? Bit13 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit6 = Bit14_Enabled ? Bit14 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit7 = Bit15_Enabled ? Bit15 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                };
                UsbI2cByte byte2 = new UsbI2cByte()
                {
                    Bit0 = Bit16_Enabled ? Bit16 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit1 = Bit17_Enabled ? Bit17 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit2 = Bit18_Enabled ? Bit18 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit3 = Bit19_Enabled ? Bit19 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit4 = Bit20_Enabled ? Bit20 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit5 = Bit21_Enabled ? Bit21 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit6 = Bit22_Enabled ? Bit22 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit7 = Bit23_Enabled ? Bit23 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                };
                UsbI2cByte byte3 = new UsbI2cByte()
                {
                    Bit0 = Bit24_Enabled ? Bit24 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit1 = Bit25_Enabled ? Bit25 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit2 = Bit26_Enabled ? Bit26 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit3 = Bit27_Enabled ? Bit27 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit4 = Bit28_Enabled ? Bit28 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit5 = Bit29_Enabled ? Bit29 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit6 = Bit30_Enabled ? Bit30 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit7 = Bit31_Enabled ? Bit31 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                };
                UsbI2cByte byte4 = new UsbI2cByte()
                {
                    Bit0 = Bit32_Enabled ? Bit32 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit1 = Bit33_Enabled ? Bit33 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit2 = Bit34_Enabled ? Bit34 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit3 = Bit35_Enabled ? Bit35 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit4 = Bit36_Enabled ? Bit36 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit5 = Bit37_Enabled ? Bit37 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit6 = Bit38_Enabled ? Bit38 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                    Bit7 = Bit39_Enabled ? Bit39 ? UsbI2cBit.Set : UsbI2cBit.Reset : UsbI2cBit.Keep,
                };

                // Write to device
                handler?.SetOutput(
                    slaveAddress: SlaveAddress,
                    registerAddress: 128 + (uint)UsbI2cRegisters.OutputPort,
                    portA: byte0,
                    portB: byte1,
                    portC: byte2,
                    portD: byte3,
                    portE: byte4
                    );
            }
            catch (Exception exc)
            {
            }
            IsWorking = false;
        }

        public ICommand ReadOutputFromUsbCommand
        {
            get => new RelayCommand(cmd => ReadOutputFromUsbAction());
        }
        private void ReadOutputFromUsbAction()
        {
            try
            {
                IsWorking = true;
                byte[] output = handler?.GetOutput(
                    slaveAddress: SlaveAddress,
                    registerAddress: 128 + (uint)UsbI2cRegisters.OutputPort);
                // Skip first two bytes
                for (int i = 2; i < output.Length; i++)
                {
                    BitArray temp = new BitArray(new byte[] { output[i] });
                    switch (i)
                    {
                        // Byte0
                        case 2:
                            Bit0 = temp[0];
                            Bit1 = temp[1];
                            Bit2 = temp[2];
                            Bit3 = temp[3];
                            Bit4 = temp[4];
                            Bit5 = temp[5];
                            Bit6 = temp[6];
                            Bit7 = temp[7];
                            break;
                        // Byte1
                        case 3:
                            Bit8 = temp[0];
                            Bit9 = temp[1];
                            Bit10 = temp[2];
                            Bit11 = temp[3];
                            Bit12 = temp[4];
                            Bit13 = temp[5];
                            Bit14 = temp[6];
                            Bit15 = temp[7];
                            break;
                        // Byte2
                        case 4:
                            Bit16 = temp[0];
                            Bit17 = temp[1];
                            Bit18 = temp[2];
                            Bit19 = temp[3];
                            Bit20 = temp[4];
                            Bit21 = temp[5];
                            Bit22 = temp[6];
                            Bit23 = temp[7];
                            break;
                        // Byte3
                        case 5:
                            Bit24 = temp[0];
                            Bit25 = temp[1];
                            Bit26 = temp[2];
                            Bit27 = temp[3];
                            Bit28 = temp[4];
                            Bit29 = temp[5];
                            Bit30 = temp[6];
                            Bit31 = temp[7];
                            break;
                        // Byte4
                        case 6:
                            Bit32 = temp[0];
                            Bit33 = temp[1];
                            Bit34 = temp[2];
                            Bit35 = temp[3];
                            Bit36 = temp[4];
                            Bit37 = temp[5];
                            Bit38 = temp[6];
                            Bit39 = temp[7];
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception exc)
            {
            }
            IsWorking = false;
        }
        #endregion
    }
}
