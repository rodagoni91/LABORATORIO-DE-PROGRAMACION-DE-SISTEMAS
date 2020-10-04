import java.io.*;
import org.antlr.runtime.*;
import org.antlr.runtime.debug.DebugEventSocketProxy;


public class __Test__ {

    public static void main(String args[]) throws Exception {
        SIC_gramaticaLexer lex = new SIC_gramaticaLexer(new ANTLRFileStream("C:\\Users\\dany_\\Desktop\\output\\__Test___input.txt", "UTF8"));
        CommonTokenStream tokens = new CommonTokenStream(lex);

        SIC_gramaticaParser g = new SIC_gramaticaParser(tokens, 49100, null);
        try {
            g.programa();
        } catch (RecognitionException e) {
            e.printStackTrace();
        }
    }
}