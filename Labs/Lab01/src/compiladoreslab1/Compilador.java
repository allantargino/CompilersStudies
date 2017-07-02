package compiladoreslab1;

import java.util.ArrayList;
import java.util.List;

public class Compilador {

    public static void main(String[] args) {
        String chain = "10.5 allan + 109 - .45 10.10 ** + * 15  10";

        //Analise Lexica
        AnalisadorLexico an = new AnalisadorLexico(chain);
        List<Token> tokens = new ArrayList<>();
        while (!an.isEOF()){
            Token t = an.nextToken();
            if (t != null){
                System.out.println("Reconhecido "+t.getCode() + "  "+t.getSymbol());
                tokens.add(t);
            }
            else{
                System.out.println("Token invalido");
            }
        }
        
        //Analise Sintatico
        AnalisadorSintatico as = new AnalisadorSintatico(tokens);
        
    }
}