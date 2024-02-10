using AltitudeTasks.Class;
using AltitudeTasks.Infrastructure;
using AltitudeTasks.Interfaces;

namespace AltitudeTasks.Repository
{
    public class InputDataBase: IInputDataBase
    {
        private readonly InputDBContext _dbContext;
        public InputDataBase(InputDBContext inputDBContext)
        {
            _dbContext = inputDBContext;
        }

        public void AddInput(Input input)
        {
            _dbContext.Inputs.Add(input);
            _dbContext.SaveChanges();
        }

        public void DeleteInput(Input input)
        {
            _dbContext.Inputs.Remove(input);
            _dbContext.SaveChanges();
        }

        public List<Input> GetAllInputs()
        {
            return _dbContext.Inputs.ToList();
        }

        public Input GetInput(long id)
        {
            return _dbContext.Inputs.FirstOrDefault(i => i.Id == id);
        }

        public Input GetInput(Input input)
        {
            throw new NotImplementedException();
        }

        public bool IfInputExist(Input input)
        {
            return _dbContext.Inputs.Any(i =>
                    i.FirstName == input.FirstName &&
                    i.LastName == input.LastName &&
                    i.Telephone == input.Telephone);
        }
    }
}
