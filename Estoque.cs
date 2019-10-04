using System;
using System.IO;

// Classe Estoque
//Atributos:Conteiner(tamanho pequeno espaço), mapa container(mapa da sala), 

//metodos:Esteira,  localizar local(onde guardar), classificar(codigo);
//
// classe Braço Robótico.
// metodos: posicionar(coordenadas); garra(bool);  leitor de codigo;


namespace estoque {
  class Estoque{
    private string conteiner;
    private int[] mapa = new int[1000];

    public Estoque(){
      for(int i=0; i<x; i++){
        mapa[i] = 0;
      }
    }   

    public int LocalizarLocal(int oq){
      int x = 0;
      string tipo = Classificar(int);
      if(tipo == "fruta"){
        x=100;
      }
      for(int i=0; i<x; i++){
        if(mapa[i] == 0){
          return mapa[i]+1;
        }
      }
    }

    private string Classificar(int codigo){
      string tipo = "fruta";
      return tipo;
    }
  }
}