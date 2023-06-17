using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Calcparse;

string? codigoFuente = null;
if (args.Length > 0) codigoFuente = args[0];

TextReader lector = Console.In;
if (codigoFuente != null)
{
    lector = File.OpenText(codigoFuente);
}

string? expresion = lector.ReadLine();
int linea = 1;

ExprParser miparser = new ExprParser(null);
miparser.BuildParseTree = true;
ParseTreeWalker walker = new ParseTreeWalker();

while (expresion != null)
{
    AntlrInputStream entrada = new AntlrInputStream(expresion + "\n");
    ExprLexer milexer = new ExprLexer(entrada);
    milexer.Line = linea;
    milexer.Column = 0;
    CommonTokenStream tokens = new CommonTokenStream(milexer);
    miparser.TokenStream = tokens;
    IParseTree arbol = miparser.prog();
    Cargador escucha = new Cargador();
    walker.Walk(escucha, arbol);
    Console.WriteLine("Resultado: " + escucha.pila.Pop());
  
    expresion = lector.ReadLine();
    linea++;


}
if (codigoFuente != null)
{
    lector.Close();
}