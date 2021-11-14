using System;

/// <summary>
/// INSTRUCTIUNI BUTOANE
/// 1 - ACTIVEAZA AFISAREA DE CULORI RANDOM A CUBULUI
/// 2 - ACTIVEAZA AFISAREA CULORILOR HARDCODED A CUBULUI
/// 3 - SCHIMBA CULORILE RANDOM PENTRU AFISAREA 1
/// L - VISION TOGGLE PENTRU CUB
/// MOUSE_LEFT_CLICK - SCHIMBA CULOARE FUNDAL PORTOCALIU
/// MOUSE_RIGHT_CLICK - SCHIMBA CULOARE FUNDAL ALBASTRU
/// LEFT_ARROW - ROTIRE CUB SPRE STANGA
/// RIGHT_ARROW - ROTIRE CUB SPRE DREAPTA
/// m - activate object movement -> move with arrows
/// c - activate camera movement -> move with arrows
/// r - activate obj rotation -> rotate with arrows
/// </summary>

namespace First_OpenTK
{
    class Program
    { 
        [STAThread]
        static void Main(string[] args)
        {
            using (Window3D EGC = new Window3D())
            {
                EGC.Run(30.0, 0.0);
            }
        }


        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("INSTRUCTIUNI BUTOANE "
                                + "\n1 - activeaza afisarea de culori random a cubului "
                                + "\n2 - activeaza afisarea culorilor hardcoded a cubului"
                                + "\n3 - schimba culorile random pentru afisarea 1"
                                + "\nL - vision toggle pentru cub"
                                + "\nmouse_left_click - Creaza obiect cazator."
                                + "\nmouse_right_click - schimba culoare fundal albastru"
                                + "\nc - activate camera movement->move with arrows"
                                + "\nz - activate camera zoom -> change with Q or A"
                                );
        }
    }
}
