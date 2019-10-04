using System;
using System.IO;
using System.Collections.Generic;
// Classe Estoque
//Atributos:Conteiner(tamanho pequeno espaço), mapa container(mapa da sala), 

//metodos:Esteira,  localizar local(onde guardar), classificar(codigo);
//
// classe Braço Robótico.
// metodos: posicionar(coordenadas); garra(bool);  leitor de codigo;


namespace estoque { //foreach(<tipo> a in <lista>) // se precisar
  class Estoque{
    private string conteiner;
    private int[] mapa = new int[1000];
    public BracoRobotico braco = new BracoRobotico();
    List<string> lista_ob;
    public Estoque(){
      for(int i=0; i<1000; i++){
        mapa[i] = 0;
      }      
      lista_ob = new List<string>{"frutas", "brinquedos", "cartas", "eletronicos"};
    }   

    public int DefinirLocal(){ 
      int oq = braco.getCodPacoteAtual();
      int x = 0, y = 0;
      string tipo = Classificar(oq);
      /*if(tipo == "frutas"){
        x = 100;
        y = 0;
      }else{
        if(tipo == "brinquedos"){
          x = 200;
          y = 100;
        }else
      }*/

      switch(tipo){
        case "frutas": x = 100; y = 0; break;
        case "brinquedos": x = 200; y = 100; break;
        case "cartas": x = 300; y = 200; break;
        case "eletronicos": x = 400; y = 300; break;
      }

      for(int i=y; i<x; i++){
        if(mapa[i] == 0){
          return i+1;
        }
      }
      return -1;
    }

    private string Classificar(int codigo){
      string tipo;
      tipo = IdentificarObj(codigo);
      return tipo;
    }

    private string IdentificarObj(int ob){
       string res = lista_ob[ob];
       return res;
    }
    
    public void AlterarCodificacao(){
      lista_ob.Clear();
      string aux = "";
      while(aux != "n"){
        Console.WriteLine ("Informe os pacotes ou 'n' para sair: ");
        aux = Console.ReadLine ();
        if(aux != "n"){
          lista_ob.Add(aux);
        }        
      }
    }
  }
}