namespace L02.Facade
{
    public class Facade
    {
        protected SubsystemOne subsystemOne;
        protected SubsystemTwo subsystemTwo;

        public Facade(SubsystemOne subsystemOne, SubsystemTwo subsystemTwo)
        {
            this.subsystemOne = subsystemOne;
            this.subsystemTwo = subsystemTwo;
        }

        public string Operation()
        {
            return $"Facade initializes subsystems:\n{subsystemOne.OperationOne()}\n{subsystemTwo.OperationOne()}\nFacade orders subsystems to perform the action:\n{subsystemOne.OperationN()}\n{subsystemTwo.OperationZ()}";
        }
    }
}
