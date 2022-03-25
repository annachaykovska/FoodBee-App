using System.Collections.Generic;

namespace FoodBee.Services
{
    public interface IFoodBeeService<T>
    {
        public List<T> GetAll();
        public List<T> GetActive();
        public void ClearActive();
        public void Toggle(T entity);
        public int GetNumActive();
    }
}
