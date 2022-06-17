using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IRepositorio<T>
    {
        IEnumerable Get();
        T GetByName(string nombre);
        void Insert(T obj);
        void Delete(string nombre);
        void Update(T obj);
        void Save();
        object GetMasBajasQueXCentimetros(double miAlturaMaxima);
        object GetDeXCentimetrosOMas(double miAlturaMinima);
        object GetPorAmbiente(string miAmbiente);
    }
}
