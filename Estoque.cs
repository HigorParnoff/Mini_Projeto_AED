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
    private int codPacote;
    private int[] mapa = new int[1000];
    public BracoRobotico braco = new BracoRobotico();
    List<string> lista_ob;
    List<int> pacotes;

    public Estoque(){
      for(int i=0; i<1000; i++){
        mapa[i] = 0;
      }     
      lista_ob = new List<string>{"frutas", "brinquedos", "cartas", "eletronicos"};
      pacotes = new List<int>{};
    }   

    public int DefinirLocal(){ 
      codPacote = braco.getCodPacoteAtual();
      int x = 0, y = 0;
      string tipo = Classificar(codPacote);
      /*if(tipo == "frutas"){
        x = 100;
        y = 0;
      }else{
        if(tipo == "brinquedos"){
          x = 200;
          y = 100;
        }else
      }*/

      for(int i = 0; i < lista_ob.Count; i++){
        if(lista_ob[i] == tipo){
          x = (i + 1) * 100;
          y = i * 100;
          break;
        }        
      }
      /*switch(tipo){
        case "frutas": x = 100; y = 0; break;
        case "brinquedos": x = 200; y = 100; break;
        case "cartas": x = 300; y = 200; break;
        case "eletronicos": x = 400; y = 300; break;
      }*/

      for(int i=y; i<x; i++){
        if(mapa[i] == 0){
          mapa[i] = (codPacote*100) + i;
          pacotes.Add((codPacote*100) + i);
          return i;
        }
      }
      Console.WriteLine ("Não há coordenadas disponiveis");
      return -1;
    }

    public void Guardar(){
      if(!braco.GuardarPacote( DefinirLocal() )) 
        { Console.WriteLine ("Estoque não guardou"); }      
    }

    public void LerCodigo(){
      if(!braco.LeitorCodigo()) 
        { Console.WriteLine ("Estoque não pode ler o código do pacote"); }      
    }

    public void Inventario(){
      Console.WriteLine ("\nInventario:");
      foreach(int i in pacotes){
        int aux = i;
        int tipo = aux % 100;
        Console.WriteLine ("cod: {0} - tipo: {1} - prateleira: {2}", aux, lista_ob[tipo], aux % 100);
      }
    }    

    private string Classificar(int codigo){
      string tipo;
      tipo = IdentificarObj(codigo);
      Console.WriteLine ("Pacote do tipo: {0}", tipo);
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