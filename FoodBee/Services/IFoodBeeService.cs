using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodBee.Services
{
    public interface IFoodBeeService<T>
    {
        public Task InitializeAsync();
        public List<T> GetAll();
        public List<string> GetActive();
        public void ClearActive();
        public bool IsActive(string entity);
        public void Toggle(string entity);
        public int GetNumActive();
    }
}
