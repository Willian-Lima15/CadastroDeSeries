using System;
using System.Collections.Generic;
using CadastroDeSeries.Interfaces;
namespace CadastroDeSeries
{
    public class SeriesRepositorios : IRepositorio<Series>
    {
        private List<Series> ListaSeries = new List<Series>();
        public void Atualiza(int Id, Series objeto)
        {
            ListaSeries[Id] = objeto;
        }

        public void Exclui(int Id)
        {
            ListaSeries[Id].Exclui();
        }

        public void Insere(Series objeto)
        {
            ListaSeries.Add(objeto);
        }

        public List<Series> Lista()
        {
            return ListaSeries;
        }

        public int proximoId()
        {
            return ListaSeries.Count;
        }

        public Series retornaPorId(int id)
        {
            return ListaSeries[id];
        }
    }
}