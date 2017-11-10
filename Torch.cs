using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Session_1
{
    public class Torch
    {

        public Dictionary<int,Color> ColorList = new Dictionary<int, Color>();
        
        private int _battery = 100;
        
        public int battery
        {
            set
            {
                _battery = value;
                if (_battery < 1)
                {
                    _battery = 0;
                }
            }
            get
            {
                return _battery;
            }
        }

        private bool _turnedOn = false;

        public bool turnedOn
        {
            get
            {
                return _turnedOn;
            }
            set
            {
                if (battery > 0)
                {
                    _turnedOn = value;
                }
                else
                {
                    _turnedOn = false;
                }
            }
        }

        public void Toggle()
        {
            turnedOn = !turnedOn;
        }

        public Color bgColor = Color.Blue;
        
        public void ChangeState(bool onOrOff)
        {
            turnedOn = onOrOff;
            battery = battery - 10;
            if (turnedOn)
            {
                bgColor = BatteryColor();
            }
            else
            {
                bgColor = Color.Empty;
            }
        }

        public Color BatteryColor()
        {
            if (ColorList.ContainsKey(battery))
            {
                return ColorList[battery];
            }
            else
            {
                return bgColor;
            }
        }
    }
}
