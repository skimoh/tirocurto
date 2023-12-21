//***CODE BEHIND - BY RODOLFO.FONSECA***//
namespace CodeBehind.TiroCurto.Tetris
{
    public class MusicPlayer
    {
        public void Tocar()
        {
            new Thread(Reproduzir).Start();
        }

        private void Reproduzir()
        {
            while (true)
            {
                const int tempoSom = 100;

                Console.Beep(1320, tempoSom * 4);
                Console.Beep(990, tempoSom * 2);
                Console.Beep(1056, tempoSom * 2);
                Console.Beep(1188, tempoSom * 2);
                Console.Beep(1320, tempoSom);
                Console.Beep(1188, tempoSom);
                Console.Beep(1056, tempoSom * 2);
                Console.Beep(990, tempoSom * 2);
                Console.Beep(880, tempoSom * 4);
                Console.Beep(880, tempoSom * 2);
                Console.Beep(1056, tempoSom * 2);
                Console.Beep(1320, tempoSom * 4);
                Console.Beep(1188, tempoSom * 2);
                Console.Beep(1056, tempoSom * 2);
                Console.Beep(990, tempoSom * 6);
                Console.Beep(1056, tempoSom * 2);
                Console.Beep(1188, tempoSom * 4);
                Console.Beep(1320, tempoSom * 4);
                Console.Beep(1056, tempoSom * 4);
                Console.Beep(880, tempoSom * 4);
                Console.Beep(880, tempoSom * 4);
                Thread.Sleep(tempoSom * 2);
                Console.Beep(1188, tempoSom * 4);
                Console.Beep(1408, tempoSom * 2);
                Console.Beep(1760, tempoSom * 4);
                Console.Beep(1584, tempoSom * 2);
                Console.Beep(1408, tempoSom * 2);
                Console.Beep(1320, tempoSom * 6);
                Console.Beep(1056, tempoSom * 2);
                Console.Beep(1320, tempoSom * 4);
                Console.Beep(1188, tempoSom * 2);
                Console.Beep(1056, tempoSom * 2);
                Console.Beep(990, tempoSom * 4);
                Console.Beep(990, tempoSom * 2);
                Console.Beep(1056, tempoSom * 2);
                Console.Beep(1188, tempoSom * 4);
                Console.Beep(1320, tempoSom * 4);
                Console.Beep(1056, tempoSom * 4);
                Console.Beep(880, tempoSom * 4);
                Console.Beep(880, tempoSom * 4);
                Thread.Sleep(tempoSom * 4);
                Console.Beep(1320, tempoSom * 4);
                Console.Beep(990, tempoSom * 2);
                Console.Beep(1056, tempoSom * 2);
                Console.Beep(1188, tempoSom * 2);
                Console.Beep(1320, tempoSom);
                Console.Beep(1188, tempoSom);
                Console.Beep(1056, tempoSom * 2);
                Console.Beep(990, tempoSom * 2);
                Console.Beep(880, tempoSom * 4);
                Console.Beep(880, tempoSom * 2);
                Console.Beep(1056, tempoSom * 2);
                Console.Beep(1320, tempoSom * 4);
                Console.Beep(1188, tempoSom * 2);
                Console.Beep(1056, tempoSom * 2);
                Console.Beep(990, tempoSom * 6);
                Console.Beep(1056, tempoSom * 2);
                Console.Beep(1188, tempoSom * 4);
                Console.Beep(1320, tempoSom * 4);
                Console.Beep(1056, tempoSom * 4);
                Console.Beep(880, tempoSom * 4);
                Console.Beep(880, tempoSom * 4);
                Thread.Sleep(tempoSom * 2);
                Console.Beep(1188, tempoSom * 4);
                Console.Beep(1408, tempoSom * 2);
                Console.Beep(1760, tempoSom * 4);
                Console.Beep(1584, tempoSom * 2);
                Console.Beep(1408, tempoSom * 2);
                Console.Beep(1320, tempoSom * 6);
                Console.Beep(1056, tempoSom * 2);
                Console.Beep(1320, tempoSom * 4);
                Console.Beep(1188, tempoSom * 2);
                Console.Beep(1056, tempoSom * 2);
                Console.Beep(990, tempoSom * 4);
                Console.Beep(990, tempoSom * 2);
                Console.Beep(1056, tempoSom * 2);
                Console.Beep(1188, tempoSom * 4);
                Console.Beep(1320, tempoSom * 4);
                Console.Beep(1056, tempoSom * 4);
                Console.Beep(880, tempoSom * 4);
                Console.Beep(880, tempoSom * 4);
                Thread.Sleep(tempoSom * 4);
                Console.Beep(660, tempoSom * 8);
                Console.Beep(528, tempoSom * 8);
                Console.Beep(594, tempoSom * 8);
                Console.Beep(495, tempoSom * 8);
                Console.Beep(528, tempoSom * 8);
                Console.Beep(440, tempoSom * 8);
                Console.Beep(419, tempoSom * 8);
                Console.Beep(495, tempoSom * 8);
                Console.Beep(660, tempoSom * 8);
                Console.Beep(528, tempoSom * 8);
                Console.Beep(594, tempoSom * 8);
                Console.Beep(495, tempoSom * 8);
                Console.Beep(528, tempoSom * 4);
                Console.Beep(660, tempoSom * 4);
                Console.Beep(880, tempoSom * 8);
                Console.Beep(838, tempoSom * 16);
                Console.Beep(660, tempoSom * 8);
                Console.Beep(528, tempoSom * 8);
                Console.Beep(594, tempoSom * 8);
                Console.Beep(495, tempoSom * 8);
                Console.Beep(528, tempoSom * 8);
                Console.Beep(440, tempoSom * 8);
                Console.Beep(419, tempoSom * 8);
                Console.Beep(495, tempoSom * 8);
                Console.Beep(660, tempoSom * 8);
                Console.Beep(528, tempoSom * 8);
                Console.Beep(594, tempoSom * 8);
                Console.Beep(495, tempoSom * 8);
                Console.Beep(528, tempoSom * 4);
                Console.Beep(660, tempoSom * 4);
                Console.Beep(880, tempoSom * 8);
                Console.Beep(838, tempoSom * 16);
            }
        }
    }
}
