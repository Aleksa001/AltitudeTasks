using AltitudeTasks.Class;
using AltitudeTasks.Infrastructure;
using AltitudeTasks.Interfaces;
using AltitudeTasks.Repository;

namespace AltitudeTasks.Services
{
    public class InputService : IInputService
    {
        private readonly IInputDataBase _inputDataBase;
        public InputService(IInputDataBase inputDataBase) 
        {
            _inputDataBase = inputDataBase;
        }

        public string AddInput(Input input)
        {
            if (_inputDataBase.IfInputExist(input)) 
            {
                return "This input already exist!";
            }
            

            try 
            {
                _inputDataBase.AddInput(input);
                return "Input successfully upload!";
            }
            catch(Exception e) 
            {
                return e.Message.ToString();
            }

        }

        public void DeleteInput(long id)
        {
            Input input = _inputDataBase.GetInput(id);  
            if (input != null) 
            {
                _inputDataBase.DeleteInput(input);
            }
        }

        public List<Input> GetAllInputs()
        {
            return _inputDataBase.GetAllInputs();
        }

        public Input GetInput(long id)
        {
            return _inputDataBase.GetInput(id);
        }
    }
}
