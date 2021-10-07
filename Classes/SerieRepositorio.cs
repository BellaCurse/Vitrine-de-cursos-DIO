using System;
using System.Collections.Generic;
using DIO.Vitrine.Interfaces;

namespace DIO.Vitrine
{
    public class VitrineRepositorio : IRepositorio<Vitrine>
    {
        private List<Vitrine> listaVitrine = new List<Vitrine>();
        public void Atualiza(int id, Vitrine objeto)
        {
            listaVitrine[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaVitrine[id].Excluir();
        }

        public void Insere(Vitrine objeto)
        {
            listaVitrine.Add(objeto);
        }

        public List<Vitrine> Lista()
        {
            return listaVitrine;
        }

        public int ProximoId()
        {
            return listaVitrine.Count;
        }

        public Vitrine RetornaPorId(int id)
        {
            return listaVitrine[id];
        }
    }
}