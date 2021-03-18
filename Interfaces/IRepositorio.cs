using System.Collections.Generic;

namespace CadastroDeSeries.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T retornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int Id);
        void Atualiza(int Id, T entidade);
        int proximoId();
    }
}