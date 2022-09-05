using ProductApi.Data;
using ProductApi.Data.ViewModel;
using ProductApi.Repository;
using ProductApi.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ProductApi.Services
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _context;
        public StateRepository(AppDbContext context)
        {
            _context = context;

        }
        public State AddState(StateVM stateVM)
        {
            var state = new State()
            {
                Title = stateVM.StateTitle,
            };
            _context.States.Add(state);
            _context.SaveChanges();
            return state;
        }
        public State UpdateState(int id, StateVM stateVM)
        {
            var state = _context.States.Where(x => x.Id == id).FirstOrDefault();
            state.Title = stateVM.StateTitle;
            _context.States.Update(state);
            _context.SaveChanges();
            return state;
        }
        public void DeleteState(int id)
        {
            var state = _context.States.Where(x => x.Id == id).FirstOrDefault();
            _context.States.Remove(state);
            _context.SaveChanges();
        }

        public State GetState(int id)
        {
            return _context.States.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<State> GetAllStates()
        {
            return _context.States;
        }
    }
}
