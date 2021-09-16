using System.Collections.Generic;

namespace cartoonhood{
    public class CartoonRepositorio : IRepositorio<Cartoon>{

        private List<Cartoon> listaCartoon = new List<Cartoon>();

        public List<Cartoon> lista(){
            return listaCartoon;
        }

        public Cartoon retornaPorId(int id){
            return listaCartoon[id];
        }

        public void insere(Cartoon entidade){
            listaCartoon.Add(entidade);
        }

        public void exclui(int id){
            listaCartoon[id].excluir();
        }
        
        public void atualiza(int id, Cartoon entidade){
            listaCartoon[id] = entidade;
        }

        public int proximoId(){
            return listaCartoon.Count;
        }
    }
}