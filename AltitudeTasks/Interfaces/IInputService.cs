using AltitudeTasks.Class;

namespace AltitudeTasks.Interfaces
{
    public interface IInputService
    {
        string AddInput(Input input);
        List<Input> GetAllInputs();
        Input GetInput(long id);
        void DeleteInput(long id);
    }
}
