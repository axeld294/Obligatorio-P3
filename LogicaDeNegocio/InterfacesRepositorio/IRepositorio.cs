using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.InterfacesRepositorio
{
    public interface IRepositorio<T>
    {
        void Add(T item);
        void Delete(int id);
        void Update(T item, int id);
        T FindbyId(int id);
        IEnumerable<T> FindAll();
    }
}
