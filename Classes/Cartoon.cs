using System;
using System.Reflection.Metadata;

namespace cartoonhood{
    public class Cartoon : EntidadeBase{
        //atributes

        private string titulo { get; set; }
        private Genero genero { get; set; }
        private string descricao { get; set; }
        private int ano { get; set; }
        private bool excluido { get; set; }

        public Cartoon(int id, string titulo, Genero genero, string descricao, int ano){
            this.id = id;
            this.titulo = titulo;
            this.genero = genero;
            this.descricao = descricao;
            this.ano = ano;
            this.excluido = false;
        }

        public override string ToString(){
            string retorno = "";
            retorno += "Título: " + this.titulo + Environment.NewLine;
            retorno += "Gênero: " + this.genero + Environment.NewLine;
            retorno += "Descrição: " + this.descricao + Environment.NewLine;
            retorno += "Ano: " + this.ano + Environment.NewLine;
            retorno += "Excluído: " + this.excluido + Environment.NewLine;

            return retorno;
        }

        public string retornaTitulo(){
            return this.titulo;
        }

        public int retornaId(){
            return this.id;
        }

        public void excluir(){
            excluido = true;
        }
        public bool retornaExcluido(){
            return this.excluido;
        }
        
    }
}