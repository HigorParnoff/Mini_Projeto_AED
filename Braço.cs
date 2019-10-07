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
      if(Posicionar(0, false)){
        if(Garra(true, false)){
          if(Posicionar(coord)){
            if(Garra(false, false)){
              if(Posicionar(0, false)){
                Console.WriteLine ("Pacote posicionado");
                return true;
              } else { Console.WriteLine ("Erro ao posicionar para coordenada inicial"); }
            } else { Console.WriteLine ("Garra não fechou"); }
          } else { Console.WriteLine ("Posicionamento negado"); }
        } else { Console.WriteLine ("Garra não abriu"); }
      } else { Console.WriteLine ("Erro ao posicionar para coordenada inicial"); }    
      return false;
    }

    public bool Posicionar (int local, bool check = true) {
      if((local >= 0) && (local <= 1000)){
        posicao = local;
        string suporte = "";
        if(local != 0) { suporte =  String.Format("{0:0}", local); }
        if(check){ Console.WriteLine ("Braço {0} {1}", local == 0? "na posição inicial": "posicionado na coordenada:", suporte); }
        return true;
      } else { Console.WriteLine ("Coordenada regeitada"); }   
      return false;
    }

    public bool Garra (bool status, bool check = true) {
      if(!garra == status){ 
        garra = !garra;
        if(check){ Console.WriteLine ("Garra {0}", garra? "fechada": "aberta"); }
        return true;
      } else if(check) { Console.WriteLine ("A garra já esta {0}", garra? "fechada": "aberta"); }
      return false;
    }

    public bool LeitorCodigo(bool check = true) {
      Random randNum = new Random();
      if(check){ Console.WriteLine ("Código lido"); }
      codPacoteAtual = randNum.Next(1,4);
      return true;
    }

    public int getPosicao() { return posicao;}
    public bool getGarra() { return garra;}
    public int getCodPacoteAtual() { return codPacoteAtual;}

    private void setPosicao(int p) { posicao = p; }
    private void setGarra(bool g) { garra = g; }
    private void setCodPacoteAtual(int cod) { codPacoteAtual = cod; }
  }
}