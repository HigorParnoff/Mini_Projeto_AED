using System;
using System.IO;

namespace estoque {
  class BracoRobotico {
    private int posicao = 0;
    private bool garra = false;
    private int codPacoteAtual = 0;

    public BracoRobotico(){}
    public BracoRobotico(int p = 0, bool g = false, int cod = 0){
      posicao = p;
      garra = g;
      codPacoteAtual = cod;
    }

    public bool GuardarPacote(int coord){
      if(Posicionar(0)){
        if(Garra(true)){
          if(Posicionar(coord)){
            if(Posicionar(coord)){
              if(Garra(false)){
                if(Posicionar(0)){
                  return true;
                }
              }
            }
          }
        }
      }    
      return false;
    }

    public bool Posicionar (int local) {
      if((local >= 0) && (local <= 1000)){
        posicao = local;
        Console.WriteLine ("Braço posicionado");
        return true;
      }
      return false;
    }

    public bool Garra (bool status) {
      if(!garra == status){ 
        garra = !garra;
        Console.WriteLine ("Garra {0}", garra? "fechada": "aberta");
        return true;
      } else { Console.WriteLine ("A garra já esta {0}", garra? "fechada": "aberta"); }
      return false;
    }

    public int LeitorCodigo () {
      Random randNum = new Random();
      Console.WriteLine ("Código lido");
      codPacoteAtual = randNum.Next(1,10);
      return codPacoteAtual;
    }

    public int getPosicao() { return posicao;}
    public bool getGarra() { return garra;}
    public int getCodPacoteAtual() { return codPacoteAtual;}

    private void setPosicao(int p) { posicao = p; }
    private void setGarra(bool g) { garra = g; }
    private void setCodPacoteAtual(int cod) { codPacoteAtual = cod; }
  }
}