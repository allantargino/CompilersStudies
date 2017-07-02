package compiladoreslab1;

import java.util.List;

public class AnalisadorSintatico {

    List<Token> _tokens;
    TreeNode<String> _root;

    public AnalisadorSintatico(List<Token> tokens) {
        _tokens = tokens;
        _root = new TreeNode<>("root");
    }

    public TreeNode<String>  Analisar() {
        return E();
    }

    public TreeNode<String>  E() {
        _root.addChild(T());
        _root.addChild(E_());
    }

    public TreeNode<String> T() {

    }

    public TreeNode<String> E_() {

    }
}
