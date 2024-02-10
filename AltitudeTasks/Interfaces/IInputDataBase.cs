using AltitudeTasks.Class;

namespace AltitudeTasks.Interfaces
{
    public interface IInputDataBase
    {
        void AddInput(Input input);
        bool IfInputExist(Input input);
        List<Input> GetAllInputs();
        Input GetInput(long id);
        void DeleteInput(Input input);
    }
}
