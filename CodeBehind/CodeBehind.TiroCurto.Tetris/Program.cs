//***CODE BEHIND - BY RODOLFO.FONSECA***//
//créditos -> https://github.com/NikolayIT/CSharpConsoleGames/tree/master

using CodeBehind.TiroCurto.Tetris;

Console.OutputEncoding = System.Text.Encoding.UTF8;

//new MusicPlayer().Tocar();

int TetrisRows = 20;
int TetrisCols = 10;

var engine = new TetrisGameManager(TetrisRows, TetrisCols);

engine.MainLoop();