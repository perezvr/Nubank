using System;

namespace ArmazemModel.DAL
{
    interface IDAL<T> where T : class
    {
        void Add(T objeto);
        void Add(T objeto, NubankContext contexto);
        void Update(T objeito);
        void Update(T objeito, NubankContext contexto);
        void Delete(Func<T, bool> expressao);
        void Delete(Func<T, bool> expressao, NubankContext contexto);
        T FindById(int id);
    }
}
