namespace Weird
{
    class Lift
    {
        private int currentFloor;
        public int CurrentFloor { 
            get { 
                return currentFloor; 
            } 
        }

        public void Call(int targetFloor)
        {
            currentFloor = targetFloor;
        }

    }
}