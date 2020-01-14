using System;

namespace PrototypeDemo
{
    public class LogicPuzzle : ICloneable
    {
        private int blueSwitchCharge;
        private int redSwitchCharge;
        private bool smallToggle;
        private bool bigToggle;
        private bool doorOpen;
        private bool slatLocked;
        private int moveCount;

        public void SwitchBlueSwitch()
        {
            if (smallToggle)
                blueSwitchCharge++;
            bigToggle = !bigToggle;
            moveCount++;
        }

        public void SwitchRedSwitch()
        {
            if (!smallToggle && blueSwitchCharge < 3)
            {
                doorOpen = true;
                blueSwitchCharge = 0;
            }
            else
            {
                redSwitchCharge++;
                slatLocked = true;
            }

            moveCount++;
        }

        public void ToggleBigToggle()
        {
            slatLocked = false;
            redSwitchCharge = 0;
            if (doorOpen)
                doorOpen = false;
            moveCount++;
        }

        public void ToggleSmallToggle()
        {
            if(blueSwitchCharge < 3 || redSwitchCharge > 5)
            {
                slatLocked = false;
                doorOpen = true;
            }

            moveCount++;
        }


        public void PrintState()
        {
            Console.WriteLine("Blue switch charge: {0}", blueSwitchCharge);
            Console.WriteLine("Red switch charge: {0}", redSwitchCharge);
            Console.WriteLine("Small toggle: {0}", smallToggle);
            Console.WriteLine("Big toggle: {0}", bigToggle);
            Console.WriteLine("Door open: {0}", doorOpen);
            Console.WriteLine("Slat locked: {0}", slatLocked);
            Console.WriteLine("Move count: {0}", moveCount);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

