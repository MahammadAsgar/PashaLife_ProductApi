using ProductApi.Data;
using ProductApi.Data.ViewModel;
using System.Collections.Generic;

namespace ProductApi.Services.Abstract
{
    public interface IStateRepository
    {
        State AddState(StateVM stateVM);
        State UpdateState(int id, StateVM stateVM);
        void DeleteState(int id);
        State GetState(int id);
        IEnumerable<State> GetAllStates();
    }
}
