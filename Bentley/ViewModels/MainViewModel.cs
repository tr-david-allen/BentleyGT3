using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace Bentley.ViewModels
{
    class MainViewModel : Screen
    {
        private bool functionToggle = true;
        private string rotarySwitchFunctionLabel;
        private string toggleLeftLabel;
        private string toggleRightLabel;
        private string titleLabel;
        private string buttonLogTextBox;
        private string buttonLogLabel;
        private SerialPort sp;
        private byte[] byteArray = new byte[1];


        public bool FunctionToggle
        {
            get => functionToggle;
            set
            {
                functionToggle = value;
                NotifyOfPropertyChange(nameof(FunctionToggle));
            }
        }

        public string RotarySwitchFunctionLabel
        {
            get => rotarySwitchFunctionLabel;
            set
            {
                rotarySwitchFunctionLabel = value;
                NotifyOfPropertyChange(nameof(RotarySwitchFunctionLabel));
            }
        }

        public string ToggleLeftLabel
        {
            get => toggleLeftLabel;
            set
            {
                toggleLeftLabel = value;
                NotifyOfPropertyChange(nameof(ToggleLeftLabel));
            }
        }

        public string ToggleRightLabel
        {
            get => toggleRightLabel;
            set
            {
                toggleRightLabel = value;
                NotifyOfPropertyChange(nameof(ToggleRightLabel));
            }
        }

        public string TitleLabel
        {
            get => titleLabel;
            set
            {
                titleLabel = value;
                NotifyOfPropertyChange(nameof(TitleLabel));
            }
        }

        public string ButtonLogTextBox
        {
            get => buttonLogTextBox;
            set
            {
                buttonLogTextBox = value;
                NotifyOfPropertyChange(nameof(ButtonLogTextBox));
            }
        }

        public string ButtonLogLabel
        {
            get => buttonLogLabel;
            set
            {
                buttonLogLabel = value;
                NotifyOfPropertyChange(nameof(ButtonLogLabel));
            }
        }

        public void Save()
        {
            if (FunctionToggle)
            {
                sp.Write("0");
            }
            else
            {
                sp.Write("1");
            }
        }

        public MainViewModel()
        {
            functionToggle = false;
            RotarySwitchFunctionLabel = "Rotary Switch Function";
            ToggleLeftLabel = "12 Positions";
            ToggleRightLabel = "Up and Down";
            TitleLabel = "Button Plate Configurator";
            ButtonLogLabel = "Button Log:";
            ButtonLogTextBox = "Button 1 Pressed";
            var portName = "COM4";
            sp = new SerialPort(portName);
            sp.DtrEnable = true;
            sp.BaudRate = 115200;
            sp.Parity = Parity.None;
            sp.StopBits = StopBits.One;
            sp.DataBits = 8;
            sp.Open();
            sp.DataReceived += Sp_DataReceived;
            ButtonLogTextBox = "Connected!";

            sp.Write("C");
        }

        private void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serialDevice = sender as SerialPort;
            var bytes = new byte[serialDevice.BytesToRead];
            var buffer = new byte[serialDevice.BytesToRead];
            ButtonLogTextBox = serialDevice.ReadLine();

            // process data on the GUI thread
            Application.Current.Dispatcher.Invoke(new System.Action(() => {
                //... do something here ...
            }));
        }
    }
}
