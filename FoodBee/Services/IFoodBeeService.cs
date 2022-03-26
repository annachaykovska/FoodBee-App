using System.Collections.Generic;

namespace FoodBee.Services
{
    public interface IFoodBeeService<T>
    {
        public List<T> GetAll();
        public List<string> GetActive();
        public void ClearActive();
        public void Toggle(string entity);
        public int GetNumActive();
    }
}
