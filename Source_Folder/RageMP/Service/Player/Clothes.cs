using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;

public class femaleClothes : Script
{
    static List<dynamic> acessories = new List<dynamic>();
    static List<dynamic> clothes_list = new List<dynamic>();
    static List<dynamic> traje_list = new List<dynamic>();

    public static void ClothesInit()
    {
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 4, variation = 0 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 4, variation = 1 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 6, variation = 0 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 6, variation = 1 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 6, variation = 2 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 6, variation = 3 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 6, variation = 4 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 6, variation = 5 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 6, variation = 6 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 6, variation = 7 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 0 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 1 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 2 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 3 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 4 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 5 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 6 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 7 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 8 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 9 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 10 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 11 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 12 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 13 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 14 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 15 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 16 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 17 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 18 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 19 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 20 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 21 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 22 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 23 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 24 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 55, variation = 25 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 96, variation = 0 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 96, variation = 1 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 96, variation = 2 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 96, variation = 3 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 96, variation = 4 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 96, variation = 5 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 96, variation = 6 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 96, variation = 7 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 96, variation = 8 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 96, variation = 9 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 96, variation = 10 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 96, variation = 11 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 96, variation = 12 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 96, variation = 13 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 96, variation = 14 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 96, variation = 15 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 54, variation = 0 });
        acessories.Add(new { sex = 0, category = "Boné", component = 0, draw = 54, variation = 1 });


        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 94, variation = 0 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 94, variation = 1 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 94, variation = 2 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 94, variation = 3 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 94, variation = 4 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 94, variation = 5 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 94, variation = 6 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 94, variation = 7 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 94, variation = 8 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 94, variation = 9 });


        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 95, variation = 0 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 95, variation = 1 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 95, variation = 2 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 95, variation = 3 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 95, variation = 4 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 95, variation = 5 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 95, variation = 6 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 95, variation = 7 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 95, variation = 8 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 95, variation = 9 });


        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 20, variation = 0 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 20, variation = 1 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 20, variation = 2 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 20, variation = 3 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 20, variation = 4 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 20, variation = 5 });

        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 21, variation = 0 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 21, variation = 1 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 21, variation = 2 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 21, variation = 3 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 21, variation = 4 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 21, variation = 5 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 21, variation = 6 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 21, variation = 7 });

        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 12, variation = 0 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 12, variation = 1 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 12, variation = 2 });

        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 12, variation = 0 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 12, variation = 1 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 12, variation = 2 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 12, variation = 3 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 12, variation = 4 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 12, variation = 5 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 12, variation = 6 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 12, variation = 7 });

        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 13, variation = 0 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 13, variation = 1 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 13, variation = 2 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 13, variation = 3 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 13, variation = 4 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 13, variation = 5 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 13, variation = 6 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 13, variation = 7 });

        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 25, variation = 0 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 25, variation = 1 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 25, variation = 2 });

        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 26, variation = 0 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 26, variation = 1 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 26, variation = 2 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 26, variation = 3 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 26, variation = 4 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 26, variation = 5 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 26, variation = 6 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 26, variation = 7 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 26, variation = 8 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 26, variation = 9 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 26, variation = 10 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 26, variation = 11 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 26, variation = 12 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 26, variation = 13 });

        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 27, variation = 0 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 27, variation = 1 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 27, variation = 2 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 27, variation = 3 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 27, variation = 4 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 27, variation = 5 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 27, variation = 6 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 27, variation = 7 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 27, variation = 8 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 27, variation = 9 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 27, variation = 10 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 27, variation = 11 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 27, variation = 12 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 27, variation = 13 });

        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 30, variation = 0 });
        acessories.Add(new { sex = 0, category = "Chapéu", component = 0, draw = 30, variation = 1 });


        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 2, variation = 0 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 2, variation = 1 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 2, variation = 2 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 2, variation = 3 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 2, variation = 4 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 2, variation = 5 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 2, variation = 6 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 2, variation = 7 });

        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 5, variation = 0 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 5, variation = 1 });

        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 28, variation = 0 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 28, variation = 1 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 28, variation = 2 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 28, variation = 3 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 28, variation = 4 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 28, variation = 5 });

        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 29, variation = 0 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 29, variation = 1 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 29, variation = 2 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 29, variation = 3 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 29, variation = 4 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 29, variation = 5 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 29, variation = 6 });
        acessories.Add(new { sex = 0, category = "Toca", component = 0, draw = 29, variation = 7 });

        acessories.Add(new { sex = 0, category = "Boina", component = 0, draw = 7, variation = 0 });
        acessories.Add(new { sex = 0, category = "Boina", component = 0, draw = 7, variation = 1 });
        acessories.Add(new { sex = 0, category = "Boina", component = 0, draw = 7, variation = 2 });
        acessories.Add(new { sex = 0, category = "Boina", component = 0, draw = 7, variation = 3 });
        acessories.Add(new { sex = 0, category = "Boina", component = 0, draw = 7, variation = 4 });
        acessories.Add(new { sex = 0, category = "Boina", component = 0, draw = 7, variation = 5 });
        acessories.Add(new { sex = 0, category = "Boina", component = 0, draw = 7, variation = 6 });
        acessories.Add(new { sex = 0, category = "Boina", component = 0, draw = 7, variation = 7 });

        acessories.Add(new { sex = 0, category = "Bandana", component = 0, draw = 14, variation = 0 });
        acessories.Add(new { sex = 0, category = "Bandana", component = 0, draw = 14, variation = 1 });
        acessories.Add(new { sex = 0, category = "Bandana", component = 0, draw = 14, variation = 2 });
        acessories.Add(new { sex = 0, category = "Bandana", component = 0, draw = 14, variation = 3 });
        acessories.Add(new { sex = 0, category = "Bandana", component = 0, draw = 14, variation = 4 });
        acessories.Add(new { sex = 0, category = "Bandana", component = 0, draw = 14, variation = 5 });
        acessories.Add(new { sex = 0, category = "Bandana", component = 0, draw = 14, variation = 6 });
        acessories.Add(new { sex = 0, category = "Bandana", component = 0, draw = 14, variation = 7 });

        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 22, variation = 0 });
        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 22, variation = 1 });

        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 23, variation = 0 });

        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 24, variation = 0 });

        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 40, variation = 0 });
        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 40, variation = 1 });
        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 40, variation = 2 });
        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 40, variation = 3 });
        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 40, variation = 4 });
        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 40, variation = 5 });
        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 40, variation = 6 });
        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 40, variation = 7 });

        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 41, variation = 0 });

        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 42, variation = 0 });
        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 42, variation = 1 });
        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 42, variation = 2 });
        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 42, variation = 3 });

        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 43, variation = 0 });
        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 43, variation = 1 });
        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 43, variation = 2 });
        acessories.Add(new { sex = 0, category = "Natal", component = 0, draw = 43, variation = 3 });

        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 2, variation = 0 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 2, variation = 1 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 2, variation = 2 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 2, variation = 3 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 2, variation = 4 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 2, variation = 5 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 2, variation = 6 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 2, variation = 7 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 2, variation = 8 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 2, variation = 9 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 2, variation = 10 });


        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 3, variation = 0 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 3, variation = 1 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 3, variation = 2 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 3, variation = 3 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 3, variation = 4 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 3, variation = 5 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 3, variation = 6 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 3, variation = 7 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 3, variation = 8 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 3, variation = 9 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 3, variation = 10 });


        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 4, variation = 0 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 4, variation = 1 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 4, variation = 2 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 4, variation = 3 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 4, variation = 4 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 4, variation = 5 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 4, variation = 6 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 4, variation = 7 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 4, variation = 8 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 4, variation = 9 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 4, variation = 10 });

        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 5, variation = 0 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 5, variation = 1 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 5, variation = 2 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 5, variation = 3 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 5, variation = 4 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 5, variation = 5 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 5, variation = 6 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 5, variation = 7 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 5, variation = 8 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 5, variation = 9 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 5, variation = 10 });


        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 7, variation = 0 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 7, variation = 1 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 7, variation = 2 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 7, variation = 3 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 7, variation = 4 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 7, variation = 5 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 7, variation = 6 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 7, variation = 7 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 7, variation = 8 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 7, variation = 9 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 7, variation = 10 });


        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 8, variation = 0 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 8, variation = 1 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 8, variation = 2 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 8, variation = 3 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 8, variation = 4 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 8, variation = 5 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 8, variation = 6 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 8, variation = 7 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 8, variation = 8 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 8, variation = 9 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 8, variation = 10 });


        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 9, variation = 0 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 9, variation = 1 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 9, variation = 2 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 9, variation = 3 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 9, variation = 4 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 9, variation = 5 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 9, variation = 6 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 9, variation = 7 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 9, variation = 8 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 9, variation = 9 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 9, variation = 10 });

        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 10, variation = 0 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 10, variation = 1 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 10, variation = 2 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 10, variation = 3 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 10, variation = 4 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 10, variation = 5 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 10, variation = 6 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 10, variation = 7 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 10, variation = 8 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 10, variation = 9 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 10, variation = 10 });

        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 12, variation = 0 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 12, variation = 1 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 12, variation = 2 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 12, variation = 3 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 12, variation = 4 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 12, variation = 5 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 12, variation = 6 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 12, variation = 7 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 12, variation = 8 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 12, variation = 9 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 12, variation = 10 });

        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 13, variation = 0 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 13, variation = 1 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 13, variation = 2 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 13, variation = 3 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 13, variation = 4 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 13, variation = 5 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 13, variation = 6 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 13, variation = 7 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 13, variation = 8 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 13, variation = 9 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 13, variation = 10 });

        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 15, variation = 0 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 15, variation = 1 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 15, variation = 2 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 15, variation = 3 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 15, variation = 4 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 15, variation = 5 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 15, variation = 6 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 15, variation = 7 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 15, variation = 8 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 15, variation = 9 });


        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 16, variation = 0 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 16, variation = 1 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 16, variation = 2 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 16, variation = 3 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 16, variation = 4 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 16, variation = 5 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 16, variation = 6 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 16, variation = 7 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 16, variation = 8 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 16, variation = 9 });


        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 17, variation = 0 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 17, variation = 1 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 17, variation = 2 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 17, variation = 3 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 17, variation = 4 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 17, variation = 5 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 17, variation = 6 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 17, variation = 7 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 17, variation = 8 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 17, variation = 9 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 17, variation = 10 });


        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 18, variation = 0 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 18, variation = 1 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 18, variation = 2 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 18, variation = 3 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 18, variation = 4 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 18, variation = 5 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 18, variation = 6 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 18, variation = 7 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 18, variation = 8 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 18, variation = 9 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 18, variation = 10 });

        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 19, variation = 0 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 19, variation = 1 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 19, variation = 2 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 19, variation = 3 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 19, variation = 4 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 19, variation = 5 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 19, variation = 6 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 19, variation = 7 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 19, variation = 8 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 19, variation = 9 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 19, variation = 10 });

        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 20, variation = 0 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 20, variation = 1 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 20, variation = 2 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 20, variation = 3 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 20, variation = 4 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 20, variation = 5 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 20, variation = 6 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 20, variation = 7 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 20, variation = 8 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 20, variation = 9 });
        acessories.Add(new { sex = 0, category = "Oculus", component = 1, draw = 20, variation = 10 });


        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 4, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 4, variation = 1 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 4, variation = 2 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 4, variation = 3 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 4, variation = 4 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 4, variation = 5 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 4, variation = 6 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 4, variation = 7 });

        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 9, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 9, variation = 1 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 9, variation = 2 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 9, variation = 3 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 9, variation = 4 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 9, variation = 5 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 9, variation = 6 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 9, variation = 7 });

        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 43, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 43, variation = 1 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 43, variation = 2 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 43, variation = 3 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 43, variation = 4 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 43, variation = 5 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 43, variation = 6 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 43, variation = 7 });

        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 44, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 44, variation = 1 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 44, variation = 2 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 44, variation = 3 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 44, variation = 4 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 44, variation = 5 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 44, variation = 6 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 44, variation = 7 });

        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 53, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 53, variation = 1 });

        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 1 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 2 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 3 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 4 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 5 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 6 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 7 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 8 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 9 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 10 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 11 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 12 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 13 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 14 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 15 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 16 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 17 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 18 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 19 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 20 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 21 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 22 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 23 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 24 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 55, variation = 25 });

        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 56, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 56, variation = 1 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 56, variation = 2 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 56, variation = 3 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 56, variation = 4 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 56, variation = 5 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 56, variation = 6 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 56, variation = 7 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 56, variation = 8 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 56, variation = 9 });

        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 58, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 58, variation = 1 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 58, variation = 2 });

        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 63, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 63, variation = 1 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 63, variation = 2 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 63, variation = 3 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 63, variation = 4 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 63, variation = 5 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 63, variation = 6 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 63, variation = 7 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 63, variation = 8 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 63, variation = 9 });

        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 1 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 2 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 3 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 4 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 5 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 6 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 7 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 8 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 9 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 10 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 11 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 12 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 13 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 14 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 15 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 16 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 17 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 18 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 19 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 75, variation = 20 });

        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 1 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 2 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 3 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 4 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 5 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 6 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 7 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 8 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 9 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 10 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 11 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 12 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 13 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 14 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 15 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 16 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 17 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 18 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 19 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 76, variation = 20 });

        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 108, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 108, variation = 1 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 108, variation = 2 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 108, variation = 3 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 108, variation = 4 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 108, variation = 5 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 108, variation = 6 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 108, variation = 7 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 108, variation = 8 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 108, variation = 9 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 108, variation = 10 });

        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 109, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 109, variation = 1 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 109, variation = 2 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 109, variation = 3 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 109, variation = 4 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 109, variation = 5 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 109, variation = 6 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 109, variation = 7 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 109, variation = 8 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 109, variation = 9 });
        acessories.Add(new { sex = 1, category = "Boné", component = 0, draw = 109, variation = 10 });

        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 5, variation = 0 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 5, variation = 1 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 5, variation = 2 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 5, variation = 3 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 5, variation = 4 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 5, variation = 5 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 5, variation = 6 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 5, variation = 7 });

        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 29, variation = 0 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 29, variation = 1 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 29, variation = 2 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 29, variation = 3 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 29, variation = 4 });

        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 0 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 1 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 2 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 3 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 4 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 5 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 6 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 7 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 8 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 9 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 10 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 11 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 12 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 13 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 14 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 15 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 16 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 17 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 18 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 19 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 20 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 21 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 22 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 23 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 24 });
        acessories.Add(new { sex = 1, category = "Toca", component = 0, draw = 119, variation = 25 });

        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 6, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 6, variation = 1 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 6, variation = 2 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 6, variation = 3 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 6, variation = 4 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 6, variation = 5 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 6, variation = 6 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 6, variation = 7 });

        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 7, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 7, variation = 1 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 7, variation = 2 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 7, variation = 3 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 7, variation = 4 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 7, variation = 5 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 7, variation = 6 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 7, variation = 7 });

        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 14, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 14, variation = 1 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 14, variation = 2 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 14, variation = 3 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 14, variation = 4 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 14, variation = 5 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 14, variation = 6 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 14, variation = 7 });

        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 0 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 1 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 2 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 3 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 4 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 5 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 6 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 7 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 8 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 9 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 10 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 11 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 12 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 13 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 14 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 15 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 16 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 17 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 18 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 19 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 20 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 21 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 22 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 23 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 24 });
        acessories.Add(new { sex = 1, category = "Boina", component = 0, draw = 105, variation = 25 });

        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 13, variation = 0 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 13, variation = 1 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 13, variation = 2 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 13, variation = 3 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 13, variation = 4 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 13, variation = 5 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 13, variation = 6 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 13, variation = 7 });

        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 20, variation = 0 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 20, variation = 1 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 20, variation = 2 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 20, variation = 3 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 20, variation = 4 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 20, variation = 5 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 20, variation = 6 });




        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 21, variation = 0 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 21, variation = 1 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 21, variation = 2 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 21, variation = 3 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 21, variation = 4 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 21, variation = 5 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 21, variation = 6 });

        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 26, variation = 0 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 26, variation = 1 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 26, variation = 2 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 26, variation = 3 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 26, variation = 4 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 26, variation = 5 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 26, variation = 6 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 26, variation = 7 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 26, variation = 8 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 26, variation = 9 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 26, variation = 10 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 26, variation = 11 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 26, variation = 12 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 26, variation = 13 });

        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 27, variation = 0 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 27, variation = 1 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 27, variation = 2 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 27, variation = 3 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 27, variation = 4 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 27, variation = 5 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 27, variation = 6 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 27, variation = 7 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 27, variation = 8 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 27, variation = 9 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 27, variation = 10 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 27, variation = 11 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 27, variation = 12 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 27, variation = 13 });


        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 28, variation = 0 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 28, variation = 1 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 28, variation = 2 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 28, variation = 3 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 28, variation = 4 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 28, variation = 5 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 28, variation = 6 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 28, variation = 7 });

        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 54, variation = 0 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 54, variation = 1 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 54, variation = 2 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 54, variation = 3 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 54, variation = 4 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 54, variation = 5 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 54, variation = 6 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 54, variation = 7 });

        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 93, variation = 0 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 93, variation = 1 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 93, variation = 2 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 93, variation = 3 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 93, variation = 4 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 93, variation = 5 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 93, variation = 6 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 93, variation = 7 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 93, variation = 8 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 93, variation = 9 });

        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 94, variation = 0 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 94, variation = 1 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 94, variation = 2 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 94, variation = 3 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 94, variation = 4 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 94, variation = 5 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 94, variation = 6 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 94, variation = 7 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 94, variation = 8 });
        acessories.Add(new { sex = 1, category = "Chapeu", component = 0, draw = 94, variation = 9 });

        acessories.Add(new { sex = 1, category = "Item de Natal", component = 0, draw = 96, variation = 0 });
        acessories.Add(new { sex = 1, category = "Item de Natal", component = 0, draw = 96, variation = 1 });
        acessories.Add(new { sex = 1, category = "Item de Natal", component = 0, draw = 96, variation = 2 });
        acessories.Add(new { sex = 1, category = "Item de Natal", component = 0, draw = 96, variation = 3 });
        acessories.Add(new { sex = 1, category = "Item de Natal", component = 0, draw = 97, variation = 0 });
        acessories.Add(new { sex = 1, category = "Item de Natal", component = 0, draw = 98, variation = 0 });
        acessories.Add(new { sex = 1, category = "Item de Natal", component = 0, draw = 99, variation = 0 });
        acessories.Add(new { sex = 1, category = "Item de Natal", component = 0, draw = 100, variation = 0 });


        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 1, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 1, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 1, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 1, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 1, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 1, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 1, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 1, variation = 7 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 1, variation = 8 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 1, variation = 9 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 1, variation = 10 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 2, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 2, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 2, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 2, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 2, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 2, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 2, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 2, variation = 7 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 2, variation = 8 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 2, variation = 9 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 2, variation = 10 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 3, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 3, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 3, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 3, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 3, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 3, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 3, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 3, variation = 7 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 3, variation = 8 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 3, variation = 9 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 3, variation = 10 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 4, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 4, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 4, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 4, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 4, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 4, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 4, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 4, variation = 7 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 4, variation = 8 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 4, variation = 9 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 4, variation = 10 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 6, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 6, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 6, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 6, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 6, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 6, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 6, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 6, variation = 7 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 6, variation = 8 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 6, variation = 9 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 6, variation = 10 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 7, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 7, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 7, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 7, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 7, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 7, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 7, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 7, variation = 7 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 7, variation = 8 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 7, variation = 9 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 7, variation = 10 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 7 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 8 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 9 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 10 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 7 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 8 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 9 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 8, variation = 10 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 9, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 9, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 9, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 9, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 9, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 9, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 9, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 9, variation = 7 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 9, variation = 8 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 9, variation = 9 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 9, variation = 10 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 10, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 10, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 10, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 10, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 10, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 10, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 10, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 10, variation = 7 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 10, variation = 8 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 10, variation = 9 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 10, variation = 10 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 11, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 11, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 11, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 11, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 11, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 11, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 11, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 11, variation = 7 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 11, variation = 8 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 11, variation = 9 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 14, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 14, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 14, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 14, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 14, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 14, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 14, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 14, variation = 7 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 14, variation = 8 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 14, variation = 9 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 14, variation = 10 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 16, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 16, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 16, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 16, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 16, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 16, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 16, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 16, variation = 7 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 16, variation = 8 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 16, variation = 9 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 17, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 17, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 17, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 17, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 17, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 17, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 17, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 17, variation = 7 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 17, variation = 8 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 17, variation = 9 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 18, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 18, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 18, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 18, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 18, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 18, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 18, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 18, variation = 7 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 19, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 19, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 19, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 19, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 19, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 19, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 19, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 19, variation = 7 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 19, variation = 8 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 19, variation = 9 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 19, variation = 10 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 20, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 20, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 20, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 20, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 20, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 20, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 20, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 20, variation = 7 });

        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 21, variation = 0 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 21, variation = 1 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 21, variation = 2 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 21, variation = 3 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 21, variation = 4 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 21, variation = 5 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 21, variation = 6 });
        acessories.Add(new { sex = 1, category = "Oculus", component = 1, draw = 21, variation = 7 });

        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 25, variation = 0 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 25, variation = 1 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 25, variation = 2 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 25, variation = 3 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 25, variation = 4 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 25, variation = 5 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 25, variation = 6 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 25, variation = 7 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 25, variation = 8 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 25, variation = 9 });

        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 24, variation = 0 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 24, variation = 1 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 24, variation = 2 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 24, variation = 3 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 24, variation = 4 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 24, variation = 5 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 24, variation = 6 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 24, variation = 7 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 24, variation = 8 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 24, variation = 9 });

        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 23, variation = 0 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 23, variation = 1 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 23, variation = 2 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 23, variation = 3 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 23, variation = 4 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 23, variation = 5 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 23, variation = 6 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 23, variation = 7 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 23, variation = 8 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 23, variation = 9 });

        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 22, variation = 0 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 22, variation = 1 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 22, variation = 2 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 22, variation = 3 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 22, variation = 4 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 22, variation = 5 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 22, variation = 6 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 22, variation = 7 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 22, variation = 8 });
        acessories.Add(new { sex = 1, category = "Uhr", component = 1, draw = 22, variation = 9 });

        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 25, variation = 0 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 25, variation = 1 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 25, variation = 2 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 25, variation = 3 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 25, variation = 4 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 25, variation = 5 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 25, variation = 6 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 25, variation = 7 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 25, variation = 8 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 25, variation = 9 });

        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 24, variation = 0 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 24, variation = 1 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 24, variation = 2 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 24, variation = 3 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 24, variation = 4 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 24, variation = 5 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 24, variation = 6 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 24, variation = 7 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 24, variation = 8 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 24, variation = 9 });

        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 23, variation = 0 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 23, variation = 1 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 23, variation = 2 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 23, variation = 3 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 23, variation = 4 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 23, variation = 5 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 23, variation = 6 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 23, variation = 7 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 23, variation = 8 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 23, variation = 9 });

        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 22, variation = 0 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 22, variation = 1 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 22, variation = 2 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 22, variation = 3 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 22, variation = 4 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 22, variation = 5 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 22, variation = 6 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 22, variation = 7 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 22, variation = 8 });
        acessories.Add(new { sex = 0, category = "Uhr", component = 1, draw = 22, variation = 9 });

        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 25, variation = 0 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 25, variation = 1 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 25, variation = 2 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 25, variation = 3 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 25, variation = 4 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 25, variation = 5 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 25, variation = 6 });

        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 24, variation = 0 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 24, variation = 1 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 24, variation = 2 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 24, variation = 3 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 24, variation = 4 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 24, variation = 5 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 24, variation = 6 });

        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 23, variation = 0 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 23, variation = 1 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 23, variation = 2 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 23, variation = 3 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 23, variation = 4 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 23, variation = 5 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 23, variation = 6 });

        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 22, variation = 0 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 22, variation = 1 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 22, variation = 2 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 22, variation = 3 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 22, variation = 4 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 22, variation = 5 });
        acessories.Add(new { sex = 1, category = "Armband", component = 1, draw = 22, variation = 6 });

        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 25, variation = 0 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 25, variation = 1 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 25, variation = 2 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 25, variation = 3 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 25, variation = 4 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 25, variation = 5 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 25, variation = 6 });

        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 24, variation = 0 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 24, variation = 1 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 24, variation = 2 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 24, variation = 3 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 24, variation = 4 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 24, variation = 5 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 24, variation = 6 });

        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 23, variation = 0 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 23, variation = 1 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 23, variation = 2 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 23, variation = 3 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 23, variation = 4 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 23, variation = 5 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 23, variation = 6 });

        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 22, variation = 0 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 22, variation = 1 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 22, variation = 2 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 22, variation = 3 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 22, variation = 4 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 22, variation = 5 });
        acessories.Add(new { sex = 0, category = "Armband", component = 1, draw = 22, variation = 6 });

        traje_list.Add(new { id = 1, name = "Basico Jeans", price = 250 });
        traje_list.Add(new { id = 2, name = "Corrida Matinal", price = 275 });
        traje_list.Add(new { id = 3, name = "Xadrez Basico", price = 189 });
        traje_list.Add(new { id = 4, name = "Casual", price = 288 });
        traje_list.Add(new { id = 5, name = "Esportista", price = 275 });
        traje_list.Add(new { id = 6, name = "Moletom de Corrida", price = 325 });
        traje_list.Add(new { id = 7, name = "Rolezinho", price = 452 });
        traje_list.Add(new { id = 8, name = "Rolezinho(2)", price = 455 });
        traje_list.Add(new { id = 9, name = "Camuflado Basico", price = 411 });
        traje_list.Add(new { id = 10, name = "Social Basico", price = 510 });
        traje_list.Add(new { id = 22, name = "Social Basico(2)", price = 510 });
        traje_list.Add(new { id = 36, name = "Social Basico(3)", price = 510 });
        traje_list.Add(new { id = 11, name = "Vestuario Arido", price = 421 });
        traje_list.Add(new { id = 12, name = "Militante", price = 277 });
        traje_list.Add(new { id = 13, name = "Agasalho", price = 327 });
        traje_list.Add(new { id = 16, name = "Agasalho 2", price = 336 });
        traje_list.Add(new { id = 21, name = "Social Extravagante", price = 611 });
        traje_list.Add(new { id = 24, name = "Frio Extremo", price = 575 });
        traje_list.Add(new { id = 29, name = "Motoqueiro", price = 550 });
        traje_list.Add(new { id = 33, name = "Old School", price = 437 });
        traje_list.Add(new { id = 34, name = "Descolado", price = 460 });
        traje_list.Add(new { id = 35, name = "Descolado(2)", price = 460 });
        traje_list.Add(new { id = 37, name = "Descolado(3)", price = 460 });
        traje_list.Add(new { id = 38, name = "Piloto", price = 627 });
        traje_list.Add(new { id = 40, name = "Reunião Empresarial", price = 780 });
        traje_list.Add(new { id = 41, name = "Reunião Empresarial(2)", price = 790 });
        traje_list.Add(new { id = 42, name = "Reunião Empresarial(3)", price = 790 });
        traje_list.Add(new { id = 61, name = "Esportivo", price = 500 });
        traje_list.Add(new { id = 62, name = "Dance Pop", price = 510 });
        traje_list.Add(new { id = 63, name = "Badboy", price = 600 });
        traje_list.Add(new { id = 69, name = "Havai", price = 250 });
        traje_list.Add(new { id = 70, name = "Fitness", price = 375 });

        //
        // Camisas
        //
        #region Female_Clothes
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 1", clothe_Id = 2, clothe_Texture = 0, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 2", clothe_Id = 2, clothe_Texture = 1, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 3", clothe_Id = 2, clothe_Texture = 2, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 4", clothe_Id = 2, clothe_Texture = 3, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 5", clothe_Id = 2, clothe_Texture = 4, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 6", clothe_Id = 2, clothe_Texture = 5, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 7", clothe_Id = 2, clothe_Texture = 6, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 8", clothe_Id = 2, clothe_Texture = 7, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 9", clothe_Id = 2, clothe_Texture = 8, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 10", clothe_Id = 2, clothe_Texture = 9, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 11", clothe_Id = 2, clothe_Texture = 10, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 12", clothe_Id = 2, clothe_Texture = 11, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 13", clothe_Id = 2, clothe_Texture = 12, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 14", clothe_Id = 2, clothe_Texture = 13, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 15", clothe_Id = 2, clothe_Texture = 14, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 16", clothe_Id = 2, clothe_Texture = 15, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F.", clothe_Id = 38, clothe_Texture = 0, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F.", clothe_Id = 38, clothe_Texture = 1, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F.", clothe_Id = 38, clothe_Texture = 2, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F.", clothe_Id = 38, clothe_Texture = 3, clothe_Torso = 2, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 17", clothe_Id = 23, clothe_Texture = 0, clothe_Torso = 4, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 18", clothe_Id = 23, clothe_Texture = 1, clothe_Torso = 4, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 19", clothe_Id = 23, clothe_Texture = 2, clothe_Torso = 4, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 20", clothe_Id = 49, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 21", clothe_Id = 49, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. 22", clothe_Id = 49, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 1", clothe_Id = 9, clothe_Texture = 0, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 2", clothe_Id = 9, clothe_Texture = 1, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 3", clothe_Id = 9, clothe_Texture = 2, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 4", clothe_Id = 9, clothe_Texture = 3, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 5", clothe_Id = 9, clothe_Texture = 4, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 6", clothe_Id = 9, clothe_Texture = 5, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 7", clothe_Id = 9, clothe_Texture = 6, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 8", clothe_Id = 9, clothe_Texture = 7, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 9", clothe_Id = 9, clothe_Texture = 8, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 10", clothe_Id = 9, clothe_Texture = 9, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 11", clothe_Id = 9, clothe_Texture = 10, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 12", clothe_Id = 9, clothe_Texture = 11, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 13", clothe_Id = 9, clothe_Texture = 12, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 14", clothe_Id = 9, clothe_Texture = 13, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 15", clothe_Id = 9, clothe_Texture = 14, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 16", clothe_Id = 17, clothe_Texture = 0, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 17", clothe_Id = 27, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 18", clothe_Id = 27, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 19", clothe_Id = 27, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 20", clothe_Id = 27, clothe_Texture = 3, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 21", clothe_Id = 27, clothe_Texture = 4, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 22", clothe_Id = 27, clothe_Texture = 5, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. Social 23", clothe_Id = 96, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 1", clothe_Id = 68, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 2", clothe_Id = 68, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 3", clothe_Id = 68, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 4", clothe_Id = 68, clothe_Texture = 3, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 5", clothe_Id = 68, clothe_Texture = 4, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 6", clothe_Id = 68, clothe_Texture = 5, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 7", clothe_Id = 68, clothe_Texture = 6, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 8", clothe_Id = 68, clothe_Texture = 7, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 9", clothe_Id = 68, clothe_Texture = 8, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 10", clothe_Id = 68, clothe_Texture = 9, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 11", clothe_Id = 68, clothe_Texture = 10, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 12", clothe_Id = 68, clothe_Texture = 11, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 13", clothe_Id = 68, clothe_Texture = 12, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 14", clothe_Id = 68, clothe_Texture = 13, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 15", clothe_Id = 68, clothe_Texture = 14, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 16", clothe_Id = 68, clothe_Texture = 15, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 17", clothe_Id = 68, clothe_Texture = 16, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 18", clothe_Id = 68, clothe_Texture = 17, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 19", clothe_Id = 68, clothe_Texture = 18, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas", clothe_Name = "Camisa F. C/ Desenho 20", clothe_Id = 68, clothe_Texture = 19, clothe_Torso = 0, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        //
        // Camisetas
        //
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. de Malha Azul", clothe_Id = 11, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. de Malha Roxo", clothe_Id = 11, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. de Malha Cinza", clothe_Id = 11, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Vermelha", clothe_Id = 16, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rosa", clothe_Id = 16, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Azul", clothe_Id = 16, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Roxa c/ Rosa", clothe_Id = 16, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Verde c/ Azul", clothe_Id = 16, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Vermelho Vibrante", clothe_Id = 16, clothe_Texture = 5, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Roxa", clothe_Id = 16, clothe_Texture = 6, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Ceda Branca", clothe_Id = 26, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Ceda Preto", clothe_Id = 26, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Ceda Vermelho", clothe_Id = 26, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Ceda Bege", clothe_Id = 26, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Ceda Roxo", clothe_Id = 26, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Ceda Azul Escuro", clothe_Id = 26, clothe_Texture = 5, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Ceda Azul Aqua", clothe_Id = 26, clothe_Texture = 6, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Ceda Amarela", clothe_Id = 26, clothe_Texture = 7, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Ceda Azul Claro", clothe_Id = 26, clothe_Texture = 8, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Ceda Cinza", clothe_Id = 26, clothe_Texture = 9, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Ceda Laranja", clothe_Id = 26, clothe_Texture = 10, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Ceda Oncinha", clothe_Id = 26, clothe_Texture = 11, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Ceda Rosa", clothe_Id = 26, clothe_Texture = 12, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Oncinha", clothe_Id = 32, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Caveira", clothe_Id = 32, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Listas", clothe_Id = 32, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. C/ Desenho 01", clothe_Id = 36, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. C/ Desenho 02", clothe_Id = 36, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. C/ Desenho 03", clothe_Id = 36, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. C/ Desenho 04", clothe_Id = 36, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. C/ Desenho 05", clothe_Id = 36, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Preta", clothe_Id = 168, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Cinza", clothe_Id = 168, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Vermelha", clothe_Id = 168, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Branca", clothe_Id = 168, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Marrom", clothe_Id = 168, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Exercito", clothe_Id = 168, clothe_Texture = 5, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada C/ Manga Preta", clothe_Id = 169, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada C/ Manga Cinza", clothe_Id = 169, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada C/ Manga Vermelha", clothe_Id = 169, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada C/ Manga Branca", clothe_Id = 169, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada C/ Manga Marrom", clothe_Id = 169, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada C/ Manga Exercito", clothe_Id = 169, clothe_Texture = 5, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Preta", clothe_Id = 170, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza", clothe_Id = 170, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });

        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza0", clothe_Id = 74, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza1", clothe_Id = 74, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza2", clothe_Id = 74, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });

        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza13", clothe_Id = 1, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza14", clothe_Id = 1, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza15", clothe_Id = 1, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza16", clothe_Id = 1, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });

        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza18", clothe_Id = 6, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza19", clothe_Id = 6, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza20", clothe_Id = 6, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });

        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza23", clothe_Id = 63, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza24", clothe_Id = 63, clothe_Texture = 1, clothe_Torso = 6, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza25", clothe_Id = 63, clothe_Texture = 2, clothe_Torso = 6, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza26", clothe_Id = 63, clothe_Texture = 3, clothe_Torso = 6, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza27", clothe_Id = 63, clothe_Texture = 4, clothe_Torso = 6, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza28", clothe_Id = 207, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 13, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza29", clothe_Id = 207, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 13, clother_UnderShirtTexture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza30", clothe_Id = 207, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 13, clother_UnderShirtTexture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza31", clothe_Id = 207, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 13, clother_UnderShirtTexture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Cinza32", clothe_Id = 207, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 13, clother_UnderShirtTexture = 4 });



        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Vermelha", clothe_Id = 170, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Branca", clothe_Id = 170, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Marrom", clothe_Id = 170, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Rasgada Curta Exercito", clothe_Id = 170, clothe_Texture = 5, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 01", clothe_Id = 195, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 02", clothe_Id = 195, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 03", clothe_Id = 195, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 04", clothe_Id = 195, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 05", clothe_Id = 195, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 06", clothe_Id = 195, clothe_Texture = 5, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 07", clothe_Id = 195, clothe_Texture = 6, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 08", clothe_Id = 195, clothe_Texture = 7, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 09", clothe_Id = 195, clothe_Texture = 8, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 10", clothe_Id = 195, clothe_Texture = 9, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 11", clothe_Id = 195, clothe_Texture = 10, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 12", clothe_Id = 195, clothe_Texture = 11, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 13", clothe_Id = 195, clothe_Texture = 12, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 14", clothe_Id = 195, clothe_Texture = 13, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 15", clothe_Id = 195, clothe_Texture = 14, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 16", clothe_Id = 195, clothe_Texture = 15, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 17", clothe_Id = 195, clothe_Texture = 16, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 18", clothe_Id = 195, clothe_Texture = 17, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 19", clothe_Id = 195, clothe_Texture = 18, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 20", clothe_Id = 195, clothe_Texture = 19, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 21", clothe_Id = 195, clothe_Texture = 20, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 22", clothe_Id = 195, clothe_Texture = 21, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 23", clothe_Id = 195, clothe_Texture = 22, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 24", clothe_Id = 195, clothe_Texture = 23, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 25", clothe_Id = 195, clothe_Texture = 24, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta C/ Manga 26", clothe_Id = 195, clothe_Texture = 25, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 01", clothe_Id = 209, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 02", clothe_Id = 209, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 03", clothe_Id = 209, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 04", clothe_Id = 209, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 05", clothe_Id = 209, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 06", clothe_Id = 209, clothe_Texture = 5, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 07", clothe_Id = 209, clothe_Texture = 6, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 08", clothe_Id = 209, clothe_Texture = 7, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 09", clothe_Id = 209, clothe_Texture = 8, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 10", clothe_Id = 209, clothe_Texture = 9, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 11", clothe_Id = 209, clothe_Texture = 10, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 12", clothe_Id = 209, clothe_Texture = 11, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 13", clothe_Id = 209, clothe_Texture = 12, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 14", clothe_Id = 209, clothe_Texture = 13, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 15", clothe_Id = 209, clothe_Texture = 14, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 16", clothe_Id = 209, clothe_Texture = 15, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 17", clothe_Id = 209, clothe_Texture = 16, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });

        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 001", clothe_Id = 207, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 002", clothe_Id = 207, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 15, clother_UnderShirtTexture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 003", clothe_Id = 207, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 15, clother_UnderShirtTexture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 004", clothe_Id = 207, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 15, clother_UnderShirtTexture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 005", clothe_Id = 207, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 15, clother_UnderShirtTexture = 4 });


        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 0003", clothe_Id = 161, clothe_Texture = 0, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 0004", clothe_Id = 161, clothe_Texture = 1, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisetas", clothe_Name = "Camiseta F. Curta 0005", clothe_Id = 161, clothe_Texture = 2, clothe_Torso = 9, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });

        //
        // Vestidos
        //
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 1", clothe_Id = 21, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 2", clothe_Id = 21, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 3", clothe_Id = 21, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 4", clothe_Id = 21, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 5", clothe_Id = 21, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 6", clothe_Id = 21, clothe_Texture = 5, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 7", clothe_Id = 37, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 8", clothe_Id = 37, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 9", clothe_Id = 37, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 10", clothe_Id = 37, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 11", clothe_Id = 37, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 12", clothe_Id = 37, clothe_Texture = 5, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 13", clothe_Id = 112, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 14", clothe_Id = 112, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 15", clothe_Id = 112, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 16", clothe_Id = 113, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 17", clothe_Id = 113, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 18", clothe_Id = 113, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 19", clothe_Id = 114, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 20", clothe_Id = 114, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 21", clothe_Id = 114, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 22", clothe_Id = 115, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 23", clothe_Id = 115, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 24", clothe_Id = 115, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 25", clothe_Id = 116, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 26", clothe_Id = 116, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 27", clothe_Id = 116, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 28", clothe_Id = 40, clothe_Texture = 0, clothe_Torso = 11, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 29", clothe_Id = 40, clothe_Texture = 1, clothe_Torso = 11, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 30", clothe_Id = 39, clothe_Texture = 0, clothe_Torso = 11, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 30", clothe_Id = 67, clothe_Texture = 0, clothe_Torso = 11, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Vestidos", clothe_Name = "Vestido 30", clothe_Id = 56, clothe_Texture = 0, clothe_Torso = 11, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });

        //
        // Biquine
        //
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine Branco", clothe_Id = 18, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine Preto", clothe_Id = 18, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine Azul", clothe_Id = 18, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine Oncinha", clothe_Id = 18, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine Vermelho", clothe_Id = 18, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine Colorido", clothe_Id = 18, clothe_Texture = 5, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine Camuflado", clothe_Id = 18, clothe_Texture = 6, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine Rosa Escuro", clothe_Id = 18, clothe_Texture = 7, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine Rosa Claro", clothe_Id = 18, clothe_Texture = 8, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine Praiano", clothe_Id = 18, clothe_Texture = 9, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine C/ Flores", clothe_Id = 18, clothe_Texture = 10, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine Azul C/ Laranja", clothe_Id = 18, clothe_Texture = 11, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine C/ Desenho Rosa", clothe_Id = 101, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine C/ Desenho Preto", clothe_Id = 101, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine C/ Desenho Amarelo", clothe_Id = 101, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine C/ Desenho Marrom", clothe_Id = 101, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine C/ Desenho Laranja", clothe_Id = 101, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Biquine", clothe_Name = "Biquine C/ Desenho Azul", clothe_Id = 101, clothe_Texture = 5, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });

        //
        // Tops
        //
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Preto", clothe_Id = 13, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy C/ Rosas", clothe_Id = 13, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Verde", clothe_Id = 13, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Cinza", clothe_Id = 13, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy C/ Rosas Vibrante", clothe_Id = 13, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Quadriculado Vermelho", clothe_Id = 13, clothe_Texture = 5, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy preto C/ Pedras Diamente", clothe_Id = 13, clothe_Texture = 6, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Rosa Shock", clothe_Id = 13, clothe_Texture = 7, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Branco", clothe_Id = 13, clothe_Texture = 8, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Azul", clothe_Id = 13, clothe_Texture = 9, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Jeans", clothe_Id = 13, clothe_Texture = 10, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Rosa Claro", clothe_Id = 13, clothe_Texture = 11, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Camuflado", clothe_Id = 13, clothe_Texture = 12, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Azul Vibrante", clothe_Id = 13, clothe_Texture = 13, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Preto e Branco", clothe_Id = 13, clothe_Texture = 14, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Oncinha", clothe_Id = 13, clothe_Texture = 15, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Preto", clothe_Id = 13, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy C/ Rosas", clothe_Id = 13, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Verde", clothe_Id = 13, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Cinza", clothe_Id = 13, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy C/ Rosas Vibrante", clothe_Id = 13, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Quadriculado Vermelho", clothe_Id = 13, clothe_Texture = 5, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy preto C/ Pedras Diamente", clothe_Id = 13, clothe_Texture = 6, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Rosa Shock", clothe_Id = 13, clothe_Texture = 7, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Branco", clothe_Id = 13, clothe_Texture = 8, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Azul", clothe_Id = 13, clothe_Texture = 9, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Jeans", clothe_Id = 13, clothe_Texture = 10, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Rosa Claro", clothe_Id = 13, clothe_Texture = 11, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Camuflado", clothe_Id = 13, clothe_Texture = 12, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Azul Vibrante", clothe_Id = 13, clothe_Texture = 13, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Preto e Branco", clothe_Id = 13, clothe_Texture = 14, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top Sexy Oncinha", clothe_Id = 13, clothe_Texture = 15, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Branca", clothe_Id = 22, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Vermelha", clothe_Id = 22, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Preto", clothe_Id = 22, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Preto Transparente", clothe_Id = 22, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Azul Transparente", clothe_Id = 22, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Sexy Bege", clothe_Id = 111, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Sexy Rosa claro", clothe_Id = 111, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Sexy Vermelho C/ Preto", clothe_Id = 111, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Sexy Azul", clothe_Id = 111, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Sexy Vermelho C/ Oncinha", clothe_Id = 111, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Sexy Branco C/ Coração", clothe_Id = 111, clothe_Texture = 5, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Sexy Preto C/ Coração", clothe_Id = 111, clothe_Texture = 6, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Sexy Vermelho C/ Coração", clothe_Id = 111, clothe_Texture = 7, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Sexy Rosa Escuro", clothe_Id = 111, clothe_Texture = 8, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Sexy Bege Escuro", clothe_Id = 111, clothe_Texture = 9, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Sexy Preto C/ Oncinha", clothe_Id = 111, clothe_Texture = 10, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Lanjerrie Sexy Vermelho e Bege", clothe_Id = 111, clothe_Texture = 11, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top C/ Desenho 01", clothe_Id = 33, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top C/ Desenho 02", clothe_Id = 33, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top C/ Desenho 03", clothe_Id = 33, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top C/ Desenho 04", clothe_Id = 33, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top C/ Desenho 05", clothe_Id = 33, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top C/ Desenho 06", clothe_Id = 33, clothe_Texture = 5, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top C/ Desenho 07", clothe_Id = 33, clothe_Texture = 6, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top C/ Desenho 08", clothe_Id = 33, clothe_Texture = 7, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Top", clothe_Name = "Top C/ Desenho 09", clothe_Id = 33, clothe_Texture = 8, clothe_Torso = 15, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        //
        // Moletons
        //
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Branco", clothe_Id = 3, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Cinza", clothe_Id = 3, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Preto", clothe_Id = 3, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Azul", clothe_Id = 3, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Marrom", clothe_Id = 3, clothe_Texture = 4, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado Preto", clothe_Id = 78, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado Cinza", clothe_Id = 78, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado Roxo", clothe_Id = 78, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado Azul", clothe_Id = 78, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado Rosa", clothe_Id = 78, clothe_Texture = 4, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado Branco", clothe_Id = 78, clothe_Texture = 5, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado Azul Escuro", clothe_Id = 78, clothe_Texture = 6, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado Vermelho", clothe_Id = 78, clothe_Texture = 7, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fecho Branco", clothe_Id = 80, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Americano", clothe_Id = 50, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Jeans", clothe_Id = 55, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Americano", clothe_Id = 50, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Time Escolar 01", clothe_Id = 72, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Time Escolar 02", clothe_Id = 81, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Time Escolar 03", clothe_Id = 81, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Time Escolar 04", clothe_Id = 81, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Time Escolar 05", clothe_Id = 81, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Time Escolar 06", clothe_Id = 81, clothe_Texture = 4, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Time Escolar 07", clothe_Id = 81, clothe_Texture = 5, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Time Escolar 08", clothe_Id = 81, clothe_Texture = 6, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Time Escolar 09", clothe_Id = 81, clothe_Texture = 7, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Time Escolar 10", clothe_Id = 81, clothe_Texture = 8, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Time Escolar 11", clothe_Id = 81, clothe_Texture = 9, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Time Escolar 12", clothe_Id = 81, clothe_Texture = 10, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Time Escolar 13", clothe_Id = 81, clothe_Texture = 11, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Time Escolar 14", clothe_Id = 87, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 01", clothe_Id = 202, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 02", clothe_Id = 202, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 03", clothe_Id = 202, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 04", clothe_Id = 202, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 05", clothe_Id = 202, clothe_Texture = 4, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 06", clothe_Id = 202, clothe_Texture = 5, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 07", clothe_Id = 202, clothe_Texture = 6, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 08", clothe_Id = 202, clothe_Texture = 7, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 09", clothe_Id = 202, clothe_Texture = 8, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 10", clothe_Id = 202, clothe_Texture = 9, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 11", clothe_Id = 202, clothe_Texture = 10, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 12", clothe_Id = 202, clothe_Texture = 11, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 13", clothe_Id = 202, clothe_Texture = 12, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 14", clothe_Id = 202, clothe_Texture = 13, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 15", clothe_Id = 202, clothe_Texture = 14, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 16", clothe_Id = 202, clothe_Texture = 15, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 17", clothe_Id = 202, clothe_Texture = 16, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 18", clothe_Id = 202, clothe_Texture = 17, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 19", clothe_Id = 202, clothe_Texture = 18, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 20", clothe_Id = 202, clothe_Texture = 19, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 21", clothe_Id = 202, clothe_Texture = 20, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 22", clothe_Id = 202, clothe_Texture = 21, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 23", clothe_Id = 202, clothe_Texture = 22, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 24", clothe_Id = 202, clothe_Texture = 23, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 25", clothe_Id = 202, clothe_Texture = 24, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton C/ Desenhos 26", clothe_Id = 202, clothe_Texture = 25, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Frio 01", clothe_Id = 98, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Frio 02", clothe_Id = 98, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Frio 03", clothe_Id = 98, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Frio 04", clothe_Id = 98, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Frio 05", clothe_Id = 98, clothe_Texture = 4, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Inverno 01", clothe_Id = 102, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Inverno 02", clothe_Id = 135, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Inverno 03", clothe_Id = 135, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Inverno 04", clothe_Id = 135, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado P/ Dentro 01", clothe_Id = 103, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado P/ Dentro 02", clothe_Id = 103, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado P/ Dentro 03", clothe_Id = 103, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado P/ Dentro 04", clothe_Id = 103, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado P/ Dentro 05", clothe_Id = 103, clothe_Texture = 4, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado P/ Dentro 06", clothe_Id = 103, clothe_Texture = 5, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado P/ Dentro 07", clothe_Id = 136, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado P/ Dentro 08", clothe_Id = 136, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado P/ Dentro 09", clothe_Id = 136, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado P/ Dentro 10", clothe_Id = 136, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado P/ Dentro 11", clothe_Id = 136, clothe_Texture = 4, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado P/ Dentro 12", clothe_Id = 136, clothe_Texture = 5, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado P/ Dentro 13", clothe_Id = 136, clothe_Texture = 6, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Fechado P/ Dentro 14", clothe_Id = 136, clothe_Texture = 7, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de Couro 01", clothe_Id = 110, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de Couro 02", clothe_Id = 110, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de Couro 03", clothe_Id = 110, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de Couro 04", clothe_Id = 110, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de Couro 05", clothe_Id = 110, clothe_Texture = 4, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de Couro 06", clothe_Id = 110, clothe_Texture = 5, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de Couro 07", clothe_Id = 110, clothe_Texture = 6, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de Couro 08", clothe_Id = 110, clothe_Texture = 7, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de Couro 09", clothe_Id = 110, clothe_Texture = 8, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de Couro 10", clothe_Id = 110, clothe_Texture = 9, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de 2 Panos 01", clothe_Id = 123, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de 2 Panos 02", clothe_Id = 123, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de 2 Panos 03", clothe_Id = 123, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de 2 Panos 04", clothe_Id = 123, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de 2 Panos 05", clothe_Id = 123, clothe_Texture = 4, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de 2 Panos 06", clothe_Id = 123, clothe_Texture = 5, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de 2 Panos 07", clothe_Id = 123, clothe_Texture = 6, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de 2 Panos 08", clothe_Id = 123, clothe_Texture = 7, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de 2 Panos 09", clothe_Id = 123, clothe_Texture = 8, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de 2 Panos 10", clothe_Id = 123, clothe_Texture = 9, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de 2 Panos 11", clothe_Id = 123, clothe_Texture = 10, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton de 2 Panos 12", clothe_Id = 123, clothe_Texture = 11, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton da SecureServ", clothe_Id = 127, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton da Libery Preto", clothe_Id = 131, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton da Libery Vermelho", clothe_Id = 131, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton da Flying Bravo", clothe_Id = 131, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Branco C/ Verde", clothe_Id = 140, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Branco C/ Laranja", clothe_Id = 140, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Branco C/ Roxo", clothe_Id = 140, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Branco C/ Rosa", clothe_Id = 140, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Branco C/ Vermelho Escuro", clothe_Id = 140, clothe_Texture = 4, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Branco C/ Azul", clothe_Id = 140, clothe_Texture = 5, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Branco C/ Cinza", clothe_Id = 140, clothe_Texture = 6, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Branco C/ Bege", clothe_Id = 140, clothe_Texture = 7, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Preto C/ Branco", clothe_Id = 140, clothe_Texture = 8, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Branco C/ Preto", clothe_Id = 140, clothe_Texture = 9, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 01", clothe_Id = 147, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 02", clothe_Id = 147, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 03", clothe_Id = 147, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 04", clothe_Id = 147, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 05", clothe_Id = 147, clothe_Texture = 4, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 06", clothe_Id = 147, clothe_Texture = 5, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 07", clothe_Id = 147, clothe_Texture = 6, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 08", clothe_Id = 147, clothe_Texture = 7, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 09", clothe_Id = 147, clothe_Texture = 8, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 10", clothe_Id = 147, clothe_Texture = 9, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 11", clothe_Id = 147, clothe_Texture = 10, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 12", clothe_Id = 147, clothe_Texture = 11, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 13", clothe_Id = 150, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 14", clothe_Id = 150, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 15", clothe_Id = 150, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 16", clothe_Id = 150, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 17", clothe_Id = 150, clothe_Texture = 4, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 18", clothe_Id = 150, clothe_Texture = 5, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 19", clothe_Id = 150, clothe_Texture = 6, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 20", clothe_Id = 150, clothe_Texture = 7, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 21", clothe_Id = 150, clothe_Texture = 8, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 22", clothe_Id = 150, clothe_Texture = 9, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 23", clothe_Id = 150, clothe_Texture = 10, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 24", clothe_Id = 150, clothe_Texture = 11, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 25", clothe_Id = 150, clothe_Texture = 12, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 26", clothe_Id = 150, clothe_Texture = 13, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 27", clothe_Id = 150, clothe_Texture = 14, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 28", clothe_Id = 150, clothe_Texture = 15, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 29", clothe_Id = 150, clothe_Texture = 16, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 30", clothe_Id = 150, clothe_Texture = 17, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 31", clothe_Id = 150, clothe_Texture = 18, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 32", clothe_Id = 150, clothe_Texture = 19, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 33", clothe_Id = 150, clothe_Texture = 20, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 34", clothe_Id = 150, clothe_Texture = 21, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 35", clothe_Id = 150, clothe_Texture = 22, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 36", clothe_Id = 150, clothe_Texture = 23, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 37", clothe_Id = 150, clothe_Texture = 24, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Fechado 38", clothe_Id = 150, clothe_Texture = 25, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Meio Aberto 01", clothe_Id = 165, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Meio Aberto 02", clothe_Id = 165, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Meio Aberto 03", clothe_Id = 165, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco de Motoqueiro 01", clothe_Id = 176, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco de Motoqueiro 02", clothe_Id = 176, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco de Motoqueiro 03", clothe_Id = 176, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco de Motoqueiro 04", clothe_Id = 176, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Luxuoso 01", clothe_Id = 189, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Luxuoso 02", clothe_Id = 189, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Luxuoso 03", clothe_Id = 189, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Luxuoso 04", clothe_Id = 189, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Luxuoso 05", clothe_Id = 189, clothe_Texture = 4, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Luxuoso 06", clothe_Id = 189, clothe_Texture = 5, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Luxuoso 07", clothe_Id = 189, clothe_Texture = 6, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Luxuoso 08", clothe_Id = 189, clothe_Texture = 7, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Luxuoso 09", clothe_Id = 189, clothe_Texture = 8, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Luxuoso 10", clothe_Id = 189, clothe_Texture = 9, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Luxuoso 11", clothe_Id = 189, clothe_Texture = 10, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Luxuoso 12", clothe_Id = 189, clothe_Texture = 11, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Luxuoso 13", clothe_Id = 189, clothe_Texture = 12, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Ultra Inverno 01", clothe_Id = 190, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Ultra Inverno 02", clothe_Id = 190, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Ultra Inverno 03", clothe_Id = 190, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Ultra Inverno 04", clothe_Id = 190, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Ultra Inverno 05", clothe_Id = 190, clothe_Texture = 4, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Ultra Inverno 06", clothe_Id = 190, clothe_Texture = 5, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Ultra Inverno 07", clothe_Id = 190, clothe_Texture = 6, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Ultra Inverno 08", clothe_Id = 190, clothe_Texture = 7, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Ultra Inverno 09", clothe_Id = 190, clothe_Texture = 8, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Ultra Inverno 10", clothe_Id = 190, clothe_Texture = 9, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Casaco Ultra Inverno 11", clothe_Id = 190, clothe_Texture = 10, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 01", clothe_Id = 192, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 02", clothe_Id = 192, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 03", clothe_Id = 192, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 04", clothe_Id = 192, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 05", clothe_Id = 192, clothe_Texture = 4, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 06", clothe_Id = 192, clothe_Texture = 5, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 07", clothe_Id = 192, clothe_Texture = 6, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 08", clothe_Id = 192, clothe_Texture = 7, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 09", clothe_Id = 192, clothe_Texture = 8, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 10", clothe_Id = 192, clothe_Texture = 9, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 11", clothe_Id = 192, clothe_Texture = 10, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 12", clothe_Id = 192, clothe_Texture = 11, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 13", clothe_Id = 192, clothe_Texture = 12, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 14", clothe_Id = 192, clothe_Texture = 13, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 15", clothe_Id = 192, clothe_Texture = 14, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 16", clothe_Id = 192, clothe_Texture = 15, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 17", clothe_Id = 192, clothe_Texture = 16, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 18", clothe_Id = 192, clothe_Texture = 17, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 19", clothe_Id = 192, clothe_Texture = 18, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 20", clothe_Id = 192, clothe_Texture = 19, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 21", clothe_Id = 192, clothe_Texture = 20, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 22", clothe_Id = 192, clothe_Texture = 21, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 23", clothe_Id = 192, clothe_Texture = 22, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 24", clothe_Id = 192, clothe_Texture = 23, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 25", clothe_Id = 192, clothe_Texture = 24, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Moleton Meia Manga 26", clothe_Id = 192, clothe_Texture = 25, clothe_Torso = 1, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke kurz F.", clothe_Id = 8, clothe_Texture = 0, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke kurz F.", clothe_Id = 8, clothe_Texture = 0, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke kurz F.", clothe_Id = 8, clothe_Texture = 1, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke kurz F.", clothe_Id = 8, clothe_Texture = 1, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke kurz F.", clothe_Id = 8, clothe_Texture = 2, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke kurz F.", clothe_Id = 8, clothe_Texture = 2, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke kurz F.", clothe_Id = 35, clothe_Texture = 0, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke kurz F.", clothe_Id = 35, clothe_Texture = 0, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke kurz F.", clothe_Id = 35, clothe_Texture = 1, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke kurz F.", clothe_Id = 35, clothe_Texture = 1, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke kurz F.", clothe_Id = 35, clothe_Texture = 2, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke kurz F.", clothe_Id = 35, clothe_Texture = 2, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Pullover Arbeit F.", clothe_Id = 43, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Pullover Arbeit F.", clothe_Id = 43, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Pullover Arbeit F.", clothe_Id = 43, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Pullover Arbeit F.", clothe_Id = 43, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Pullover Arbeit F.", clothe_Id = 43, clothe_Texture = 4, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke lang geschlossen F.", clothe_Id = 53, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke lang geschlossen F.", clothe_Id = 53, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke lang geschlossen F.", clothe_Id = 53, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke lang geschlossen F.", clothe_Id = 53, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd zu F.", clothe_Id = 121, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd zu F.", clothe_Id = 121, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd zu F.", clothe_Id = 121, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd zu F.", clothe_Id = 121, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd zu F.", clothe_Id = 121, clothe_Texture = 4, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd zu F.", clothe_Id = 121, clothe_Texture = 5, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd zu F.", clothe_Id = 121, clothe_Texture = 6, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd zu F.", clothe_Id = 121, clothe_Texture = 7, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd zu F.", clothe_Id = 121, clothe_Texture = 8, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd zu F.", clothe_Id = 121, clothe_Texture = 9, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd zu F.", clothe_Id = 121, clothe_Texture = 10, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd zu F.", clothe_Id = 121, clothe_Texture = 11, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd zu F.", clothe_Id = 121, clothe_Texture = 12, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd zu F.", clothe_Id = 121, clothe_Texture = 13, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd zu F.", clothe_Id = 121, clothe_Texture = 14, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd offen ", clothe_Id = 120, clothe_Texture = 0, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd offen ", clothe_Id = 120, clothe_Texture = 1, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd offen ", clothe_Id = 120, clothe_Texture = 2, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd offen ", clothe_Id = 120, clothe_Texture = 3, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd offen ", clothe_Id = 120, clothe_Texture = 4, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd offen ", clothe_Id = 120, clothe_Texture = 5, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd offen ", clothe_Id = 120, clothe_Texture = 6, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd offen ", clothe_Id = 120, clothe_Texture = 7, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd offen ", clothe_Id = 120, clothe_Texture = 8, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd offen ", clothe_Id = 120, clothe_Texture = 9, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd offen ", clothe_Id = 120, clothe_Texture = 10, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd offen ", clothe_Id = 120, clothe_Texture = 11, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd offen ", clothe_Id = 120, clothe_Texture = 12, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd offen ", clothe_Id = 120, clothe_Texture = 13, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hemd offen ", clothe_Id = 120, clothe_Texture = 14, clothe_Torso = 5, clother_UnderShirt = 5, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hoodie Kapuze F.", clothe_Id = 172, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Hoodie Kapuze F.", clothe_Id = 172, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 3, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke Leder offen F.", clothe_Id = 148, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke Leder offen F.", clothe_Id = 148, clothe_Texture = 1, clothe_Torso = 6, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke Leder offen F.", clothe_Id = 148, clothe_Texture = 2, clothe_Torso = 6, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke Leder offen F.", clothe_Id = 148, clothe_Texture = 3, clothe_Torso = 6, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke Leder offen F.", clothe_Id = 148, clothe_Texture = 4, clothe_Torso = 6, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke Leder offen F.", clothe_Id = 148, clothe_Texture = 5, clothe_Torso = 6, clother_UnderShirt = 0, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke lang offen F.2", clothe_Id = 57, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke lang offen F.2", clothe_Id = 57, clothe_Texture = 1, clothe_Torso = 6, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke lang offen F.2", clothe_Id = 57, clothe_Texture = 2, clothe_Torso = 6, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke lang zu F.2", clothe_Id = 58, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke lang zu F.2", clothe_Id = 58, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Jacke lang zu F.2", clothe_Id = 58, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Kutte", clothe_Id = 159, clothe_Texture = 0, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Kutte", clothe_Id = 159, clothe_Texture = 0, clothe_Torso = 24, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Kutte", clothe_Id = 176, clothe_Texture = 0, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Kutte", clothe_Id = 176, clothe_Texture = 0, clothe_Torso = 24, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Kutte", clothe_Id = 175, clothe_Texture = 0, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Kutte", clothe_Id = 175, clothe_Texture = 0, clothe_Torso = 24, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Kutte", clothe_Id = 177, clothe_Texture = 0, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Kutte", clothe_Id = 177, clothe_Texture = 0, clothe_Torso = 24, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Kutte", clothe_Id = 178, clothe_Texture = 0, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Kutte", clothe_Id = 178, clothe_Texture = 0, clothe_Torso = 24, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Kutte", clothe_Id = 166, clothe_Texture = 0, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Kutte", clothe_Id = 174, clothe_Texture = 0, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Kutte", clothe_Id = 176, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Bluse", clothe_Id = 109, clothe_Texture = 0, clothe_Torso = 3, clother_UnderShirt = 21, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Bluse", clothe_Id = 109, clothe_Texture = 1, clothe_Torso = 3, clother_UnderShirt = 21, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Bluse", clothe_Id = 109, clothe_Texture = 2, clothe_Torso = 3, clother_UnderShirt = 21, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Moleton", clothe_Name = "Bluse", clothe_Id = 109, clothe_Texture = 3, clothe_Torso = 3, clother_UnderShirt = 21, clother_UnderShirtTexture = 0 });
        //
        // Camisas Polos
        //
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 01", clothe_Id = 14, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 02", clothe_Id = 14, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 03", clothe_Id = 14, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 04", clothe_Id = 14, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 05", clothe_Id = 14, clothe_Texture = 4, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 06", clothe_Id = 14, clothe_Texture = 5, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 07", clothe_Id = 14, clothe_Texture = 6, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 08", clothe_Id = 14, clothe_Texture = 7, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 09", clothe_Id = 14, clothe_Texture = 8, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 10", clothe_Id = 14, clothe_Texture = 9, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 11", clothe_Id = 14, clothe_Texture = 10, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 12", clothe_Id = 14, clothe_Texture = 11, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 13", clothe_Id = 14, clothe_Texture = 12, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 14", clothe_Id = 14, clothe_Texture = 13, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 15", clothe_Id = 14, clothe_Texture = 14, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 16", clothe_Id = 14, clothe_Texture = 15, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 17", clothe_Id = 84, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 18", clothe_Id = 84, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 19", clothe_Id = 84, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 20", clothe_Id = 85, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 21", clothe_Id = 85, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 22", clothe_Id = 85, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 23", clothe_Id = 119, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 24", clothe_Id = 119, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Camisas Polo", clothe_Name = "Camisa Polo 25", clothe_Id = 119, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });

        //
        // Calça Jeans
        //
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 1", clothe_Id = 1, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 2", clothe_Id = 1, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 3", clothe_Id = 1, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 4", clothe_Id = 1, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 5", clothe_Id = 1, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 6", clothe_Id = 1, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 7", clothe_Id = 1, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 8", clothe_Id = 1, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 9", clothe_Id = 1, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 10", clothe_Id = 1, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 11", clothe_Id = 1, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 12", clothe_Id = 1, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 13", clothe_Id = 1, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 14", clothe_Id = 1, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 15", clothe_Id = 1, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 16", clothe_Id = 1, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 16", clothe_Id = 73, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 17", clothe_Id = 73, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 18", clothe_Id = 73, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 19", clothe_Id = 73, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 20", clothe_Id = 73, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 21", clothe_Id = 73, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 22", clothe_Id = 74, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 23", clothe_Id = 74, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 24", clothe_Id = 74, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 25", clothe_Id = 74, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 26", clothe_Id = 74, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 27", clothe_Id = 74, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 28", clothe_Id = 84, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 29", clothe_Id = 84, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 30", clothe_Id = 84, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 31", clothe_Id = 84, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 32", clothe_Id = 84, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 33", clothe_Id = 84, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 34", clothe_Id = 85, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 35", clothe_Id = 85, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 36", clothe_Id = 85, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans 37", clothe_Id = 85, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Apertada 1", clothe_Id = 0, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Apertada 2", clothe_Id = 0, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Apertada 3", clothe_Id = 0, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Apertada 4", clothe_Id = 0, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Apertada 5", clothe_Id = 0, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Apertada 6", clothe_Id = 0, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Apertada 7", clothe_Id = 0, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Apertada 8", clothe_Id = 0, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Apertada 9", clothe_Id = 0, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Apertada 10", clothe_Id = 0, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Apertada 11", clothe_Id = 0, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Apertada 12", clothe_Id = 0, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Apertada 13", clothe_Id = 0, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Apertada 14", clothe_Id = 0, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Apertada 15", clothe_Id = 0, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Apertada 16", clothe_Id = 0, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Jegging 1", clothe_Id = 4, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Jegging 2", clothe_Id = 4, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Jegging 3", clothe_Id = 4, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Jegging 4", clothe_Id = 4, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Jegging 5", clothe_Id = 4, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Jegging 6", clothe_Id = 4, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Jegging 7", clothe_Id = 4, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Jegging 8", clothe_Id = 4, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Jegging 9", clothe_Id = 4, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Jegging 10", clothe_Id = 4, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Jegging 11", clothe_Id = 4, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Jegging 12", clothe_Id = 4, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Jegging 13", clothe_Id = 4, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Jegging 14", clothe_Id = 4, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Jegging 15", clothe_Id = 4, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans Jegging 16", clothe_Id = 4, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Jeans offen vorne", clothe_Id = 43, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Jeans offen vorne", clothe_Id = 43, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Jeans offen vorne", clothe_Id = 43, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Jeans offen vorne", clothe_Id = 43, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Jeans offen vorne", clothe_Id = 43, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Jeans offen seite", clothe_Id = 44, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Jeans offen seite", clothe_Id = 44, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Jeans offen seite", clothe_Id = 44, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Jeans offen seite", clothe_Id = 44, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Jeans offen seite", clothe_Id = 44, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Jeans", clothe_Name = "Calça Jeans", clothe_Id = 42, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Cargo 1", clothe_Id = 33, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Cargo 2", clothe_Id = 45, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Cargo 3", clothe_Id = 45, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Cargo 4", clothe_Id = 45, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Cargo 5", clothe_Id = 45, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Cargo 6", clothe_Id = 48, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Cargo 7", clothe_Id = 48, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Cargo 8", clothe_Id = 49, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Cargo 9", clothe_Id = 49, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 1", clothe_Id = 11, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 2", clothe_Id = 11, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 3", clothe_Id = 11, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 4", clothe_Id = 11, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 5", clothe_Id = 11, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 6", clothe_Id = 11, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 7", clothe_Id = 11, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 8", clothe_Id = 11, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 9", clothe_Id = 11, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 10", clothe_Id = 11, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 11", clothe_Id = 11, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 12", clothe_Id = 11, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 13", clothe_Id = 11, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 14", clothe_Id = 11, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 15", clothe_Id = 11, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 16", clothe_Id = 11, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 1", clothe_Id = 30, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 2", clothe_Id = 30, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 3", clothe_Id = 30, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 4", clothe_Id = 30, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Cargo", clothe_Name = "Calça Jegging Cargo 5", clothe_Id = 30, clothe_Texture = 4 });

        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano Jegging 1", clothe_Id = 2, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano Jegging 2", clothe_Id = 2, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano Jegging 3", clothe_Id = 2, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 1", clothe_Id = 3, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 2", clothe_Id = 3, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 3", clothe_Id = 3, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 4", clothe_Id = 3, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 5", clothe_Id = 3, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 6", clothe_Id = 3, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 7", clothe_Id = 3, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 8", clothe_Id = 3, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 9", clothe_Id = 3, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 10", clothe_Id = 3, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 11", clothe_Id = 3, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 12", clothe_Id = 3, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 13", clothe_Id = 3, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 14", clothe_Id = 3, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 15", clothe_Id = 3, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 16", clothe_Id = 3, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 17", clothe_Id = 58, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 18", clothe_Id = 58, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 19", clothe_Id = 58, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 20", clothe_Id = 58, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 21", clothe_Id = 66, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 22", clothe_Id = 66, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 23", clothe_Id = 66, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 24", clothe_Id = 66, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 25", clothe_Id = 66, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 26", clothe_Id = 66, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 27", clothe_Id = 66, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 28", clothe_Id = 66, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 29", clothe_Id = 66, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 30", clothe_Id = 66, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 31", clothe_Id = 66, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 16 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Pano 32", clothe_Id = 71, clothe_Texture = 17 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Saruel 1", clothe_Id = 80, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Saruel 2", clothe_Id = 80, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Saruel 3", clothe_Id = 80, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Saruel 4", clothe_Id = 80, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Saruel 5", clothe_Id = 80, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Saruel 6", clothe_Id = 80, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Saruel 7", clothe_Id = 80, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Saruel 8", clothe_Id = 80, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Saruel 9", clothe_Id = 81, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Saruel 10", clothe_Id = 81, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça de Pano", clothe_Name = "Calça de Saruel 11", clothe_Id = 81, clothe_Texture = 2 });


        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Saruel 0", clothe_Id = 82, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Saruel 1", clothe_Id = 82, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Saruel 2", clothe_Id = 82, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Saruel 3", clothe_Id = 82, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Saruel 4", clothe_Id = 82, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Saruel 5", clothe_Id = 82, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Saruel 6", clothe_Id = 82, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Saruel 7", clothe_Id = 82, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 1", clothe_Id = 10, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 2", clothe_Id = 10, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 3", clothe_Id = 10, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 4", clothe_Id = 14, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 5", clothe_Id = 14, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 6", clothe_Id = 16, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 7", clothe_Id = 16, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 8", clothe_Id = 16, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 9", clothe_Id = 16, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 10", clothe_Id = 16, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 11", clothe_Id = 16, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 12", clothe_Id = 16, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 13", clothe_Id = 16, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 14", clothe_Id = 16, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 15", clothe_Id = 16, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 16", clothe_Id = 16, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Curto 17", clothe_Id = 16, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Jeans 1", clothe_Id = 25, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Jeans 2", clothe_Id = 25, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Jeans 3", clothe_Id = 25, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Jeans 4", clothe_Id = 25, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Jeans 5", clothe_Id = 25, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Jeans 6", clothe_Id = 25, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Jeans 7", clothe_Id = 25, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Jeans 8", clothe_Id = 25, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Jeans 9", clothe_Id = 25, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Jeans 10", clothe_Id = 25, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Jeans 11", clothe_Id = 25, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Jeans 12", clothe_Id = 25, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Short", clothe_Name = "Short Jeans 13", clothe_Id = 25, clothe_Texture = 12 });

        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 1", clothe_Id = 6, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 2", clothe_Id = 6, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 3", clothe_Id = 6, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 4", clothe_Id = 23, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 5", clothe_Id = 23, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 6", clothe_Id = 23, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 7", clothe_Id = 23, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 8", clothe_Id = 23, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 9", clothe_Id = 23, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 10", clothe_Id = 23, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 11", clothe_Id = 23, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 12", clothe_Id = 23, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 13", clothe_Id = 23, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 14", clothe_Id = 23, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 15", clothe_Id = 23, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 16", clothe_Id = 23, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 17", clothe_Id = 37, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 18", clothe_Id = 37, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 19", clothe_Id = 37, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 20", clothe_Id = 37, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 21", clothe_Id = 37, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 22", clothe_Id = 37, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 23", clothe_Id = 37, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 24", clothe_Id = 41, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 25", clothe_Id = 41, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 26", clothe_Id = 41, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 27", clothe_Id = 47, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 28", clothe_Id = 47, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 29", clothe_Id = 47, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 30", clothe_Id = 47, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 31", clothe_Id = 47, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 32", clothe_Id = 47, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 33", clothe_Id = 47, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 34", clothe_Id = 50, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 35", clothe_Id = 50, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 36", clothe_Id = 50, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 37", clothe_Id = 50, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 38", clothe_Id = 50, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 39", clothe_Id = 51, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 40", clothe_Id = 51, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 41", clothe_Id = 51, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 42", clothe_Id = 51, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 43", clothe_Id = 51, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 44", clothe_Id = 52, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 45", clothe_Id = 52, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 46", clothe_Id = 52, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 47", clothe_Id = 52, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 48", clothe_Id = 53, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 49", clothe_Id = 54, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 50", clothe_Id = 54, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 51", clothe_Id = 54, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 52", clothe_Id = 54, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 53", clothe_Id = 64, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 54", clothe_Id = 64, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 55", clothe_Id = 64, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 56", clothe_Id = 64, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 57", clothe_Id = 67, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 58", clothe_Id = 67, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 59", clothe_Id = 67, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 60", clothe_Id = 67, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 61", clothe_Id = 67, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 62", clothe_Id = 67, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 63", clothe_Id = 67, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 64", clothe_Id = 67, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 65", clothe_Id = 67, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 66", clothe_Id = 67, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 67", clothe_Id = 67, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 68", clothe_Id = 67, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 69", clothe_Id = 67, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 70", clothe_Id = 67, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 71", clothe_Id = 87, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 72", clothe_Id = 87, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 73", clothe_Id = 87, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 74", clothe_Id = 87, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 75", clothe_Id = 87, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 76", clothe_Id = 87, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 77", clothe_Id = 87, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 78", clothe_Id = 87, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 79", clothe_Id = 87, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 80", clothe_Id = 87, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 81", clothe_Id = 87, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 82", clothe_Id = 87, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 83", clothe_Id = 87, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 84", clothe_Id = 87, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 85", clothe_Id = 87, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 86", clothe_Id = 87, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 87", clothe_Id = 27, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 88", clothe_Id = 27, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 89", clothe_Id = 27, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 90", clothe_Id = 27, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 91", clothe_Id = 27, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 92", clothe_Id = 27, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 93", clothe_Id = 27, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 94", clothe_Id = 27, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 95", clothe_Id = 27, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 96", clothe_Id = 27, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 97", clothe_Id = 27, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 98", clothe_Id = 27, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 99", clothe_Id = 27, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 100", clothe_Id = 27, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 101", clothe_Id = 27, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calça Social", clothe_Name = "Calça Social 102", clothe_Id = 27, clothe_Texture = 15 });




        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 1", clothe_Id = 7, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 2", clothe_Id = 7, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 3", clothe_Id = 7, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 4", clothe_Id = 18, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 5", clothe_Id = 18, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 1", clothe_Id = 24, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 2", clothe_Id = 24, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 3", clothe_Id = 24, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 4", clothe_Id = 24, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 5", clothe_Id = 24, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 6", clothe_Id = 24, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 7", clothe_Id = 24, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 8", clothe_Id = 24, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 9", clothe_Id = 24, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 10", clothe_Id = 24, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 11", clothe_Id = 24, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 12", clothe_Id = 24, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 13", clothe_Id = 24, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 14", clothe_Id = 36, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 15", clothe_Id = 36, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Longa 16", clothe_Id = 36, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 1", clothe_Id = 8, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 2", clothe_Id = 8, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 3", clothe_Id = 8, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 4", clothe_Id = 8, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 5", clothe_Id = 8, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 6", clothe_Id = 8, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 7", clothe_Id = 8, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 8", clothe_Id = 8, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 9", clothe_Id = 8, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 10", clothe_Id = 8, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 11", clothe_Id = 8, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 12", clothe_Id = 8, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 13", clothe_Id = 8, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 14", clothe_Id = 8, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 15", clothe_Id = 8, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 16", clothe_Id = 26, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta 17", clothe_Id = 28, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta C/ Pedraria 1", clothe_Id = 9, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta C/ Pedraria 2", clothe_Id = 9, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta C/ Pedraria 3", clothe_Id = 9, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta C/ Pedraria 4", clothe_Id = 9, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta C/ Pedraria 5", clothe_Id = 9, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta C/ Pedraria 6", clothe_Id = 9, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta C/ Pedraria 7", clothe_Id = 9, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta C/ Pedraria 8", clothe_Id = 9, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta C/ Pedraria 9", clothe_Id = 9, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta C/ Pedraria 10", clothe_Id = 9, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta C/ Pedraria 11", clothe_Id = 9, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta C/ Pedraria 12", clothe_Id = 9, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta C/ Pedraria 13", clothe_Id = 9, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta C/ Pedraria 14", clothe_Id = 9, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta C/ Pedraria 15", clothe_Id = 9, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta C/ Pedraria 16", clothe_Id = 9, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta Escolar 1", clothe_Id = 12, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta Escolar 2", clothe_Id = 12, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta Escolar 3", clothe_Id = 12, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta Escolar 4", clothe_Id = 12, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta Escolar 5", clothe_Id = 12, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta Escolar 6", clothe_Id = 12, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta Escolar 7", clothe_Id = 12, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta Escolar 8", clothe_Id = 12, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta Escolar 9", clothe_Id = 12, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta Escolar 10", clothe_Id = 12, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta Escolar 11", clothe_Id = 12, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta Escolar 12", clothe_Id = 12, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta Escolar 13", clothe_Id = 12, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta Escolar 14", clothe_Id = 12, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Saia", clothe_Name = "Saia Curta Escolar 15", clothe_Id = 12, clothe_Texture = 14 });



        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Biquíni 1", clothe_Id = 15, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Biquíni 2", clothe_Id = 17, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Biquíni 3", clothe_Id = 17, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Biquíni 4", clothe_Id = 17, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Biquíni 5", clothe_Id = 17, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Biquíni 6", clothe_Id = 17, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Biquíni 7", clothe_Id = 17, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Biquíni 8", clothe_Id = 17, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Biquíni 9", clothe_Id = 17, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Biquíni 10", clothe_Id = 17, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Biquíni 11", clothe_Id = 17, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Biquíni 12", clothe_Id = 17, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Biquíni 13", clothe_Id = 17, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 1", clothe_Id = 56, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 2", clothe_Id = 56, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 3", clothe_Id = 56, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 4", clothe_Id = 56, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 5", clothe_Id = 56, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 6", clothe_Id = 56, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 7", clothe_Id = 62, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 8", clothe_Id = 62, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 9", clothe_Id = 62, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 10", clothe_Id = 62, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 11", clothe_Id = 62, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 12", clothe_Id = 62, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 13", clothe_Id = 62, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 14", clothe_Id = 62, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 15", clothe_Id = 62, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 16", clothe_Id = 62, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 17", clothe_Id = 62, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Calcinha", clothe_Name = "Calcinha 18", clothe_Id = 62, clothe_Texture = 11 });


        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 1", clothe_Id = 0, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 2", clothe_Id = 0, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 3", clothe_Id = 0, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 4", clothe_Id = 0, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 5", clothe_Id = 6, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 6", clothe_Id = 6, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 7", clothe_Id = 6, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 8", clothe_Id = 6, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 9", clothe_Id = 8, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 10", clothe_Id = 8, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 11", clothe_Id = 8, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 12", clothe_Id = 8, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 13", clothe_Id = 8, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 14", clothe_Id = 8, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 15", clothe_Id = 8, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 16", clothe_Id = 8, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 17", clothe_Id = 8, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 18", clothe_Id = 8, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 19", clothe_Id = 8, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 20", clothe_Id = 8, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 21", clothe_Id = 8, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 22", clothe_Id = 8, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 23", clothe_Id = 8, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 24", clothe_Id = 8, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 25", clothe_Id = 14, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 26", clothe_Id = 14, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 27", clothe_Id = 14, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 28", clothe_Id = 14, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 29", clothe_Id = 14, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 30", clothe_Id = 14, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 31", clothe_Id = 14, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 32", clothe_Id = 14, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 33", clothe_Id = 14, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 34", clothe_Id = 14, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 35", clothe_Id = 14, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 36", clothe_Id = 14, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 37", clothe_Id = 14, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 38", clothe_Id = 14, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 39", clothe_Id = 14, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 40", clothe_Id = 14, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 41", clothe_Id = 18, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 42", clothe_Id = 18, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 43", clothe_Id = 18, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 44", clothe_Id = 19, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 45", clothe_Id = 19, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 46", clothe_Id = 19, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 47", clothe_Id = 19, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 48", clothe_Id = 19, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 49", clothe_Id = 19, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 50", clothe_Id = 19, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 51", clothe_Id = 19, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 52", clothe_Id = 19, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 53", clothe_Id = 19, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 54", clothe_Id = 19, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 55", clothe_Id = 19, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 56", clothe_Id = 20, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 57", clothe_Id = 20, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 58", clothe_Id = 20, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 59", clothe_Id = 20, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 60", clothe_Id = 20, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 61", clothe_Id = 20, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 62", clothe_Id = 20, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 63", clothe_Id = 20, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 64", clothe_Id = 20, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 65", clothe_Id = 20, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 66", clothe_Id = 20, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 67", clothe_Id = 20, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 68", clothe_Id = 23, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 69", clothe_Id = 23, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 70", clothe_Id = 23, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 71", clothe_Id = 41, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 72", clothe_Id = 41, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 73", clothe_Id = 41, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 74", clothe_Id = 41, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 75", clothe_Id = 41, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 76", clothe_Id = 41, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 77", clothe_Id = 41, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 78", clothe_Id = 41, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 79", clothe_Id = 41, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 80", clothe_Id = 41, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 81", clothe_Id = 41, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 82", clothe_Id = 41, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 83", clothe_Id = 42, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 84", clothe_Id = 42, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 85", clothe_Id = 42, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 86", clothe_Id = 42, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 87", clothe_Id = 42, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 88", clothe_Id = 42, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 89", clothe_Id = 42, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 90", clothe_Id = 42, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 91", clothe_Id = 42, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 92", clothe_Id = 42, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 93", clothe_Id = 42, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 94", clothe_Id = 42, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 95", clothe_Id = 43, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 96", clothe_Id = 43, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 97", clothe_Id = 43, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 98", clothe_Id = 43, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 99", clothe_Id = 43, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 100", clothe_Id = 43, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 101", clothe_Id = 43, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 102", clothe_Id = 43, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 103", clothe_Id = 44, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 104", clothe_Id = 44, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 105", clothe_Id = 44, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 106", clothe_Id = 44, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 107", clothe_Id = 44, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 108", clothe_Id = 44, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 109", clothe_Id = 44, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Salto", clothe_Name = "Salto Alto 110", clothe_Id = 44, clothe_Texture = 7 });

        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 1", clothe_Id = 1, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 2", clothe_Id = 1, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 3", clothe_Id = 1, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 4", clothe_Id = 1, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 5", clothe_Id = 1, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 6", clothe_Id = 1, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 7", clothe_Id = 1, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 8", clothe_Id = 1, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 9", clothe_Id = 1, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 10", clothe_Id = 1, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 11", clothe_Id = 1, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 12", clothe_Id = 1, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 13", clothe_Id = 1, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 14", clothe_Id = 1, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 15", clothe_Id = 1, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 16", clothe_Id = 1, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 17", clothe_Id = 3, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 18", clothe_Id = 3, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 19", clothe_Id = 3, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 20", clothe_Id = 3, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 21", clothe_Id = 3, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 22", clothe_Id = 3, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 23", clothe_Id = 3, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 24", clothe_Id = 3, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 25", clothe_Id = 3, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 26", clothe_Id = 3, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 27", clothe_Id = 3, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 28", clothe_Id = 3, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 29", clothe_Id = 3, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 30", clothe_Id = 3, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 31", clothe_Id = 3, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 32", clothe_Id = 3, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 33", clothe_Id = 4, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 34", clothe_Id = 4, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 35", clothe_Id = 4, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 36", clothe_Id = 4, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 37", clothe_Id = 10, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 38", clothe_Id = 10, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 39", clothe_Id = 10, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 40", clothe_Id = 10, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 41", clothe_Id = 11, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 42", clothe_Id = 11, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 43", clothe_Id = 11, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 44", clothe_Id = 11, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 45", clothe_Id = 27, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 46", clothe_Id = 28, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 47", clothe_Id = 31, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 48", clothe_Id = 32, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 49", clothe_Id = 32, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 50", clothe_Id = 32, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 51", clothe_Id = 32, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 52", clothe_Id = 32, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 53", clothe_Id = 33, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 54", clothe_Id = 33, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 55", clothe_Id = 33, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 56", clothe_Id = 33, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 57", clothe_Id = 33, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 58", clothe_Id = 33, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 59", clothe_Id = 33, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 60", clothe_Id = 33, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 61", clothe_Id = 47, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 62", clothe_Id = 47, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 63", clothe_Id = 47, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 64", clothe_Id = 47, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 65", clothe_Id = 47, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 66", clothe_Id = 47, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 67", clothe_Id = 47, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 68", clothe_Id = 47, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 69", clothe_Id = 47, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 70", clothe_Id = 47, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 71", clothe_Id = 49, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 72", clothe_Id = 49, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 73", clothe_Id = 50, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 74", clothe_Id = 50, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 75", clothe_Id = 52, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 76", clothe_Id = 52, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 77", clothe_Id = 52, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 78", clothe_Id = 52, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 79", clothe_Id = 52, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 80", clothe_Id = 52, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 81", clothe_Id = 55, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 82", clothe_Id = 55, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 83", clothe_Id = 55, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 84", clothe_Id = 55, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 85", clothe_Id = 55, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 86", clothe_Id = 55, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 87", clothe_Id = 57, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 88", clothe_Id = 57, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 89", clothe_Id = 57, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 90", clothe_Id = 59, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 91", clothe_Id = 59, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 92", clothe_Id = 60, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 93", clothe_Id = 60, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 94", clothe_Id = 60, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 95", clothe_Id = 60, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 96", clothe_Id = 60, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 97", clothe_Id = 60, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 98", clothe_Id = 60, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 99", clothe_Id = 60, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 100", clothe_Id = 60, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 101", clothe_Id = 60, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 102", clothe_Id = 60, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 103", clothe_Id = 60, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 104", clothe_Id = 29, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 105", clothe_Id = 29, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 106", clothe_Id = 29, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 107", clothe_Id = 37, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 108", clothe_Id = 37, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 109", clothe_Id = 37, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 110", clothe_Id = 37, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 111", clothe_Id = 39, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 112", clothe_Id = 39, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 113", clothe_Id = 39, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 114", clothe_Id = 39, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Tenis", clothe_Name = "Tenis 115", clothe_Id = 39, clothe_Texture = 4 });

        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 1", clothe_Id = 2, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 2", clothe_Id = 2, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 3", clothe_Id = 2, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 4", clothe_Id = 2, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 5", clothe_Id = 2, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 6", clothe_Id = 2, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 7", clothe_Id = 2, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 8", clothe_Id = 2, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 9", clothe_Id = 2, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 10", clothe_Id = 2, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 11", clothe_Id = 2, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 12", clothe_Id = 2, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 13", clothe_Id = 2, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 14", clothe_Id = 2, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 15", clothe_Id = 2, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 16", clothe_Id = 2, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 17", clothe_Id = 9, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 18", clothe_Id = 9, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 19", clothe_Id = 9, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 20", clothe_Id = 9, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 21", clothe_Id = 21, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 22", clothe_Id = 21, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 23", clothe_Id = 21, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 24", clothe_Id = 21, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 25", clothe_Id = 21, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 26", clothe_Id = 21, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 27", clothe_Id = 21, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 28", clothe_Id = 21, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 29", clothe_Id = 21, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 30", clothe_Id = 21, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 31", clothe_Id = 24, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 32", clothe_Id = 25, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 33", clothe_Id = 26, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 34", clothe_Id = 36, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 35", clothe_Id = 36, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 36", clothe_Id = 38, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 37", clothe_Id = 38, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 38", clothe_Id = 38, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 39", clothe_Id = 38, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 40", clothe_Id = 38, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 41", clothe_Id = 51, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 42", clothe_Id = 51, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 43", clothe_Id = 51, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 44", clothe_Id = 51, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 45", clothe_Id = 51, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 46", clothe_Id = 51, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 47", clothe_Id = 53, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 48", clothe_Id = 53, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 49", clothe_Id = 54, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 50", clothe_Id = 54, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 51", clothe_Id = 54, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 52", clothe_Id = 54, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 53", clothe_Id = 54, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 54", clothe_Id = 54, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 55", clothe_Id = 56, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 56", clothe_Id = 56, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Bota", clothe_Name = "Botas 57", clothe_Id = 56, clothe_Texture = 2 });

        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Chinelo 1", clothe_Id = 5, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Chinelo 2", clothe_Id = 5, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Chinelo 3", clothe_Id = 16, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Chinelo 4", clothe_Id = 16, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Chinelo 5", clothe_Id = 16, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Chinelo 6", clothe_Id = 16, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Chinelo 7", clothe_Id = 16, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Chinelo 8", clothe_Id = 16, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Chinelo 9", clothe_Id = 16, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Chinelo 10", clothe_Id = 16, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Chinelo 11", clothe_Id = 16, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Chinelo 12", clothe_Id = 16, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Chinelo 13", clothe_Id = 16, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Chinelo 14", clothe_Id = 16, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Sandalha 15", clothe_Id = 15, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Sandalha 16", clothe_Id = 15, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Sandalha 17", clothe_Id = 15, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Sandalha 18", clothe_Id = 15, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Sandalha 19", clothe_Id = 15, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Sandalha 20", clothe_Id = 15, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Sandalha 21", clothe_Id = 15, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Sandalha 22", clothe_Id = 15, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Sandalha 23", clothe_Id = 15, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Sandalha 24", clothe_Id = 15, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Sandalha 25", clothe_Id = 15, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Sandalha 26", clothe_Id = 15, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Sandalha 27", clothe_Id = 15, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Sandalha 28", clothe_Id = 15, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Sandalha 29", clothe_Id = 15, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "Sandalha 30", clothe_Id = 15, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Sandalha", clothe_Name = "barfuß", clothe_Id = 35, clothe_Texture = 0 });


        // new neck


        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 0, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 1, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 2, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 3, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 4, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 5, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 6, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 7, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 8, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 9, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 10, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 11, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 12, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 13, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 14, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 15, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 16, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 17, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 18, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 19, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 20, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 21, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 22, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 23, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 28, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 30, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 31, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 32, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 33, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 34, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 35, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 36, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 37, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 38, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 40, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 41, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 42, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 53, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 54, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 55, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 56, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 57, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 58, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 59, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 60, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 61, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 62, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 64, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 65, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 66, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 67, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 68, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 69, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 70, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 71, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 72, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 81, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 82, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 83, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 84, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 85, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 86, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 87, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 88, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 89, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 90, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 91, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 92, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 93, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 1, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 94, clothe_Texture = 0 });

        //
        #endregion Female_Clothes

        //
        //
        //
        //
        //
        //
        //
        //
        //

        #region Male_Clothes
        // START NEW NECK
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 0, clothe_Texture = 0 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 10, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 10, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 10, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 10, clothe_Texture = 3 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 11, clothe_Texture = 0 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 12, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 12, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 12, clothe_Texture = 2 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 16, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 16, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 16, clothe_Texture = 2 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 17, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 17, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 17, clothe_Texture = 2 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 18, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 19, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 20, clothe_Texture = 0 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 21, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 21, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 21, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 21, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 21, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 21, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 21, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 21, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 21, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 21, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 21, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 21, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 21, clothe_Texture = 12 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 22, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 22, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 22, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 22, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 22, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 22, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 22, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 22, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 22, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 22, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 22, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 22, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 22, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 22, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 22, clothe_Texture = 14 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 23, clothe_Texture = 0 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 24, clothe_Texture = 15 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 25, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 25, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 25, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 25, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 25, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 25, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 25, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 25, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 25, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 25, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 25, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 25, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 25, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 25, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 25, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 25, clothe_Texture = 15 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 26, clothe_Texture = 15 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 27, clothe_Texture = 15 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 28, clothe_Texture = 0 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 29, clothe_Texture = 15 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 30, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 30, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 30, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 30, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 30, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 30, clothe_Texture = 5 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 31, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 31, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 31, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 31, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 31, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 31, clothe_Texture = 5 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 32, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 32, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 32, clothe_Texture = 2 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 33, clothe_Texture = 0 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 34, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 34, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 34, clothe_Texture = 2 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 35, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 35, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 35, clothe_Texture = 2 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 36, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 37, clothe_Texture = 0 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 38, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 38, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 38, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 38, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 38, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 38, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 38, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 38, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 38, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 38, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 38, clothe_Texture = 10 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 15 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 39, clothe_Texture = 0 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 42, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 42, clothe_Texture = 1 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 43, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 43, clothe_Texture = 1 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 44, clothe_Texture = 0 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 45, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 45, clothe_Texture = 1 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 46, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 46, clothe_Texture = 1 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 47, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 47, clothe_Texture = 1 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 48, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 48, clothe_Texture = 1 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 49, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 49, clothe_Texture = 1 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 50, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 50, clothe_Texture = 1 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 51, clothe_Texture = 0 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 52, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 53, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 54, clothe_Texture = 0 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 55, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 74, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 75, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 76, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 77, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 78, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 79, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 80, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 81, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 82, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 82, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 83, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 85, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 86, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 87, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 88, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 89, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 90, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 91, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 92, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 93, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 94, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 110, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 111, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 112, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 113, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 114, clothe_Texture = 0 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 115, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 115, clothe_Texture = 1 });


        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 116, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 116, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 116, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 116, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 116, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 116, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 116, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 116, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 116, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 116, clothe_Texture = 9 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 117, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 117, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 117, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 117, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 117, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 117, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 117, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 117, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 117, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 117, clothe_Texture = 9 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 119, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 120, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 121, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 122, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 123, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Neck", clothe_Name = "Neck", clothe_Id = 124, clothe_Texture = 0 });
        // END NEW NECK


        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 1", clothe_Id = 0, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 2", clothe_Id = 0, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 3", clothe_Id = 0, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 4", clothe_Id = 0, clothe_Texture = 3, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 5", clothe_Id = 0, clothe_Texture = 4, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 6", clothe_Id = 0, clothe_Texture = 5, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 7", clothe_Id = 0, clothe_Texture = 7, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 8", clothe_Id = 0, clothe_Texture = 8, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 9", clothe_Id = 0, clothe_Texture = 11, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 10", clothe_Id = 1, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 11", clothe_Id = 1, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 12", clothe_Id = 1, clothe_Texture = 3, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 13", clothe_Id = 1, clothe_Texture = 4, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 14", clothe_Id = 1, clothe_Texture = 5, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 15", clothe_Id = 1, clothe_Texture = 6, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 16", clothe_Id = 1, clothe_Texture = 7, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 17", clothe_Id = 1, clothe_Texture = 8, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 18", clothe_Id = 1, clothe_Texture = 11, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 19", clothe_Id = 1, clothe_Texture = 12, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 20", clothe_Id = 1, clothe_Texture = 14, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 21", clothe_Id = 16, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 22", clothe_Id = 16, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 23", clothe_Id = 16, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 24", clothe_Id = 22, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 25", clothe_Id = 22, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 26", clothe_Id = 22, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 27", clothe_Id = 33, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 28", clothe_Id = 34, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 29", clothe_Id = 34, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 30", clothe_Id = 44, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 31", clothe_Id = 44, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 32", clothe_Id = 44, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 33", clothe_Id = 44, clothe_Texture = 3, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 36", clothe_Id = 56, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 37", clothe_Id = 71, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 38", clothe_Id = 73, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 39", clothe_Id = 73, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 40", clothe_Id = 73, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 41", clothe_Id = 73, clothe_Texture = 3, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 42", clothe_Id = 73, clothe_Texture = 4, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 43", clothe_Id = 73, clothe_Texture = 5, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 44", clothe_Id = 73, clothe_Texture = 6, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 45", clothe_Id = 73, clothe_Texture = 7, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 46", clothe_Id = 73, clothe_Texture = 8, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 47", clothe_Id = 73, clothe_Texture = 9, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 48", clothe_Id = 73, clothe_Texture = 10, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 49", clothe_Id = 73, clothe_Texture = 11, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 50", clothe_Id = 73, clothe_Texture = 12, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 51", clothe_Id = 73, clothe_Texture = 13, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 52", clothe_Id = 73, clothe_Texture = 14, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 53", clothe_Id = 73, clothe_Texture = 15, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 54", clothe_Id = 73, clothe_Texture = 16, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 55", clothe_Id = 73, clothe_Texture = 17, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 56", clothe_Id = 73, clothe_Texture = 18, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 57", clothe_Id = 80, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 58", clothe_Id = 80, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 59", clothe_Id = 80, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 60", clothe_Id = 81, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 61", clothe_Id = 81, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 62", clothe_Id = 81, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 63", clothe_Id = 83, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 64", clothe_Id = 83, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 65", clothe_Id = 83, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 66", clothe_Id = 83, clothe_Texture = 3, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 67", clothe_Id = 83, clothe_Texture = 4, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 68", clothe_Id = 97, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 69", clothe_Id = 97, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 70", clothe_Id = 128, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 71", clothe_Id = 128, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 72", clothe_Id = 128, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 73", clothe_Id = 128, clothe_Texture = 3, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 74", clothe_Id = 128, clothe_Texture = 4, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 75", clothe_Id = 128, clothe_Texture = 5, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 76", clothe_Id = 128, clothe_Texture = 6, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 77", clothe_Id = 128, clothe_Texture = 7, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 78", clothe_Id = 128, clothe_Texture = 8, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 79", clothe_Id = 128, clothe_Texture = 9, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 80", clothe_Id = 146, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 81", clothe_Id = 146, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 82", clothe_Id = 146, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 83", clothe_Id = 146, clothe_Texture = 3, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 84", clothe_Id = 146, clothe_Texture = 4, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 85", clothe_Id = 146, clothe_Texture = 5, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 86", clothe_Id = 146, clothe_Texture = 6, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 87", clothe_Id = 146, clothe_Texture = 7, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 88", clothe_Id = 146, clothe_Texture = 8, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 89", clothe_Id = 164, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 90", clothe_Id = 164, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 91", clothe_Id = 164, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 92", clothe_Id = 193, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 93", clothe_Id = 193, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 94", clothe_Id = 193, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 95", clothe_Id = 193, clothe_Texture = 3, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 96", clothe_Id = 193, clothe_Texture = 4, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 97", clothe_Id = 193, clothe_Texture = 5, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 98", clothe_Id = 193, clothe_Texture = 6, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 99", clothe_Id = 193, clothe_Texture = 7, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 100", clothe_Id = 193, clothe_Texture = 8, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 101", clothe_Id = 193, clothe_Texture = 9, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 102", clothe_Id = 193, clothe_Texture = 10, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 103", clothe_Id = 193, clothe_Texture = 11, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 104", clothe_Id = 193, clothe_Texture = 12, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 105", clothe_Id = 193, clothe_Texture = 13, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 106", clothe_Id = 193, clothe_Texture = 14, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 107", clothe_Id = 193, clothe_Texture = 15, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 108", clothe_Id = 193, clothe_Texture = 16, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 109", clothe_Id = 193, clothe_Texture = 17, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 110", clothe_Id = 193, clothe_Texture = 18, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 111", clothe_Id = 193, clothe_Texture = 19, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 112", clothe_Id = 193, clothe_Texture = 20, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 113", clothe_Id = 193, clothe_Texture = 21, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 114", clothe_Id = 193, clothe_Texture = 22, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 115", clothe_Id = 193, clothe_Texture = 23, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 116", clothe_Id = 193, clothe_Texture = 24, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Masculina", clothe_Name = "Camisa Masculina 117", clothe_Id = 193, clothe_Texture = 25, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 1", clothe_Id = 2, clothe_Texture = 9, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 2", clothe_Id = 5, clothe_Texture = 0, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 3", clothe_Id = 5, clothe_Texture = 1, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 4", clothe_Id = 5, clothe_Texture = 2, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 5", clothe_Id = 5, clothe_Texture = 7, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 6", clothe_Id = 17, clothe_Texture = 0, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 7", clothe_Id = 17, clothe_Texture = 1, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 8", clothe_Id = 17, clothe_Texture = 2, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 9", clothe_Id = 17, clothe_Texture = 3, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 10", clothe_Id = 17, clothe_Texture = 4, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 11", clothe_Id = 17, clothe_Texture = 5, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 12", clothe_Id = 36, clothe_Texture = 0, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 13", clothe_Id = 36, clothe_Texture = 1, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 14", clothe_Id = 36, clothe_Texture = 2, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 15", clothe_Id = 36, clothe_Texture = 3, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 16", clothe_Id = 36, clothe_Texture = 4, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 17", clothe_Id = 36, clothe_Texture = 5, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 18", clothe_Id = 109, clothe_Texture = 0, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 19", clothe_Id = 137, clothe_Texture = 0, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 20", clothe_Id = 137, clothe_Texture = 1, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 21", clothe_Id = 137, clothe_Texture = 2, clothe_Torso = 5, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisetas Masculina", clothe_Name = "Camiseta Masculina 22", clothe_Id = 15, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 6, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 6, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 6, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 6, clothe_Texture = 4, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 6, clothe_Texture = 5, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 6, clothe_Texture = 6, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 6, clothe_Texture = 8, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 6, clothe_Texture = 9, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 6, clothe_Texture = 11, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 37, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 37, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 37, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 64, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 68, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 68, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 68, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 68, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 1", clothe_Id = 68, clothe_Texture = 4, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 2", clothe_Id = 68, clothe_Texture = 5, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3", clothe_Id = 69, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 4", clothe_Id = 69, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 5", clothe_Id = 69, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 6", clothe_Id = 69, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 7", clothe_Id = 69, clothe_Texture = 4, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 8", clothe_Id = 69, clothe_Texture = 5, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 9", clothe_Id = 75, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 10", clothe_Id = 75, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 11", clothe_Id = 75, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 12", clothe_Id = 75, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 13", clothe_Id = 75, clothe_Texture = 4, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 14", clothe_Id = 75, clothe_Texture = 5, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 15", clothe_Id = 75, clothe_Texture = 6, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 16", clothe_Id = 75, clothe_Texture = 7, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 17", clothe_Id = 75, clothe_Texture = 8, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 18", clothe_Id = 75, clothe_Texture = 9, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 19", clothe_Id = 75, clothe_Texture = 10, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 20", clothe_Id = 90, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 21", clothe_Id = 76, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 22", clothe_Id = 76, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 23", clothe_Id = 76, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 24", clothe_Id = 76, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 25", clothe_Id = 76, clothe_Texture = 4, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 26", clothe_Id = 119, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 27", clothe_Id = 119, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 28", clothe_Id = 119, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 29", clothe_Id = 119, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 30", clothe_Id = 119, clothe_Texture = 4, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 31", clothe_Id = 119, clothe_Texture = 5, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 32", clothe_Id = 119, clothe_Texture = 6, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 33", clothe_Id = 119, clothe_Texture = 7, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 34", clothe_Id = 119, clothe_Texture = 8, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 35", clothe_Id = 119, clothe_Texture = 9, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 36", clothe_Id = 119, clothe_Texture = 10, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 37", clothe_Id = 119, clothe_Texture = 11, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 38", clothe_Id = 121, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 39", clothe_Id = 121, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 40", clothe_Id = 121, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 41", clothe_Id = 121, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 42", clothe_Id = 121, clothe_Texture = 4, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 43", clothe_Id = 121, clothe_Texture = 5, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 44", clothe_Id = 121, clothe_Texture = 6, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 45", clothe_Id = 121, clothe_Texture = 7, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 46", clothe_Id = 121, clothe_Texture = 8, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 47", clothe_Id = 121, clothe_Texture = 9, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 48", clothe_Id = 121, clothe_Texture = 10, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 49", clothe_Id = 121, clothe_Texture = 11, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 50", clothe_Id = 124, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 51", clothe_Id = 154, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 52", clothe_Id = 154, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 53", clothe_Id = 154, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 54", clothe_Id = 154, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 55", clothe_Id = 154, clothe_Texture = 4, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 56", clothe_Id = 154, clothe_Texture = 5, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 57", clothe_Id = 154, clothe_Texture = 6, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 58", clothe_Id = 154, clothe_Texture = 7, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 59", clothe_Id = 161, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 60", clothe_Id = 161, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 61", clothe_Id = 161, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 62", clothe_Id = 161, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 63", clothe_Id = 168, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 64", clothe_Id = 168, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 65", clothe_Id = 168, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 66", clothe_Id = 174, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 67", clothe_Id = 174, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 68", clothe_Id = 174, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 69", clothe_Id = 174, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 70", clothe_Id = 184, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 71", clothe_Id = 184, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 72", clothe_Id = 184, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 73", clothe_Id = 184, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 74", clothe_Id = 187, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 75", clothe_Id = 187, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 76", clothe_Id = 187, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 77", clothe_Id = 187, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 78", clothe_Id = 187, clothe_Texture = 4, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 79", clothe_Id = 187, clothe_Texture = 5, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 80", clothe_Id = 187, clothe_Texture = 6, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 81", clothe_Id = 187, clothe_Texture = 7, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 82", clothe_Id = 187, clothe_Texture = 8, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 83", clothe_Id = 187, clothe_Texture = 9, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 84", clothe_Id = 187, clothe_Texture = 10, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 85", clothe_Id = 187, clothe_Texture = 11, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 86", clothe_Id = 187, clothe_Texture = 12, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 87", clothe_Id = 188, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 88", clothe_Id = 188, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 89", clothe_Id = 188, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 90", clothe_Id = 188, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 91", clothe_Id = 188, clothe_Texture = 4, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 92", clothe_Id = 188, clothe_Texture = 5, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 93", clothe_Id = 188, clothe_Texture = 6, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 94", clothe_Id = 188, clothe_Texture = 7, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 95", clothe_Id = 188, clothe_Texture = 8, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 96", clothe_Id = 188, clothe_Texture = 9, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 97", clothe_Id = 188, clothe_Texture = 10, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 98", clothe_Id = 204, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 99", clothe_Id = 204, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 100", clothe_Id = 204, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 101", clothe_Id = 204, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 102", clothe_Id = 204, clothe_Texture = 4, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 103", clothe_Id = 204, clothe_Texture = 5, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 104", clothe_Id = 204, clothe_Texture = 6, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 105", clothe_Id = 204, clothe_Texture = 7, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 106", clothe_Id = 204, clothe_Texture = 8, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 107", clothe_Id = 204, clothe_Texture = 9, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 108", clothe_Id = 204, clothe_Texture = 10, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 109", clothe_Id = 204, clothe_Texture = 11, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 110", clothe_Id = 204, clothe_Texture = 12, clothe_Torso = 14, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 111", clothe_Id = 57, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 112", clothe_Id = 75, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 113", clothe_Id = 75, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 114", clothe_Id = 75, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 115", clothe_Id = 75, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 116", clothe_Id = 75, clothe_Texture = 4, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 117", clothe_Id = 75, clothe_Texture = 5, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 118", clothe_Id = 75, clothe_Texture = 6, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 119", clothe_Id = 75, clothe_Texture = 7, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 120", clothe_Id = 75, clothe_Texture = 8, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 121", clothe_Id = 75, clothe_Texture = 9, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 122", clothe_Id = 75, clothe_Texture = 10, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 123", clothe_Id = 78, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 124", clothe_Id = 78, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 125", clothe_Id = 78, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 126", clothe_Id = 78, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 127", clothe_Id = 78, clothe_Texture = 4, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 128", clothe_Id = 78, clothe_Texture = 5, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 129", clothe_Id = 78, clothe_Texture = 6, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 130", clothe_Id = 78, clothe_Texture = 7, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 131", clothe_Id = 78, clothe_Texture = 8, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 132", clothe_Id = 78, clothe_Texture = 9, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 133", clothe_Id = 78, clothe_Texture = 10, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 134", clothe_Id = 78, clothe_Texture = 11, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 135", clothe_Id = 78, clothe_Texture = 12, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 136", clothe_Id = 78, clothe_Texture = 13, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 137", clothe_Id = 78, clothe_Texture = 14, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 138", clothe_Id = 78, clothe_Texture = 15, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 139", clothe_Id = 79, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 140", clothe_Id = 85, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 141", clothe_Id = 84, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 142", clothe_Id = 84, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 143", clothe_Id = 84, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 144", clothe_Id = 84, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 145", clothe_Id = 84, clothe_Texture = 4, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 146", clothe_Id = 84, clothe_Texture = 5, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 147", clothe_Id = 86, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 148", clothe_Id = 86, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 149", clothe_Id = 86, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 150", clothe_Id = 86, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 151", clothe_Id = 86, clothe_Texture = 4, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 152", clothe_Id = 87, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 153", clothe_Id = 87, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 154", clothe_Id = 87, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 155", clothe_Id = 87, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 156", clothe_Id = 87, clothe_Texture = 4, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 157", clothe_Id = 87, clothe_Texture = 5, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 158", clothe_Id = 87, clothe_Texture = 6, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 159", clothe_Id = 87, clothe_Texture = 7, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 160", clothe_Id = 87, clothe_Texture = 8, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 161", clothe_Id = 87, clothe_Texture = 9, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 162", clothe_Id = 87, clothe_Texture = 10, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 163", clothe_Id = 87, clothe_Texture = 11, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 164", clothe_Id = 90, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 165", clothe_Id = 96, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 166", clothe_Id = 107, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 167", clothe_Id = 107, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 168", clothe_Id = 107, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 169", clothe_Id = 107, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 170", clothe_Id = 107, clothe_Texture = 4, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 171", clothe_Id = 110, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 172", clothe_Id = 125, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 173", clothe_Id = 126, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 174", clothe_Id = 126, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 175", clothe_Id = 126, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 176", clothe_Id = 126, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 177", clothe_Id = 126, clothe_Texture = 4, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 178", clothe_Id = 126, clothe_Texture = 5, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 179", clothe_Id = 126, clothe_Texture = 6, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 180", clothe_Id = 126, clothe_Texture = 7, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 181", clothe_Id = 126, clothe_Texture = 8, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 182", clothe_Id = 126, clothe_Texture = 9, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 183", clothe_Id = 126, clothe_Texture = 10, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 184", clothe_Id = 126, clothe_Texture = 11, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 185", clothe_Id = 126, clothe_Texture = 12, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 186", clothe_Id = 126, clothe_Texture = 13, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 187", clothe_Id = 126, clothe_Texture = 14, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 188", clothe_Id = 129, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 189", clothe_Id = 134, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 190", clothe_Id = 134, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 191", clothe_Id = 134, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 192", clothe_Id = 138, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 193", clothe_Id = 138, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 194", clothe_Id = 138, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 195", clothe_Id = 143, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 196", clothe_Id = 143, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 197", clothe_Id = 143, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 198", clothe_Id = 143, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 199", clothe_Id = 143, clothe_Texture = 4, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 200", clothe_Id = 143, clothe_Texture = 5, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 201", clothe_Id = 143, clothe_Texture = 6, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 202", clothe_Id = 143, clothe_Texture = 7, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 203", clothe_Id = 143, clothe_Texture = 8, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 204", clothe_Id = 143, clothe_Texture = 9, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 205", clothe_Id = 150, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 206", clothe_Id = 150, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 207", clothe_Id = 150, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 208", clothe_Id = 150, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 209", clothe_Id = 150, clothe_Texture = 4, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 210", clothe_Id = 150, clothe_Texture = 5, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 211", clothe_Id = 150, clothe_Texture = 6, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 212", clothe_Id = 150, clothe_Texture = 7, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 213", clothe_Id = 150, clothe_Texture = 8, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 214", clothe_Id = 150, clothe_Texture = 9, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 215", clothe_Id = 150, clothe_Texture = 10, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 216", clothe_Id = 150, clothe_Texture = 11, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 217", clothe_Id = 153, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 218", clothe_Id = 153, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 219", clothe_Id = 153, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 220", clothe_Id = 153, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 221", clothe_Id = 153, clothe_Texture = 4, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 222", clothe_Id = 153, clothe_Texture = 5, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 223", clothe_Id = 153, clothe_Texture = 6, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 224", clothe_Id = 153, clothe_Texture = 7, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 225", clothe_Id = 153, clothe_Texture = 8, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 226", clothe_Id = 153, clothe_Texture = 9, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 227", clothe_Id = 153, clothe_Texture = 10, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 228", clothe_Id = 153, clothe_Texture = 11, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 229", clothe_Id = 153, clothe_Texture = 12, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 230", clothe_Id = 153, clothe_Texture = 13, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 231", clothe_Id = 153, clothe_Texture = 14, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 232", clothe_Id = 153, clothe_Texture = 15, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 233", clothe_Id = 153, clothe_Texture = 16, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 234", clothe_Id = 153, clothe_Texture = 17, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 235", clothe_Id = 153, clothe_Texture = 18, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 236", clothe_Id = 153, clothe_Texture = 19, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 237", clothe_Id = 153, clothe_Texture = 20, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 238", clothe_Id = 153, clothe_Texture = 21, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 239", clothe_Id = 153, clothe_Texture = 22, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 240", clothe_Id = 153, clothe_Texture = 23, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 241", clothe_Id = 153, clothe_Texture = 24, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 242", clothe_Id = 153, clothe_Texture = 25, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 243", clothe_Id = 171, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 244", clothe_Id = 171, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 245", clothe_Id = 190, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 245", clothe_Id = 190, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 246", clothe_Id = 190, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 247", clothe_Id = 190, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 248", clothe_Id = 190, clothe_Texture = 4, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 248", clothe_Id = 190, clothe_Texture = 5, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 249", clothe_Id = 190, clothe_Texture = 6, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 250", clothe_Id = 190, clothe_Texture = 7, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 251", clothe_Id = 190, clothe_Texture = 8, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 252", clothe_Id = 190, clothe_Texture = 9, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 253", clothe_Id = 190, clothe_Texture = 10, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 254", clothe_Id = 190, clothe_Texture = 11, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 255", clothe_Id = 190, clothe_Texture = 12, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 256", clothe_Id = 190, clothe_Texture = 13, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 257", clothe_Id = 190, clothe_Texture = 14, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 258", clothe_Id = 190, clothe_Texture = 15, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 258", clothe_Id = 190, clothe_Texture = 16, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 259", clothe_Id = 190, clothe_Texture = 17, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 260", clothe_Id = 190, clothe_Texture = 18, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 261", clothe_Id = 190, clothe_Texture = 19, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 262", clothe_Id = 190, clothe_Texture = 20, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 263", clothe_Id = 190, clothe_Texture = 21, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 264", clothe_Id = 190, clothe_Texture = 22, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 265", clothe_Id = 190, clothe_Texture = 23, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 266", clothe_Id = 190, clothe_Texture = 24, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 267", clothe_Id = 190, clothe_Texture = 25, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 268", clothe_Id = 200, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 269", clothe_Id = 200, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 270", clothe_Id = 200, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 271", clothe_Id = 200, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 272", clothe_Id = 200, clothe_Texture = 4, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 273", clothe_Id = 200, clothe_Texture = 5, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 274", clothe_Id = 200, clothe_Texture = 6, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 275", clothe_Id = 200, clothe_Texture = 7, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 276", clothe_Id = 200, clothe_Texture = 8, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 277", clothe_Id = 200, clothe_Texture = 9, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 278", clothe_Id = 200, clothe_Texture = 10, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 279", clothe_Id = 200, clothe_Texture = 11, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 280", clothe_Id = 200, clothe_Texture = 12, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 281", clothe_Id = 200, clothe_Texture = 13, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 282", clothe_Id = 200, clothe_Texture = 14, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 283", clothe_Id = 200, clothe_Texture = 15, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 284", clothe_Id = 200, clothe_Texture = 16, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 285", clothe_Id = 200, clothe_Texture = 17, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 286", clothe_Id = 200, clothe_Texture = 18, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 287", clothe_Id = 200, clothe_Texture = 19, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 288", clothe_Id = 200, clothe_Texture = 20, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 289", clothe_Id = 200, clothe_Texture = 21, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 290", clothe_Id = 200, clothe_Texture = 22, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 291", clothe_Id = 200, clothe_Texture = 23, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 292", clothe_Id = 200, clothe_Texture = 24, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Hemd offen", clothe_Id = 127, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Hemd offen", clothe_Id = 127, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Hemd offen", clothe_Id = 127, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Hemd offen", clothe_Id = 127, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Hemd offen", clothe_Id = 127, clothe_Texture = 4, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Hemd offen", clothe_Id = 127, clothe_Texture = 5, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Hemd offen", clothe_Id = 127, clothe_Texture = 6, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Hemd offen", clothe_Id = 127, clothe_Texture = 7, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Hemd offen", clothe_Id = 127, clothe_Texture = 8, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Hemd offen", clothe_Id = 127, clothe_Texture = 9, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Hemd offen", clothe_Id = 127, clothe_Texture = 10, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Hemd offen", clothe_Id = 127, clothe_Texture = 11, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Hemd offen", clothe_Id = 127, clothe_Texture = 12, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Hemd offen", clothe_Id = 127, clothe_Texture = 13, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Hemd offen", clothe_Id = 127, clothe_Texture = 14, clothe_Torso = 14, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Jacke mit Weste", clothe_Id = 46, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Jacke mit Weste", clothe_Id = 46, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Jacke mit Weste", clothe_Id = 46, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });

        // Rocker und Mafia
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 300", clothe_Id = 4, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 4, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 301", clothe_Id = 4, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 4, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 302", clothe_Id = 4, clothe_Texture = 4, clothe_Torso = 14, clother_UnderShirt = 4, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 303", clothe_Id = 4, clothe_Texture = 11, clothe_Torso = 14, clother_UnderShirt = 4, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 304", clothe_Id = 4, clothe_Texture = 14, clothe_Torso = 14, clother_UnderShirt = 4, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 305", clothe_Id = 7, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 8, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 306", clothe_Id = 7, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 8, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 307", clothe_Id = 7, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 8, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 308", clothe_Id = 7, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 8, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 309", clothe_Id = 7, clothe_Texture = 4, clothe_Torso = 14, clother_UnderShirt = 8, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 310", clothe_Id = 7, clothe_Texture = 5, clothe_Torso = 14, clother_UnderShirt = 8, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 311", clothe_Id = 7, clothe_Texture = 6, clothe_Torso = 14, clother_UnderShirt = 8, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 312", clothe_Id = 20, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 33, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 313", clothe_Id = 20, clothe_Texture = 1, clothe_Torso = 6, clother_UnderShirt = 33, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 314", clothe_Id = 20, clothe_Texture = 2, clothe_Torso = 6, clother_UnderShirt = 33, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 315", clothe_Id = 20, clothe_Texture = 3, clothe_Torso = 6, clother_UnderShirt = 33, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 316", clothe_Id = 23, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 317", clothe_Id = 23, clothe_Texture = 1, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 318", clothe_Id = 23, clothe_Texture = 2, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 319", clothe_Id = 29, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3190", clothe_Id = 29, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3191", clothe_Id = 29, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3192", clothe_Id = 29, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3193", clothe_Id = 29, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3194", clothe_Id = 29, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3990", clothe_Id = 29, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3991", clothe_Id = 29, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3992", clothe_Id = 29, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3993", clothe_Id = 29, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3994", clothe_Id = 29, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 4 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 320", clothe_Id = 29, clothe_Texture = 1, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 321", clothe_Id = 29, clothe_Texture = 2, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 322", clothe_Id = 29, clothe_Texture = 3, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 323", clothe_Id = 29, clothe_Texture = 4, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 324", clothe_Id = 29, clothe_Texture = 5, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 325", clothe_Id = 29, clothe_Texture = 6, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 326", clothe_Id = 29, clothe_Texture = 7, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 327", clothe_Id = 31, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 328", clothe_Id = 31, clothe_Texture = 1, clothe_Torso = 6, clother_UnderShirt = 64, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 329", clothe_Id = 35, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 330", clothe_Id = 35, clothe_Texture = 1, clothe_Torso = 6, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 331", clothe_Id = 35, clothe_Texture = 2, clothe_Torso = 6, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 332", clothe_Id = 35, clothe_Texture = 3, clothe_Torso = 6, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 333", clothe_Id = 35, clothe_Texture = 4, clothe_Torso = 6, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3330", clothe_Id = 35, clothe_Texture = 4, clothe_Torso = 6, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 334", clothe_Id = 35, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3340", clothe_Id = 35, clothe_Texture = 1, clothe_Torso = 6, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3341", clothe_Id = 35, clothe_Texture = 2, clothe_Torso = 6, clother_UnderShirt = 23, clother_UnderShirtTexture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3342", clothe_Id = 35, clothe_Texture = 3, clothe_Torso = 6, clother_UnderShirt = 23, clother_UnderShirtTexture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3343", clothe_Id = 35, clothe_Texture = 4, clothe_Torso = 6, clother_UnderShirt = 23, clother_UnderShirtTexture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3345", clothe_Id = 35, clothe_Texture = 6, clothe_Torso = 6, clother_UnderShirt = 23, clother_UnderShirtTexture = 5 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 335", clothe_Id = 35, clothe_Texture = 6, clothe_Torso = 14, clother_UnderShirt = 4, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 336", clothe_Id = 58, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 4, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3360", clothe_Id = 58, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 60, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3361", clothe_Id = 58, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 69, clother_UnderShirtTexture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3362", clothe_Id = 58, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 69, clother_UnderShirtTexture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3363", clothe_Id = 58, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 69, clother_UnderShirtTexture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3364", clothe_Id = 58, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 69, clother_UnderShirtTexture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3365", clothe_Id = 58, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 69, clother_UnderShirtTexture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3366", clothe_Id = 58, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 69, clother_UnderShirtTexture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3367", clothe_Id = 58, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 69, clother_UnderShirtTexture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3368", clothe_Id = 58, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 69, clother_UnderShirtTexture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3369", clothe_Id = 58, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 69, clother_UnderShirtTexture = 5 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 336", clothe_Id = 58, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 4, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 336", clothe_Id = 58, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 4, clother_UnderShirtTexture = 0 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 337", clothe_Id = 62, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 338", clothe_Id = 62, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 23, clother_UnderShirtTexture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 339", clothe_Id = 62, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 23, clother_UnderShirtTexture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 340", clothe_Id = 62, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 23, clother_UnderShirtTexture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 341", clothe_Id = 62, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 23, clother_UnderShirtTexture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 342", clothe_Id = 62, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 23, clother_UnderShirtTexture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 343", clothe_Id = 157, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 122, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3430", clothe_Id = 157, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3431", clothe_Id = 157, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3432", clothe_Id = 157, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3433", clothe_Id = 157, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 344", clothe_Id = 157, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 345", clothe_Id = 157, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 346", clothe_Id = 160, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 122, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 347", clothe_Id = 160, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 122, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 348", clothe_Id = 170, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 122, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3480", clothe_Id = 170, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3481", clothe_Id = 170, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3482", clothe_Id = 170, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3483", clothe_Id = 170, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3484", clothe_Id = 170, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 3485", clothe_Id = 170, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 349", clothe_Id = 170, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 122, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 350", clothe_Id = 170, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 122, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 351", clothe_Id = 173, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 122, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 352", clothe_Id = 173, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 122, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 353", clothe_Id = 173, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 122, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 354", clothe_Id = 179, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 122, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 355", clothe_Id = 179, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 122, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 356", clothe_Id = 181, clothe_Texture = 0, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 357", clothe_Id = 181, clothe_Texture = 1, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 358", clothe_Id = 181, clothe_Texture = 2, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 359", clothe_Id = 181, clothe_Texture = 3, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 360", clothe_Id = 181, clothe_Texture = 4, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 361", clothe_Id = 181, clothe_Texture = 5, clothe_Torso = 15, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 362", clothe_Id = 183, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 24, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 363", clothe_Id = 183, clothe_Texture = 1, clothe_Torso = 6, clother_UnderShirt = 24, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 364", clothe_Id = 183, clothe_Texture = 2, clothe_Torso = 6, clother_UnderShirt = 24, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 365", clothe_Id = 183, clothe_Texture = 3, clothe_Torso = 6, clother_UnderShirt = 24, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 366", clothe_Id = 183, clothe_Texture = 4, clothe_Torso = 6, clother_UnderShirt = 24, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 367", clothe_Id = 183, clothe_Texture = 5, clothe_Torso = 6, clother_UnderShirt = 24, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 368", clothe_Id = 185, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 369", clothe_Id = 185, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 370", clothe_Id = 185, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 371", clothe_Id = 185, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 372", clothe_Id = 192, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 373", clothe_Id = 192, clothe_Texture = 1, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 374", clothe_Id = 192, clothe_Texture = 2, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 375", clothe_Id = 192, clothe_Texture = 3, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 376", clothe_Id = 192, clothe_Texture = 4, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 377", clothe_Id = 192, clothe_Texture = 5, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 378", clothe_Id = 192, clothe_Texture = 6, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 379", clothe_Id = 192, clothe_Texture = 7, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 380", clothe_Id = 192, clothe_Texture = 8, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 381", clothe_Id = 192, clothe_Texture = 9, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 382", clothe_Id = 192, clothe_Texture = 10, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 383", clothe_Id = 192, clothe_Texture = 11, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 384", clothe_Id = 240, clothe_Texture = 0, clothe_Torso = 4, clother_UnderShirt = 13, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 385", clothe_Id = 240, clothe_Texture = 1, clothe_Torso = 4, clother_UnderShirt = 13, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 386", clothe_Id = 240, clothe_Texture = 2, clothe_Torso = 4, clother_UnderShirt = 13, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 387", clothe_Id = 240, clothe_Texture = 3, clothe_Torso = 4, clother_UnderShirt = 13, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 388", clothe_Id = 240, clothe_Texture = 4, clothe_Torso = 4, clother_UnderShirt = 13, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 389", clothe_Id = 240, clothe_Texture = 5, clothe_Torso = 4, clother_UnderShirt = 13, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 390", clothe_Id = 230, clothe_Texture = 0, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 391", clothe_Id = 230, clothe_Texture = 1, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 392", clothe_Id = 230, clothe_Texture = 2, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 393", clothe_Id = 230, clothe_Texture = 3, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 394", clothe_Id = 230, clothe_Texture = 4, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 395", clothe_Id = 230, clothe_Texture = 5, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 396", clothe_Id = 230, clothe_Texture = 6, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 397", clothe_Id = 230, clothe_Texture = 7, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 398", clothe_Id = 230, clothe_Texture = 8, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 399", clothe_Id = 230, clothe_Texture = 9, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 400", clothe_Id = 230, clothe_Texture = 10, clothe_Torso = 4, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino ACLS 1 400", clothe_Id = 53, clothe_Texture = 1, clothe_Torso = 71, clother_UnderShirt = 59, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino ACLS 2 400", clothe_Id = 53, clothe_Texture = 2, clothe_Torso = 71, clother_UnderShirt = 59, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino ACLS 3 400", clothe_Id = 53, clothe_Texture = 3, clothe_Torso = 71, clother_UnderShirt = 59, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 31er 400", clothe_Id = 50, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 32er 400", clothe_Id = 50, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 33er 400", clothe_Id = 50, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 34er 400", clothe_Id = 50, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Casaco Masculino 34er 400", clothe_Id = 50, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Kutte Leder kurz", clothe_Id = 175, clothe_Texture = 0, clothe_Torso = 2, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Kutte Leder kurz", clothe_Id = 175, clothe_Texture = 0, clothe_Torso = 21, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 158, clothe_Texture = 0, clothe_Torso = 2, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 158, clothe_Texture = 0, clothe_Torso = 21, clother_UnderShirt = 2, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 159, clothe_Texture = 0, clothe_Torso = 2, clother_UnderShirt = 24, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 159, clothe_Texture = 0, clothe_Torso = 21, clother_UnderShirt = 24, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 160, clothe_Texture = 0, clothe_Torso = 2, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 160, clothe_Texture = 0, clothe_Torso = 21, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 161, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 162, clothe_Texture = 0, clothe_Torso = 2, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 162, clothe_Texture = 0, clothe_Torso = 21, clother_UnderShirt = 14, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 163, clothe_Texture = 0, clothe_Torso = 14, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 169, clothe_Texture = 0, clothe_Torso = 2, clother_UnderShirt = 1, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 170, clothe_Texture = 0, clothe_Torso = 2, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 172, clothe_Texture = 0, clothe_Torso = 2, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 172, clothe_Texture = 0, clothe_Torso = 21, clother_UnderShirt = 23, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 176, clothe_Texture = 0, clothe_Torso = 2, clother_UnderShirt = 44, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 176, clothe_Texture = 0, clothe_Torso = 21, clother_UnderShirt = 44, clother_UnderShirtTexture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Moletons Masculino", clothe_Name = "Moletons Masculino", clothe_Id = 174, clothe_Texture = 0, clothe_Torso = 6, clother_UnderShirt = 15, clother_UnderShirtTexture = 0 });


        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 1", clothe_Id = 9, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 2", clothe_Id = 9, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 3", clothe_Id = 9, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 4", clothe_Id = 9, clothe_Texture = 3, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 5", clothe_Id = 9, clothe_Texture = 4, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 6", clothe_Id = 9, clothe_Texture = 5, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 7", clothe_Id = 9, clothe_Texture = 6, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 8", clothe_Id = 9, clothe_Texture = 7, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 9", clothe_Id = 9, clothe_Texture = 10, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 10", clothe_Id = 9, clothe_Texture = 11, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 11", clothe_Id = 9, clothe_Texture = 12, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 12", clothe_Id = 9, clothe_Texture = 13, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 13", clothe_Id = 9, clothe_Texture = 14, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 14", clothe_Id = 9, clothe_Texture = 15, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 15", clothe_Id = 93, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 16", clothe_Id = 93, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 17", clothe_Id = 93, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 18", clothe_Id = 94, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 19", clothe_Id = 94, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 20", clothe_Id = 94, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 21", clothe_Id = 123, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 22", clothe_Id = 123, clothe_Texture = 1, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 23", clothe_Id = 123, clothe_Texture = 2, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 24", clothe_Id = 131, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo 25", clothe_Id = 132, clothe_Texture = 0, clothe_Torso = 0, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Pullover Kapuze", clothe_Id = 305, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Pullover Kapuze", clothe_Id = 305, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Pullover Kapuze", clothe_Id = 305, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Pullover Kapuze an", clothe_Id = 306, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Pullover Kapuze an", clothe_Id = 306, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Pullover Kapuze an", clothe_Id = 306, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo Masculina", clothe_Id = 308, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo Masculina", clothe_Id = 308, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Polo Masculina", clothe_Name = "Camisa Polo Masculina", clothe_Id = 308, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 1", clothe_Id = 12, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 2", clothe_Id = 12, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 3", clothe_Id = 12, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 4", clothe_Id = 12, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 5", clothe_Id = 12, clothe_Texture = 4, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 6", clothe_Id = 12, clothe_Texture = 5, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 7", clothe_Id = 12, clothe_Texture = 6, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 8", clothe_Id = 12, clothe_Texture = 7, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 9", clothe_Id = 12, clothe_Texture = 8, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 10", clothe_Id = 12, clothe_Texture = 9, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 11", clothe_Id = 12, clothe_Texture = 10, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 12", clothe_Id = 12, clothe_Texture = 11, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 13", clothe_Id = 14, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 14", clothe_Id = 14, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 15", clothe_Id = 14, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 16", clothe_Id = 14, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 17", clothe_Id = 14, clothe_Texture = 4, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 18", clothe_Id = 14, clothe_Texture = 5, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 19", clothe_Id = 14, clothe_Texture = 6, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 20", clothe_Id = 14, clothe_Texture = 7, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 21", clothe_Id = 14, clothe_Texture = 8, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 22", clothe_Id = 14, clothe_Texture = 9, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 23", clothe_Id = 14, clothe_Texture = 10, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 24", clothe_Id = 14, clothe_Texture = 11, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 25", clothe_Id = 14, clothe_Texture = 12, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 26", clothe_Id = 14, clothe_Texture = 13, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 27", clothe_Id = 14, clothe_Texture = 14, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 28", clothe_Id = 14, clothe_Texture = 15, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 29", clothe_Id = 41, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 30", clothe_Id = 41, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 31", clothe_Id = 41, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 32", clothe_Id = 41, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 33", clothe_Id = 126, clothe_Texture = 0, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 34", clothe_Id = 126, clothe_Texture = 1, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 35", clothe_Id = 126, clothe_Texture = 2, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 36", clothe_Id = 126, clothe_Texture = 3, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 37", clothe_Id = 126, clothe_Texture = 4, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 38", clothe_Id = 126, clothe_Texture = 5, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 39", clothe_Id = 126, clothe_Texture = 6, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 40", clothe_Id = 126, clothe_Texture = 7, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 41", clothe_Id = 126, clothe_Texture = 8, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 42", clothe_Id = 126, clothe_Texture = 9, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 43", clothe_Id = 126, clothe_Texture = 10, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 44", clothe_Id = 126, clothe_Texture = 11, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 45", clothe_Id = 126, clothe_Texture = 12, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 46", clothe_Id = 126, clothe_Texture = 13, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 47", clothe_Id = 126, clothe_Texture = 14, clothe_Torso = 1, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 48", clothe_Id = 13, clothe_Texture = 0, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 49", clothe_Id = 13, clothe_Texture = 1, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 50", clothe_Id = 13, clothe_Texture = 2, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 51", clothe_Id = 13, clothe_Texture = 3, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 52", clothe_Id = 13, clothe_Texture = 5, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 53", clothe_Id = 13, clothe_Texture = 13, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 54", clothe_Id = 26, clothe_Texture = 0, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 55", clothe_Id = 26, clothe_Texture = 1, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 56", clothe_Id = 26, clothe_Texture = 2, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 57", clothe_Id = 26, clothe_Texture = 3, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 58", clothe_Id = 26, clothe_Texture = 4, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 59", clothe_Id = 26, clothe_Texture = 5, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 60", clothe_Id = 26, clothe_Texture = 6, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 61", clothe_Id = 26, clothe_Texture = 7, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 62", clothe_Id = 26, clothe_Texture = 8, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 63", clothe_Id = 26, clothe_Texture = 9, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 64", clothe_Id = 42, clothe_Texture = 0, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 65", clothe_Id = 43, clothe_Texture = 0, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 66", clothe_Id = 133, clothe_Texture = 0, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 67", clothe_Id = 95, clothe_Texture = 0, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 68", clothe_Id = 95, clothe_Texture = 1, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 69", clothe_Id = 95, clothe_Texture = 2, clothe_Torso = 11, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 70", clothe_Id = 135, clothe_Texture = 0, clothe_Torso = 2, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 71", clothe_Id = 135, clothe_Texture = 1, clothe_Torso = 2, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 72", clothe_Id = 135, clothe_Texture = 2, clothe_Torso = 2, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 73", clothe_Id = 135, clothe_Texture = 3, clothe_Torso = 2, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 74", clothe_Id = 135, clothe_Texture = 4, clothe_Torso = 2, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 75", clothe_Id = 135, clothe_Texture = 5, clothe_Torso = 2, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Camisa Social Masculina", clothe_Name = "Camisa Social 76", clothe_Id = 135, clothe_Texture = 6, clothe_Torso = 2, clother_UnderShirt = 0, clother_UnderShirtTexture = 16 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 1", clothe_Id = 0, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 2", clothe_Id = 0, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 3", clothe_Id = 0, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 4", clothe_Id = 0, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 5", clothe_Id = 0, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 6", clothe_Id = 0, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 7", clothe_Id = 0, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 8", clothe_Id = 0, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 9", clothe_Id = 0, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 10", clothe_Id = 0, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 11", clothe_Id = 0, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 12", clothe_Id = 0, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 13", clothe_Id = 0, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 14", clothe_Id = 0, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 15", clothe_Id = 0, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 16", clothe_Id = 0, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 17", clothe_Id = 1, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 18", clothe_Id = 1, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 19", clothe_Id = 1, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 20", clothe_Id = 1, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 21", clothe_Id = 1, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 22", clothe_Id = 1, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 23", clothe_Id = 1, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 24", clothe_Id = 1, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 25", clothe_Id = 1, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 26", clothe_Id = 1, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 27", clothe_Id = 1, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 28", clothe_Id = 1, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 29", clothe_Id = 1, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 30", clothe_Id = 1, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 31", clothe_Id = 1, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 32", clothe_Id = 1, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 33", clothe_Id = 4, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 34", clothe_Id = 4, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 35", clothe_Id = 4, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 36", clothe_Id = 4, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 37", clothe_Id = 8, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 38", clothe_Id = 8, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 39", clothe_Id = 8, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 40", clothe_Id = 8, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 41", clothe_Id = 26, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 42", clothe_Id = 26, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 43", clothe_Id = 26, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 44", clothe_Id = 26, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 45", clothe_Id = 26, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 46", clothe_Id = 26, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 47", clothe_Id = 26, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 48", clothe_Id = 26, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 49", clothe_Id = 26, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 50", clothe_Id = 26, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 51", clothe_Id = 26, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 52", clothe_Id = 26, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 53", clothe_Id = 27, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 54", clothe_Id = 27, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 55", clothe_Id = 27, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 56", clothe_Id = 27, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 57", clothe_Id = 27, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 58", clothe_Id = 27, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 59", clothe_Id = 27, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 60", clothe_Id = 27, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 61", clothe_Id = 27, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 62", clothe_Id = 27, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 63", clothe_Id = 27, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 64", clothe_Id = 27, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 65", clothe_Id = 43, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 66", clothe_Id = 43, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 67", clothe_Id = 47, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 68", clothe_Id = 47, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 69", clothe_Id = 71, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 70", clothe_Id = 71, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 71", clothe_Id = 71, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 72", clothe_Id = 71, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 73", clothe_Id = 71, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 74", clothe_Id = 71, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 75", clothe_Id = 73, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 76", clothe_Id = 73, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 77", clothe_Id = 73, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 78", clothe_Id = 73, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 79", clothe_Id = 73, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 80", clothe_Id = 73, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 81", clothe_Id = 75, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 82", clothe_Id = 75, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 83", clothe_Id = 75, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 84", clothe_Id = 75, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 85", clothe_Id = 75, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 86", clothe_Id = 75, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 87", clothe_Id = 75, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 88", clothe_Id = 75, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 89", clothe_Id = 76, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 90", clothe_Id = 76, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 91", clothe_Id = 76, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 92", clothe_Id = 76, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 93", clothe_Id = 76, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 94", clothe_Id = 76, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 95", clothe_Id = 76, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 96", clothe_Id = 76, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 97", clothe_Id = 82, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 98", clothe_Id = 82, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 99", clothe_Id = 82, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 100", clothe_Id = 82, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 101", clothe_Id = 82, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 102", clothe_Id = 82, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 103", clothe_Id = 82, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 104", clothe_Id = 82, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 105", clothe_Id = 82, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Jeans Masculina", clothe_Name = "Calça Jeans Masculina 106", clothe_Id = 82, clothe_Texture = 9 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 1", clothe_Id = 9, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 2", clothe_Id = 9, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 3", clothe_Id = 9, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 4", clothe_Id = 9, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 5", clothe_Id = 9, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 6", clothe_Id = 9, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 7", clothe_Id = 9, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 8", clothe_Id = 9, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 9", clothe_Id = 9, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 10", clothe_Id = 9, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 11", clothe_Id = 9, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 12", clothe_Id = 9, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 13", clothe_Id = 9, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 14", clothe_Id = 9, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 15", clothe_Id = 9, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 16", clothe_Id = 9, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 17", clothe_Id = 34, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 18", clothe_Id = 36, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 19", clothe_Id = 46, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Cargo Masculina", clothe_Name = "Calça Cargo Masculina 20", clothe_Id = 46, clothe_Texture = 1 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 1", clothe_Id = 3, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 2", clothe_Id = 3, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 3", clothe_Id = 3, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 4", clothe_Id = 3, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 5", clothe_Id = 3, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 6", clothe_Id = 3, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 7", clothe_Id = 3, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 8", clothe_Id = 3, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 9", clothe_Id = 3, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 10", clothe_Id = 3, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 11", clothe_Id = 3, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 12", clothe_Id = 3, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 13", clothe_Id = 3, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 14", clothe_Id = 3, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 15", clothe_Id = 3, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 16", clothe_Id = 3, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 17", clothe_Id = 5, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 18", clothe_Id = 5, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 19", clothe_Id = 5, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 20", clothe_Id = 5, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 21", clothe_Id = 5, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 22", clothe_Id = 5, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 23", clothe_Id = 5, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 24", clothe_Id = 5, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 25", clothe_Id = 5, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 26", clothe_Id = 5, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 27", clothe_Id = 5, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 28", clothe_Id = 5, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 29", clothe_Id = 5, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 30", clothe_Id = 5, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 31", clothe_Id = 5, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 32", clothe_Id = 5, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 33", clothe_Id = 7, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 34", clothe_Id = 7, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 35", clothe_Id = 7, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 36", clothe_Id = 7, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 37", clothe_Id = 7, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 38", clothe_Id = 7, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 39", clothe_Id = 7, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 40", clothe_Id = 7, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 41", clothe_Id = 7, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 42", clothe_Id = 7, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 43", clothe_Id = 7, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 44", clothe_Id = 7, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 45", clothe_Id = 7, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 46", clothe_Id = 7, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 47", clothe_Id = 7, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 48", clothe_Id = 7, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 49", clothe_Id = 19, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 50", clothe_Id = 19, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 51", clothe_Id = 23, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 52", clothe_Id = 23, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 53", clothe_Id = 23, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 54", clothe_Id = 23, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 55", clothe_Id = 23, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 56", clothe_Id = 23, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 57", clothe_Id = 23, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 58", clothe_Id = 23, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 59", clothe_Id = 23, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 60", clothe_Id = 23, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 61", clothe_Id = 23, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 62", clothe_Id = 23, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 63", clothe_Id = 23, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 64", clothe_Id = 29, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 65", clothe_Id = 29, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 66", clothe_Id = 29, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 67", clothe_Id = 45, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 68", clothe_Id = 45, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 69", clothe_Id = 45, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 70", clothe_Id = 45, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 71", clothe_Id = 45, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 72", clothe_Id = 45, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 73", clothe_Id = 45, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 74", clothe_Id = 55, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 75", clothe_Id = 55, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 76", clothe_Id = 55, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 77", clothe_Id = 55, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 78", clothe_Id = 64, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 79", clothe_Id = 64, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 80", clothe_Id = 64, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 81", clothe_Id = 64, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 82", clothe_Id = 64, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 83", clothe_Id = 64, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 84", clothe_Id = 64, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 85", clothe_Id = 64, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 86", clothe_Id = 64, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 87", clothe_Id = 64, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 88", clothe_Id = 64, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 89", clothe_Id = 69, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 90", clothe_Id = 69, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 91", clothe_Id = 69, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 92", clothe_Id = 69, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 93", clothe_Id = 69, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 94", clothe_Id = 69, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 95", clothe_Id = 69, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 96", clothe_Id = 69, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 97", clothe_Id = 69, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 98", clothe_Id = 69, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 99", clothe_Id = 69, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 100", clothe_Id = 69, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 101", clothe_Id = 69, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 102", clothe_Id = 69, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 103", clothe_Id = 69, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 104", clothe_Id = 69, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 105", clothe_Id = 69, clothe_Texture = 16 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Pano Masculina", clothe_Name = "Calça Pano Masculina 106", clothe_Id = 69, clothe_Texture = 17 });



        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 1", clothe_Id = 10, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 2", clothe_Id = 10, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 3", clothe_Id = 10, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 4", clothe_Id = 13, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 5", clothe_Id = 13, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 6", clothe_Id = 13, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 7", clothe_Id = 20, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 8", clothe_Id = 20, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 9", clothe_Id = 20, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 10", clothe_Id = 22, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 11", clothe_Id = 22, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 12", clothe_Id = 22, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 13", clothe_Id = 22, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 14", clothe_Id = 22, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 15", clothe_Id = 22, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 16", clothe_Id = 22, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 17", clothe_Id = 22, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 18", clothe_Id = 22, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 19", clothe_Id = 22, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 20", clothe_Id = 22, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 21", clothe_Id = 22, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 22", clothe_Id = 22, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 23", clothe_Id = 23, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 24", clothe_Id = 23, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 25", clothe_Id = 23, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 26", clothe_Id = 23, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 27", clothe_Id = 23, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 28", clothe_Id = 23, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 29", clothe_Id = 23, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 30", clothe_Id = 23, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 31", clothe_Id = 23, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 32", clothe_Id = 23, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 33", clothe_Id = 23, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 34", clothe_Id = 23, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 35", clothe_Id = 23, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 36", clothe_Id = 24, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 37", clothe_Id = 24, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 38", clothe_Id = 24, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 39", clothe_Id = 24, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 40", clothe_Id = 24, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 41", clothe_Id = 24, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 42", clothe_Id = 24, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 43", clothe_Id = 25, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 44", clothe_Id = 25, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 45", clothe_Id = 25, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 46", clothe_Id = 25, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 47", clothe_Id = 25, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 48", clothe_Id = 25, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 49", clothe_Id = 25, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 50", clothe_Id = 28, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 51", clothe_Id = 28, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 52", clothe_Id = 28, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 53", clothe_Id = 28, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 54", clothe_Id = 28, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 55", clothe_Id = 28, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 56", clothe_Id = 28, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 57", clothe_Id = 28, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 58", clothe_Id = 28, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 59", clothe_Id = 28, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 60", clothe_Id = 28, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 61", clothe_Id = 28, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 62", clothe_Id = 28, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 63", clothe_Id = 28, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 64", clothe_Id = 28, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 65", clothe_Id = 28, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 66", clothe_Id = 37, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 67", clothe_Id = 37, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 68", clothe_Id = 37, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 69", clothe_Id = 37, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 70", clothe_Id = 45, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 71", clothe_Id = 45, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 72", clothe_Id = 45, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 73", clothe_Id = 45, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 74", clothe_Id = 45, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 75", clothe_Id = 45, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 76", clothe_Id = 45, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 77", clothe_Id = 48, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 78", clothe_Id = 48, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 79", clothe_Id = 48, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 80", clothe_Id = 48, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 81", clothe_Id = 48, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 82", clothe_Id = 49, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 83", clothe_Id = 49, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 84", clothe_Id = 49, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 85", clothe_Id = 49, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 86", clothe_Id = 49, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 87", clothe_Id = 50, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 88", clothe_Id = 50, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 89", clothe_Id = 50, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 90", clothe_Id = 50, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 91", clothe_Id = 52, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 92", clothe_Id = 52, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 93", clothe_Id = 52, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 94", clothe_Id = 52, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 95", clothe_Id = 51, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 96", clothe_Id = 53, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 97", clothe_Id = 60, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 98", clothe_Id = 60, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 99", clothe_Id = 60, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 100", clothe_Id = 60, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 101", clothe_Id = 60, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 102", clothe_Id = 60, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 103", clothe_Id = 60, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 104", clothe_Id = 60, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 105", clothe_Id = 60, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 106", clothe_Id = 60, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 107", clothe_Id = 60, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 108", clothe_Id = 60, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 109", clothe_Id = 65, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 110", clothe_Id = 65, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 111", clothe_Id = 65, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 112", clothe_Id = 65, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 113", clothe_Id = 65, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 114", clothe_Id = 65, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 115", clothe_Id = 65, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 116", clothe_Id = 65, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 117", clothe_Id = 65, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 118", clothe_Id = 65, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 119", clothe_Id = 65, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 120", clothe_Id = 65, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 121", clothe_Id = 65, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 122", clothe_Id = 65, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 123", clothe_Id = 79, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 124", clothe_Id = 79, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Calça Social Masculina", clothe_Name = "Calça Social Masculina 125", clothe_Id = 79, clothe_Texture = 2 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 1", clothe_Id = 2, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 2", clothe_Id = 6, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 3", clothe_Id = 6, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 4", clothe_Id = 6, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 5", clothe_Id = 6, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 6", clothe_Id = 12, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 7", clothe_Id = 12, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 8", clothe_Id = 12, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 9", clothe_Id = 12, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 10", clothe_Id = 12, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 11", clothe_Id = 15, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 12", clothe_Id = 15, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 13", clothe_Id = 15, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 14", clothe_Id = 15, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 15", clothe_Id = 15, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 16", clothe_Id = 15, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 17", clothe_Id = 15, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 18", clothe_Id = 15, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 19", clothe_Id = 15, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 20", clothe_Id = 15, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 21", clothe_Id = 15, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 22", clothe_Id = 15, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 23", clothe_Id = 15, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 24", clothe_Id = 15, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 25", clothe_Id = 15, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 26", clothe_Id = 15, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 27", clothe_Id = 16, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 28", clothe_Id = 16, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 29", clothe_Id = 16, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 30", clothe_Id = 16, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 31", clothe_Id = 16, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 32", clothe_Id = 16, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 33", clothe_Id = 16, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 34", clothe_Id = 16, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 35", clothe_Id = 16, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 36", clothe_Id = 16, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 37", clothe_Id = 16, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 38", clothe_Id = 16, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 39", clothe_Id = 17, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 40", clothe_Id = 17, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 41", clothe_Id = 17, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 42", clothe_Id = 17, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 43", clothe_Id = 17, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 44", clothe_Id = 17, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 45", clothe_Id = 17, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 46", clothe_Id = 17, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 47", clothe_Id = 17, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 48", clothe_Id = 17, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 49", clothe_Id = 17, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 50", clothe_Id = 42, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 51", clothe_Id = 42, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 52", clothe_Id = 42, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 53", clothe_Id = 42, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 54", clothe_Id = 42, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 55", clothe_Id = 42, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 56", clothe_Id = 42, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 57", clothe_Id = 42, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 58", clothe_Id = 54, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 59", clothe_Id = 54, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 60", clothe_Id = 54, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 61", clothe_Id = 54, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 62", clothe_Id = 54, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 63", clothe_Id = 54, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 64", clothe_Id = 54, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 65", clothe_Id = 62, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 66", clothe_Id = 62, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 67", clothe_Id = 62, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 68", clothe_Id = 62, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 69", clothe_Id = 80, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 70", clothe_Id = 80, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 71", clothe_Id = 80, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 72", clothe_Id = 80, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 73", clothe_Id = 80, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 74", clothe_Id = 80, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 75", clothe_Id = 80, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 76", clothe_Id = 80, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 77", clothe_Id = 81, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 78", clothe_Id = 81, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Masculino", clothe_Name = "Short Masculino 79", clothe_Id = 81, clothe_Texture = 2 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 1", clothe_Id = 14, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 2", clothe_Id = 14, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 3", clothe_Id = 14, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 4", clothe_Id = 14, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 5", clothe_Id = 18, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 6", clothe_Id = 18, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 7", clothe_Id = 18, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 8", clothe_Id = 18, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 9", clothe_Id = 18, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 10", clothe_Id = 18, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 11", clothe_Id = 18, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 12", clothe_Id = 18, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 13", clothe_Id = 18, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 14", clothe_Id = 18, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 15", clothe_Id = 18, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 16", clothe_Id = 18, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 17", clothe_Id = 21, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 18", clothe_Id = 61, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 19", clothe_Id = 61, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 20", clothe_Id = 61, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 21", clothe_Id = 61, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 22", clothe_Id = 61, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 23", clothe_Id = 61, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 24", clothe_Id = 61, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 25", clothe_Id = 61, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 26", clothe_Id = 61, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 27", clothe_Id = 61, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 28", clothe_Id = 61, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 29", clothe_Id = 61, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 30", clothe_Id = 61, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Short Curto Masculino", clothe_Name = "Short Curto Masculino 31", clothe_Id = 61, clothe_Texture = 13 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 1", clothe_Id = 0, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 2", clothe_Id = 2, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 3", clothe_Id = 2, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 4", clothe_Id = 1, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 5", clothe_Id = 1, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 6", clothe_Id = 1, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 7", clothe_Id = 1, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 8", clothe_Id = 1, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 9", clothe_Id = 1, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 10", clothe_Id = 1, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 11", clothe_Id = 1, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 12", clothe_Id = 1, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 13", clothe_Id = 1, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 14", clothe_Id = 1, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 15", clothe_Id = 1, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 16", clothe_Id = 1, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 17", clothe_Id = 1, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 18", clothe_Id = 1, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 19", clothe_Id = 1, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 20", clothe_Id = 4, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 21", clothe_Id = 4, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 22", clothe_Id = 4, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 23", clothe_Id = 7, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 24", clothe_Id = 7, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 25", clothe_Id = 7, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 26", clothe_Id = 7, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 27", clothe_Id = 7, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 28", clothe_Id = 7, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 29", clothe_Id = 7, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 30", clothe_Id = 7, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 31", clothe_Id = 7, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 32", clothe_Id = 7, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 34", clothe_Id = 7, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 35", clothe_Id = 7, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 36", clothe_Id = 7, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 37", clothe_Id = 7, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 38", clothe_Id = 7, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 39", clothe_Id = 7, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 40", clothe_Id = 8, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 41", clothe_Id = 8, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 42", clothe_Id = 8, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 43", clothe_Id = 8, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 44", clothe_Id = 8, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 45", clothe_Id = 8, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 46", clothe_Id = 8, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 47", clothe_Id = 8, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 48", clothe_Id = 8, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 49", clothe_Id = 8, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 50", clothe_Id = 8, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 51", clothe_Id = 8, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 52", clothe_Id = 8, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 53", clothe_Id = 8, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 54", clothe_Id = 8, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 55", clothe_Id = 8, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 56", clothe_Id = 9, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 57", clothe_Id = 9, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 58", clothe_Id = 9, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 59", clothe_Id = 9, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 60", clothe_Id = 9, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 61", clothe_Id = 9, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 62", clothe_Id = 9, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 63", clothe_Id = 9, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 64", clothe_Id = 9, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 65", clothe_Id = 9, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 66", clothe_Id = 9, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 67", clothe_Id = 9, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 68", clothe_Id = 9, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 69", clothe_Id = 9, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 70", clothe_Id = 9, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 71", clothe_Id = 9, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 72", clothe_Id = 12, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 73", clothe_Id = 12, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 74", clothe_Id = 12, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 75", clothe_Id = 12, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 76", clothe_Id = 12, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 77", clothe_Id = 12, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 78", clothe_Id = 12, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 79", clothe_Id = 12, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 80", clothe_Id = 12, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 81", clothe_Id = 12, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 82", clothe_Id = 12, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 83", clothe_Id = 12, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 84", clothe_Id = 12, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 85", clothe_Id = 12, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 86", clothe_Id = 12, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 87", clothe_Id = 12, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 88", clothe_Id = 14, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 89", clothe_Id = 14, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 90", clothe_Id = 14, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 91", clothe_Id = 14, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 92", clothe_Id = 14, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 93", clothe_Id = 14, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 94", clothe_Id = 14, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 95", clothe_Id = 14, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 96", clothe_Id = 14, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 97", clothe_Id = 14, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 98", clothe_Id = 14, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 99", clothe_Id = 14, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 100", clothe_Id = 14, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 101", clothe_Id = 14, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 102", clothe_Id = 14, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 103", clothe_Id = 14, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 104", clothe_Id = 22, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 105", clothe_Id = 22, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 106", clothe_Id = 22, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 107", clothe_Id = 22, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 108", clothe_Id = 22, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 109", clothe_Id = 22, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 110", clothe_Id = 22, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 111", clothe_Id = 22, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 112", clothe_Id = 22, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 113", clothe_Id = 22, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 114", clothe_Id = 22, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 115", clothe_Id = 22, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 116", clothe_Id = 23, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 117", clothe_Id = 23, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 118", clothe_Id = 23, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 119", clothe_Id = 23, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 120", clothe_Id = 23, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 121", clothe_Id = 23, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 122", clothe_Id = 23, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 123", clothe_Id = 23, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 124", clothe_Id = 23, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 125", clothe_Id = 23, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 126", clothe_Id = 23, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 127", clothe_Id = 23, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 128", clothe_Id = 23, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 129", clothe_Id = 23, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 130", clothe_Id = 23, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 131", clothe_Id = 23, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 132", clothe_Id = 26, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 133", clothe_Id = 26, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 134", clothe_Id = 26, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 135", clothe_Id = 26, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 136", clothe_Id = 26, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 137", clothe_Id = 26, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 138", clothe_Id = 26, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 139", clothe_Id = 26, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 140", clothe_Id = 26, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 141", clothe_Id = 26, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 142", clothe_Id = 26, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 143", clothe_Id = 26, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 144", clothe_Id = 26, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 145", clothe_Id = 26, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 146", clothe_Id = 26, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 147", clothe_Id = 26, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 148", clothe_Id = 28, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 149", clothe_Id = 28, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 150", clothe_Id = 28, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 151", clothe_Id = 28, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 152", clothe_Id = 28, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 153", clothe_Id = 28, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 154", clothe_Id = 29, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 155", clothe_Id = 31, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 156", clothe_Id = 31, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 157", clothe_Id = 31, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 158", clothe_Id = 31, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 159", clothe_Id = 31, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 160", clothe_Id = 32, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 161", clothe_Id = 32, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 162", clothe_Id = 32, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 163", clothe_Id = 32, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 164", clothe_Id = 32, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 165", clothe_Id = 32, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 166", clothe_Id = 32, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 167", clothe_Id = 32, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 168", clothe_Id = 32, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 169", clothe_Id = 32, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 170", clothe_Id = 32, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 171", clothe_Id = 32, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 172", clothe_Id = 32, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 173", clothe_Id = 32, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 174", clothe_Id = 32, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 175", clothe_Id = 32, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 176", clothe_Id = 46, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 177", clothe_Id = 46, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 178", clothe_Id = 46, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 179", clothe_Id = 46, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 180", clothe_Id = 46, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 181", clothe_Id = 46, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 182", clothe_Id = 46, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 183", clothe_Id = 46, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 184", clothe_Id = 46, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 185", clothe_Id = 46, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 186", clothe_Id = 48, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 187", clothe_Id = 48, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 188", clothe_Id = 49, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 189", clothe_Id = 49, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 190", clothe_Id = 51, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 191", clothe_Id = 51, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 192", clothe_Id = 51, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 193", clothe_Id = 51, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 194", clothe_Id = 51, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 195", clothe_Id = 51, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 196", clothe_Id = 54, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 197", clothe_Id = 54, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 198", clothe_Id = 54, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 199", clothe_Id = 54, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 200", clothe_Id = 54, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 201", clothe_Id = 54, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 202", clothe_Id = 57, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 203", clothe_Id = 57, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 204", clothe_Id = 57, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 205", clothe_Id = 57, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 206", clothe_Id = 57, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 207", clothe_Id = 57, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 208", clothe_Id = 57, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 209", clothe_Id = 57, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 210", clothe_Id = 57, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 211", clothe_Id = 57, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 212", clothe_Id = 57, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Tenis Masculino", clothe_Name = "Tenis Masculino 213", clothe_Id = 57, clothe_Texture = 11 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 1", clothe_Id = 3, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 2", clothe_Id = 3, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 3", clothe_Id = 3, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 4", clothe_Id = 3, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 5", clothe_Id = 3, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 6", clothe_Id = 3, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 7", clothe_Id = 3, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 8", clothe_Id = 3, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 9", clothe_Id = 3, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 10", clothe_Id = 3, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 11", clothe_Id = 3, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 12", clothe_Id = 3, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 13", clothe_Id = 3, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 14", clothe_Id = 3, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 15", clothe_Id = 3, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 16", clothe_Id = 3, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 17", clothe_Id = 10, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 18", clothe_Id = 10, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 19", clothe_Id = 10, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 20", clothe_Id = 10, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 21", clothe_Id = 11, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 22", clothe_Id = 11, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 23", clothe_Id = 11, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 24", clothe_Id = 11, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 25", clothe_Id = 12, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 26", clothe_Id = 12, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 27", clothe_Id = 12, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 28", clothe_Id = 12, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 29", clothe_Id = 12, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 30", clothe_Id = 12, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 31", clothe_Id = 12, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 32", clothe_Id = 12, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 33", clothe_Id = 12, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 34", clothe_Id = 12, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 35", clothe_Id = 12, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 36", clothe_Id = 12, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 37", clothe_Id = 12, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 38", clothe_Id = 12, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 39", clothe_Id = 12, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 40", clothe_Id = 12, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 41", clothe_Id = 15, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 42", clothe_Id = 15, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 43", clothe_Id = 15, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 44", clothe_Id = 15, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 45", clothe_Id = 15, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 46", clothe_Id = 15, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 47", clothe_Id = 15, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 48", clothe_Id = 15, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 49", clothe_Id = 15, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 50", clothe_Id = 15, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 51", clothe_Id = 15, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 52", clothe_Id = 15, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 53", clothe_Id = 15, clothe_Texture = 12 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 54", clothe_Id = 15, clothe_Texture = 13 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 55", clothe_Id = 15, clothe_Texture = 14 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 56", clothe_Id = 15, clothe_Texture = 15 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 57", clothe_Id = 18, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 58", clothe_Id = 18, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 59", clothe_Id = 19, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 60", clothe_Id = 20, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 61", clothe_Id = 20, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 62", clothe_Id = 20, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 63", clothe_Id = 20, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 64", clothe_Id = 20, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 65", clothe_Id = 20, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 66", clothe_Id = 20, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 67", clothe_Id = 20, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 68", clothe_Id = 20, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 69", clothe_Id = 20, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 70", clothe_Id = 20, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 71", clothe_Id = 20, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 72", clothe_Id = 21, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 73", clothe_Id = 21, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 74", clothe_Id = 21, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 75", clothe_Id = 21, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 76", clothe_Id = 21, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 77", clothe_Id = 21, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 78", clothe_Id = 21, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 79", clothe_Id = 21, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 80", clothe_Id = 21, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 81", clothe_Id = 21, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 82", clothe_Id = 21, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 83", clothe_Id = 21, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 84", clothe_Id = 30, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 85", clothe_Id = 30, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 86", clothe_Id = 36, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 87", clothe_Id = 36, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 88", clothe_Id = 36, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 89", clothe_Id = 36, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 90", clothe_Id = 38, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 91", clothe_Id = 38, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 92", clothe_Id = 38, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 93", clothe_Id = 38, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 94", clothe_Id = 38, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 95", clothe_Id = 40, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 96", clothe_Id = 40, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 97", clothe_Id = 40, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 98", clothe_Id = 40, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 99", clothe_Id = 40, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 100", clothe_Id = 40, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 101", clothe_Id = 40, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 102", clothe_Id = 40, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 103", clothe_Id = 40, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 104", clothe_Id = 40, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 105", clothe_Id = 40, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 106", clothe_Id = 40, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 107", clothe_Id = 41, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 108", clothe_Id = 42, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 109", clothe_Id = 42, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 110", clothe_Id = 42, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 111", clothe_Id = 42, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 112", clothe_Id = 42, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 113", clothe_Id = 42, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 114", clothe_Id = 42, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 115", clothe_Id = 42, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 116", clothe_Id = 42, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 117", clothe_Id = 42, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 118", clothe_Id = 43, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 119", clothe_Id = 43, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 120", clothe_Id = 43, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 121", clothe_Id = 43, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 122", clothe_Id = 43, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 123", clothe_Id = 43, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 124", clothe_Id = 43, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 125", clothe_Id = 43, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 126", clothe_Id = 45, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 127", clothe_Id = 45, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 128", clothe_Id = 45, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 129", clothe_Id = 45, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 130", clothe_Id = 45, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 131", clothe_Id = 45, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 132", clothe_Id = 45, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 133", clothe_Id = 45, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 134", clothe_Id = 45, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 135", clothe_Id = 45, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 136", clothe_Id = 45, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 137", clothe_Id = 56, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Sapato Masculino", clothe_Name = "Sapato Masculino 138", clothe_Id = 56, clothe_Texture = 1 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 1", clothe_Id = 24, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 2", clothe_Id = 25, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 3", clothe_Id = 27, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 4", clothe_Id = 35, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 5", clothe_Id = 35, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 6", clothe_Id = 37, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 7", clothe_Id = 37, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 8", clothe_Id = 37, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 9", clothe_Id = 37, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 10", clothe_Id = 37, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 11", clothe_Id = 44, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 12", clothe_Id = 44, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 13", clothe_Id = 44, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 14", clothe_Id = 44, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 15", clothe_Id = 44, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 16", clothe_Id = 44, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 17", clothe_Id = 44, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 18", clothe_Id = 44, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 19", clothe_Id = 44, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 20", clothe_Id = 44, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 21", clothe_Id = 44, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 22", clothe_Id = 50, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 23", clothe_Id = 50, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 24", clothe_Id = 50, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 25", clothe_Id = 50, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 26", clothe_Id = 50, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 27", clothe_Id = 50, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 28", clothe_Id = 52, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 29", clothe_Id = 52, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 30", clothe_Id = 53, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 34", clothe_Id = 53, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 35", clothe_Id = 53, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 36", clothe_Id = 53, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 37", clothe_Id = 53, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Bota Masculina", clothe_Name = "Bota Masculina 38", clothe_Id = 53, clothe_Texture = 5 });

        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 1", clothe_Id = 5, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 2", clothe_Id = 5, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 3", clothe_Id = 5, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 4", clothe_Id = 5, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 5", clothe_Id = 16, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 6", clothe_Id = 16, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 7", clothe_Id = 16, clothe_Texture = 2 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 8", clothe_Id = 16, clothe_Texture = 3 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 9", clothe_Id = 16, clothe_Texture = 4 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 10", clothe_Id = 16, clothe_Texture = 5 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 11", clothe_Id = 16, clothe_Texture = 6 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 12", clothe_Id = 16, clothe_Texture = 7 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 13", clothe_Id = 16, clothe_Texture = 8 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 14", clothe_Id = 16, clothe_Texture = 9 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 15", clothe_Id = 16, clothe_Texture = 10 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 16", clothe_Id = 16, clothe_Texture = 11 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 17", clothe_Id = 6, clothe_Texture = 0 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 18", clothe_Id = 6, clothe_Texture = 1 });
        clothes_list.Add(new { clothe_genre = 0, clothe_class = "Chinelo Masculino", clothe_Name = "Chinelo Masculino 19", clothe_Id = 34, clothe_Texture = 0 });
        #endregion Male_Clothes
    }

    public static int GetClotheIndex(string clothe_name)
    {
        int index = -1, foreach_index = -1;

        foreach (var clothes in clothes_list)
        {
            if (clothes.clothe_Name == clothe_name)
            {
                return index = foreach_index;
            }
            foreach_index++;
        }
        return -1;
    }

    public static int GetMenuItems(string class_name)
    {
        int index = 0;
        foreach (var clothes in clothes_list)
        {
            if (clothes.clothe_class == class_name)
            {
                index += 1;
            }
        }
        return index;
    }

    public static int GetClotheIndexFirst(string class_name)
    {
        int index = 0, foreach_index = 0;

        foreach (var clothes in clothes_list)
        {
            if (clothes.clothe_class == class_name)
            {
                return index = foreach_index;
            }
            foreach_index++;
        }
        return -1;
    }

    public static int GetClotheIndexLast(string class_name)
    {
        int index = GetClotheIndexFirst(class_name);
        foreach (var clothes in clothes_list)
        {
            if (clothes.clothe_class == class_name)
            {
                index += 1;
            }
        }
        return index;
    }

    public static void SetPlayerShirts(Client player, int shirt, int shirt_texture, int torso, int undershit, int undershirttexture)
    {
        player.SetClothes(11, shirt, shirt_texture);
        player.SetClothes(3, torso, 0);
        player.SetClothes(8, undershit, undershirttexture);
    }

    public static void SetPlayerLegs(Client player, int leg, int leg_texture)
    {
        player.SetClothes(4, leg, leg_texture);
    }

    public static void SetPlayerShoes(Client player, int shoe, int shoe_texture)
    {
        player.SetClothes(6, shoe, shoe_texture);
    }

    [RemoteEvent("Preview_Clothes")]
    public static void Preview_Clothes(Client player, string category, int index)
    {
        if (category == "shirt")
        {
            SetPlayerShirts(player, clothes_list[index].clothe_Id, clothes_list[index].clothe_Texture, clothes_list[index].clothe_Torso, clothes_list[index].clother_UnderShirt, clothes_list[index].clother_UnderShirtTexture);
        }
        else if (category == "pants")
        {
            SetPlayerLegs(player, clothes_list[index].clothe_Id, clothes_list[index].clothe_Texture);
        }
        else if (category == "shoes")
        {
            SetPlayerShoes(player, clothes_list[index].clothe_Id, clothes_list[index].clothe_Texture);
        }
        else if (category == "hats")
        {
            player.SetAccessories(0, acessories[index].draw, acessories[index].variation);
        }
        else if (category == "glasses")
        {
            player.SetAccessories(1, acessories[index].draw, acessories[index].variation);
        }
        else if (category == "neck")
        {
            player.SetClothes(7, clothes_list[index].clothe_Id, clothes_list[index].clothe_Texture);
        }
        else if (category == "watches")
        {
            player.SetAccessories(6, acessories[index].draw, acessories[index].variation);
        }
        else if (category == "bracelets")
        {
            player.SetAccessories(7, acessories[index].draw, acessories[index].variation);
        }
    }

    public static void ShowClothesMainMenu(Client player, int clothes_type, string response)
    {
        int count = 0;
        List<string> shirt = new List<string>();
        List<string> moletons = new List<string>();
        List<string> pants = new List<string>();
        List<string> shoes = new List<string>();
        List<string> hats = new List<string>();
        List<string> glasses = new List<string>();
        List<string> neck = new List<string>();
        List<string> watches = new List<string>();
        List<string> bracelets = new List<string>();
        List<dynamic> menu_item_list = new List<dynamic>();

        shirt.Add("Auswählen");
        moletons.Add("Auswählen");
        pants.Add("Auswählen");
        shoes.Add("Auswählen");
        hats.Add("Auswählen");
        neck.Add("Auswählen");
        glasses.Add("Auswählen");
        watches.Add("Auswählen");
        bracelets.Add("Auswählen");

        if ((int)NAPI.Data.GetEntitySharedData(player, "CHARACTER_ONLINE_GENRE") == 1)
        {
            foreach (var clothes in clothes_list)
            {

                if (clothes.clothe_genre == 1)
                {
                    if (clothes.clothe_class == "Camisas" || clothes.clothe_class == "Camisetas" || clothes.clothe_class == "Camisas Polos" || clothes.clothe_class == "Top" || clothes.clothe_class == "Biquinis" || clothes.clothe_class == "Vestidos")
                    {
                        shirt.Add(count.ToString());
                    }
                    if (clothes.clothe_class == "Moleton")
                    {
                        moletons.Add(count.ToString());
                    }
                    if (clothes.clothe_class == "Calça Jeans" || clothes.clothe_class == "Calça Cargo" || clothes.clothe_class == "Calça de Pano" || clothes.clothe_class == "Calça Social" || clothes.clothe_class == "Short" || clothes.clothe_class == "Saia" || clothes.clothe_class == "Calcinha")
                    {
                        pants.Add(count.ToString());
                    }

                    if (clothes.clothe_class == "Salto" || clothes.clothe_class == "Tenis" || clothes.clothe_class == "Bota" || clothes.clothe_class == "Sandalha")
                    {
                        shoes.Add(count.ToString());
                    }

                    if (clothes.clothe_class == "Neck")
                    {
                        neck.Add(count.ToString());
                    }


                }
                count++;

            }
            count = 0;
            foreach (var clothes in acessories)
            {
                if (clothes.sex == 1)
                {
                    if (clothes.category == "Boné" || clothes.category == "Chapeu" || clothes.category == "Toca" || clothes.category == "Boina" || clothes.category == "Bandana" || clothes.category == "Item de Natal")
                    {
                        hats.Add(count.ToString());
                    }
                    if (clothes.category == "Oculus")
                    {
                        glasses.Add(count.ToString());
                    }
                    if (clothes.category == "Uhr")
                    {
                        watches.Add(count.ToString());
                    }
                    if (clothes.category == "Armband")
                    {
                        watches.Add(count.ToString());
                    }
                }
                count++;
            }
        }
        else if ((int)NAPI.Data.GetEntitySharedData(player, "CHARACTER_ONLINE_GENRE") == 0)
        {
            foreach (var clothes in clothes_list)
            {

                if (clothes.clothe_genre == 0)
                {
                    if (clothes.clothe_class == "Camisa Masculina" || clothes.clothe_class == "Camisetas Masculina" || clothes.clothe_class == "Camisa Polo Masculina" || clothes.clothe_class == "Camisa Social Masculina")
                    {
                        shirt.Add(count.ToString());
                    }

                    if (clothes.clothe_class == "Moletons Masculino")
                    {
                        moletons.Add(count.ToString());
                    }

                    if (clothes.clothe_class == "Calça Jeans Masculina" || clothes.clothe_class == "Calça Cargo Masculina" || clothes.clothe_class == "Calça Pano Masculina" || clothes.clothe_class == "Calça Social Masculina" || clothes.clothe_class == "Short Masculino" || clothes.clothe_class == "Short Curto Masculino")
                    {
                        pants.Add(count.ToString());
                    }

                    if (clothes.clothe_class == "Tenis Masculino" || clothes.clothe_class == "Sapato Masculino" || clothes.clothe_class == " Bota Masculina" || clothes.clothe_class == "Chinelo Masculino")
                    {
                        shoes.Add(count.ToString());
                    }

                    if (clothes.clothe_class == "Neck")
                    {
                        neck.Add(count.ToString());
                    }
                }
                count++;
            }
            count = 0;
            foreach (var clothes in acessories)
            {
                if (clothes.sex == 0)
                {
                    if (clothes.category == "Boné" || clothes.category == "Chapéu" || clothes.category == "Toca" || clothes.category == "Boina" || clothes.category == "Bandana" || clothes.category == "Natal")
                    {
                        hats.Add(count.ToString());
                    }
                    else if (clothes.category == "Oculus")
                    {
                        glasses.Add(count.ToString());
                    }
                    else if (clothes.category == "Uhr")
                    {
                        watches.Add(count.ToString());
                    }
                    else if (clothes.category == "Armband")
                    {
                        bracelets.Add(count.ToString());
                    }
                }
                count++;
            }
        }



        menu_item_list.Add(new { Type = 6, Name = "Hemden", Description = "Die Kosten für den Umstieg auf diesen Kleidungsstil betragen ~g~50 ~w~Drücke ~c~[ENTER]~w~ um zu kaufen.", List = shirt, StartIndex = 0 });
        menu_item_list.Add(new { Type = 6, Name = "Sweatshirts", Description = "Die Kosten für den Umstieg auf diesen Kleidungsstil betragen ~g~50 ~w~Drücke ~c~[ENTER]~w~ um zu kaufen.", List = moletons, StartIndex = 0 });
        menu_item_list.Add(new { Type = 6, Name = "Hosen", Description = "Die Kosten für den Umstieg auf diesen Kleidungsstil betragen ~g~50 ~w~Drücke ~c~[ENTER]~w~ um zu kaufen.", List = pants, StartIndex = 0 });
        menu_item_list.Add(new { Type = 6, Name = "Schuhe", Description = "Die Kosten für den Umstieg auf diesen Kleidungsstil betragen ~g~50 ~w~Drücke ~c~[ENTER]~w~ um zu kaufen.", List = shoes, StartIndex = 0 });
        menu_item_list.Add(new { Type = 6, Name = "Hut", Description = "Die Kosten für den Umstieg auf diesen Kleidungsstil betragen ~g~50 ~w~Drücke ~c~[ENTER]~w~ um zu kaufen.", List = hats, StartIndex = 0 });
        menu_item_list.Add(new { Type = 6, Name = "Brille", Description = "Die Kosten für den Umstieg auf diesen Kleidungsstil betragen ~g~50 ~w~Drücke ~c~[ENTER]~w~ um zu kaufen.", List = glasses, StartIndex = 0 });
        menu_item_list.Add(new { Type = 6, Name = "Halskette / Krawatten", Description = "Die Kosten für den Umstieg auf diesen Kleidungsstil betragen ~g~50 ~w~Drücke ~c~[ENTER]~w~ um zu kaufen.", List = neck, StartIndex = 0 });
        menu_item_list.Add(new { Type = 6, Name = "Uhr", Description = "Die Kosten für den Umstieg auf diesen Kleidungsstil betragen ~g~50 ~w~Drücke ~c~[ENTER]~w~ um zu kaufen.", List = watches, StartIndex = 0 });
        menu_item_list.Add(new { Type = 6, Name = "Armband", Description = "Die Kosten für den Umstieg auf diesen Kleidungsstil betragen ~g~50 ~w~Drücke ~c~[ENTER]~w~ um zu kaufen.", List = bracelets, StartIndex = 0 });

        player.SetData("Clothes_NewIndex_Shirt", -1);
        player.SetData("Clothes_NewIndex_Moleton", -1);
        player.SetData("Clothes_NewIndex_Pants", -1);
        player.SetData("Clothes_NewIndex_Shoes", -1);
        player.SetData("Clothes_NewIndex_Hats", -1);
        player.SetData("Clothes_NewIndex_Glasses", -1);
        player.SetData("Clothes_NewIndex_Neck", -1);
        player.SetData("Clothes_NewIndex_Watches", -1);
        player.SetData("Clothes_NewIndex_Bracelets", -1);

        InteractMenu.CreateMenu(player, "CLOTHES_MENU", "", "~g~", true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_lowendfashion2");

        //player.TriggerEvent("Display_Clothes", API.Shared.ToJson(shirt), API.Shared.ToJson(moletons), API.Shared.ToJson(pants), API.Shared.ToJson(shoes), API.Shared.ToJson(hats), API.Shared.ToJson(glasses));

        player.TriggerEvent("ps_BodyCamera");
    }



    public static void OnMenuReturnClose(Client player, String callbackId)
    {
        if (callbackId == "CLOTHES_MENU")
        {
            player.TriggerEvent("ps_DestroyCamera");
            player.TriggerEvent("Destroy_Character_Menu");
            Main.UpdatePlayerClothes(player);
        }
    }

    public static void SelectMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "CLOTHES_MENU")
        {

            switch (selectedIndex)
            {
                case 0:
                    {

                        if (player.GetData("Clothes_NewIndex_Shirt") == -1)
                        {
                            InteractMenu_New.SendNotificationError(player, "Sie müssen zuerst den zu kaufenden Artikel auswählen.");
                            //Update_Player_Clothes(player);
                            return;
                        }
                        BuyClothes(player, "shirt", player.GetData("Clothes_NewIndex_Shirt"));
                        break;
                    }
                case 1:
                    {
                        if (player.GetData("Clothes_NewIndex_Moleton") == -1)
                        {
                            InteractMenu_New.SendNotificationError(player, "Sie müssen zuerst den zu kaufenden Artikel auswählen.");
                            //Update_Player_Clothes(player);
                            return;
                        }
                        BuyClothes(player, "shirt", player.GetData("Clothes_NewIndex_Moleton"));
                        break;
                    }
                case 2:
                    {
                        if (player.GetData("Clothes_NewIndex_Pants") == -1)
                        {
                            InteractMenu_New.SendNotificationError(player, "Sie müssen zuerst den zu kaufenden Artikel auswählen.");
                            //Update_Player_Clothes(player);
                            return;
                        }
                        BuyClothes(player, "pants", player.GetData("Clothes_NewIndex_Pants"));
                        break;
                    }
                case 3:
                    {
                        if (player.GetData("Clothes_NewIndex_Shoes") == -1)
                        {
                            InteractMenu_New.SendNotificationError(player, "Sie müssen zuerst den zu kaufenden Artikel auswählen.");
                            //Update_Player_Clothes(player);
                            return;
                        }
                        BuyClothes(player, "shoes", player.GetData("Clothes_NewIndex_Shoes"));
                        break;
                    }
                case 4:
                    {
                        if (player.GetData("Clothes_NewIndex_Hats") == -1)
                        {
                            InteractMenu_New.SendNotificationError(player, "Sie müssen zuerst den zu kaufenden Artikel auswählen.");
                            //Update_Player_Clothes(player);
                            return;
                        }
                        BuyClothes(player, "hats", player.GetData("Clothes_NewIndex_Hats"));
                        break;
                    }
                case 5:
                    {
                        if (player.GetData("Clothes_NewIndex_Glasses") == -1)
                        {
                            InteractMenu_New.SendNotificationError(player, "Sie müssen zuerst den zu kaufenden Artikel auswählen.");
                            // Update_Player_Clothes(player);
                            return;
                        }
                        BuyClothes(player, "glasses", player.GetData("Clothes_NewIndex_Glasses"));
                        break;
                    }
                case 6:
                    {
                        if (player.GetData("Clothes_NewIndex_Neck") == -1)
                        {
                            InteractMenu_New.SendNotificationError(player, "Sie müssen zuerst den zu kaufenden Artikel auswählen.");
                            // Update_Player_Clothes(player);
                            return;
                        }
                        BuyClothes(player, "neck", player.GetData("Clothes_NewIndex_Neck"));
                        break;
                    }
                case 7:
                    {
                        if (player.GetData("Clothes_NewIndex_Watches") == -1)
                        {
                            InteractMenu_New.SendNotificationError(player, "Sie müssen zuerst den zu kaufenden Artikel auswählen.");
                            // Update_Player_Clothes(player);
                            return;
                        }
                        BuyClothes(player, "watches", player.GetData("Clothes_NewIndex_Watches"));
                        break;
                    }
                case 8:
                    {
                        if (player.GetData("Clothes_NewIndex_Bracelets") == -1)
                        {
                            InteractMenu_New.SendNotificationError(player, "Sie müssen zuerst den zu kaufenden Artikel auswählen.");
                            // Update_Player_Clothes(player);
                            return;
                        }
                        BuyClothes(player, "bracelets", player.GetData("Clothes_NewIndex_Bracelets"));
                        break;
                    }
            }
        }
    }


    public static void ListItemMenuResponse(Client player, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
        if (callbackId == "CLOTHES_MENU")
        {

            switch (selectedIndex)
            {
                case 0:
                    {
                        if (valueList == "Auswählen")
                        {
                            player.SetData("Clothes_NewIndex_Shirt", -1);
                            //Update_Player_Clothes(player);
                            return;
                        }
                        player.SetData("Clothes_NewIndex_Shirt", Convert.ToInt32(valueList));
                        Preview_Clothes(player, "shirt", Convert.ToInt32(valueList));
                        break;
                    }
                case 1:
                    {
                        if (valueList == "Auswählen")
                        {
                            player.SetData("Clothes_NewIndex_Moleton", -1);
                            //Update_Player_Clothes(player);
                            return;
                        }
                        player.SetData("Clothes_NewIndex_Moleton", Convert.ToInt32(valueList));
                        Preview_Clothes(player, "shirt", Convert.ToInt32(valueList));
                        break;
                    }
                case 2:
                    {
                        if (valueList == "Auswählen")
                        {
                            player.SetData("Clothes_NewIndex_Pants", -1);
                            //Update_Player_Clothes(player);
                            return;
                        }
                        player.SetData("Clothes_NewIndex_Pants", Convert.ToInt32(valueList));
                        Preview_Clothes(player, "pants", Convert.ToInt32(valueList));
                        break;
                    }
                case 3:
                    {
                        if (valueList == "Auswählen")
                        {
                            player.SetData("Clothes_NewIndex_Shoes", -1);
                            //Update_Player_Clothes(player);
                            return;
                        }
                        player.SetData("Clothes_NewIndex_Shoes", Convert.ToInt32(valueList));
                        Preview_Clothes(player, "shoes", Convert.ToInt32(valueList));
                        break;
                    }
                case 4:
                    {
                        if (valueList == "Auswählen")
                        {
                            player.SetData("Clothes_NewIndex_Hats", -1);
                            //Update_Player_Clothes(player);
                            return;
                        }
                        player.SetData("Clothes_NewIndex_Hats", Convert.ToInt32(valueList));
                        Preview_Clothes(player, "hats", Convert.ToInt32(valueList));
                        break;
                    }
                case 5:
                    {
                        if (valueList == "Auswählen")
                        {
                            player.SetData("Clothes_NewIndex_Glasses", -1);
                            //Update_Player_Clothes(player);
                            return;
                        }
                        player.SetData("Clothes_NewIndex_Glasses", Convert.ToInt32(valueList));
                        Preview_Clothes(player, "glasses", Convert.ToInt32(valueList));
                        break;
                    }
                case 6:
                    {
                        if (valueList == "Auswählen")
                        {
                            player.SetData("Clothes_NewIndex_Neck", -1);
                            //Update_Player_Clothes(player);
                            return;
                        }
                        player.SetData("Clothes_NewIndex_Neck", Convert.ToInt32(valueList));
                        Preview_Clothes(player, "neck", Convert.ToInt32(valueList));
                        break;
                    }
                case 7:
                    {
                        if (valueList == "Auswählen")
                        {
                            player.SetData("Clothes_NewIndex_Watches", -1);
                            //Update_Player_Clothes(player);
                            return;
                        }
                        player.SetData("Clothes_NewIndex_Watches", Convert.ToInt32(valueList));
                        Preview_Clothes(player, "watches", Convert.ToInt32(valueList));
                        break;
                    }
                case 8:
                    {
                        if (valueList == "Auswählen")
                        {
                            player.SetData("Clothes_NewIndex_Bracelets", -1);
                            //Update_Player_Clothes(player);
                            return;
                        }
                        player.SetData("Clothes_NewIndex_Bracelets", Convert.ToInt32(valueList));
                        Preview_Clothes(player, "bracelets", Convert.ToInt32(valueList));
                        break;
                    }
            }
        }
    }

    //  acessories.Add(new { sex = 0, category = "Boina", component = 0, draw = 7, variation = 4});

    // Masculino: Boné, Chapéu, Toca, Boina, Bandana, Natal
    // Sex: Boné, Toca, Boina, Chapeu, Item de Natal

    [RemoteEvent("Buy_Clothes")]
    public static void BuyClothes(Client player, string category, int item_id)
    {

        var business_id = Business.GetPlayerInBusinessInType(player, 1);
        if (business_id == -1)
        {
            Main.SendErrorMessage(player, "Sie befinden sich nicht in einer Firma.");
            //ClothesCloseMenu(player);
            return;
        }

        int item_price = 50;

        if (item_id == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Wir konnten Ihre Anfrage nicht bearbeiten. Sie müssen zunächst eine Art von Element auswählen.");
            //player.TriggerEvent("show_menu_shirts", 0);
            //ClothesCloseMenu(player);
        }
        else
        {
            if (Main.GetPlayerMoney(player) < item_price)
            {
                NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Der Artikel, den Sie zu kaufen versuchen, kostet $" + item_price + ", sie haben nicht genug Geld in Ihren Händen.");
                //ClothesCloseMenu(player);
                return;
            }

            //Business safe and Inventory stuffs
            if (Business.business_list[business_id].business_OwnerID != -1)
            {
                if (Business.business_list[business_id].business_Inventory > 0)
                {
                    Business.business_list[business_id].business_Safe += (item_price / 100 * 50);
                    Business.business_list[business_id].business_Inventory -= 1;
                    Business.SaveBusiness(business_id);
                    Business.UpdateBusinessLabel(business_id);
                }
                else
                {
                    NAPI.Notification.SendNotificationToPlayer(player, "[" + Business.business_list[business_id].business_Name + "]:~w~ Unser Unternehmen hat momentan nichts auf Lager, bitte kommen Sie später wieder!");
                    //ClothesCloseMenu(player);
                    return;
                }
            }

            Main.GivePlayerMoney(player, -item_price);

            string item_name = "indefinido";
            if (category == "shirt")
            {
                player.SetSharedData("character_torso", clothes_list[item_id].clothe_Torso);
                player.SetSharedData("character_undershirt", clothes_list[item_id].clother_UnderShirt);
                player.SetSharedData("character_undershirt_texture", clothes_list[item_id].clother_UnderShirtTexture);
                player.SetSharedData("character_shirt", clothes_list[item_id].clothe_Id);
                player.SetSharedData("character_shirt_texture", clothes_list[item_id].clothe_Texture);
                item_name = clothes_list[item_id].clothe_Name;
            }
            else if (category == "pants")
            {
                player.SetSharedData("character_leg", clothes_list[item_id].clothe_Id);
                player.SetSharedData("character_leg_texture", clothes_list[item_id].clothe_Texture);
                player.SetData("character_outfit", -1);
                item_name = clothes_list[item_id].clothe_Name;
            }
            else if (category == "shoes")
            {
                player.SetSharedData("character_feet", clothes_list[item_id].clothe_Id);
                player.SetSharedData("character_feet_texture", clothes_list[item_id].clothe_Texture);
                item_name = clothes_list[item_id].clothe_Name;
            }
            else if (category == "hats")
            {
                player.SetSharedData("character_hats", acessories[item_id].draw);
                player.SetSharedData("character_hats_texture", acessories[item_id].variation);
                item_name = acessories[item_id].category;
            }
            else if (category == "glasses")
            {
                player.SetSharedData("character_glasses", acessories[item_id].draw);
                player.SetSharedData("character_glasses_texture", acessories[item_id].variation);
                item_name = acessories[item_id].category;
            }
            else if (category == "neck")
            {
                player.SetSharedData("character_accessories", clothes_list[item_id].clothe_Id);
                player.SetSharedData("character_accessories_texture", clothes_list[item_id].clothe_Texture);
                item_name = clothes_list[item_id].clothe_Name;
            }
            else if (category == "watches")
            {
                player.SetSharedData("character_watches", acessories[item_id].draw);
                player.SetSharedData("character_watches_texture", acessories[item_id].variation);
                item_name = acessories[item_id].category;
            }
            else if (category == "bracelets")
            {
                player.SetSharedData("character_bracelets", acessories[item_id].draw);
                player.SetSharedData("character_bracelets_texture", acessories[item_id].variation);
                item_name = acessories[item_id].category;
            }
            NAPI.Notification.SendNotificationToPlayer(player, "~y~[" + Business.business_list[business_id].business_Name + "]:~w~ Du hast einen " + item_name + " von ~y~" + Business.business_list[business_id].business_Name + "~w~ für ~g~$" + item_price + " gekauft.");
            //Main.UpdatePlayerClothes(player);
        }

    }

    [RemoteEvent("Clothes_Menu_Destroy")]
    public static void ClothesCloseMenu(Client player)
    {
        player.TriggerEvent("ps_DestroyCamera");
        player.TriggerEvent("Destroy_Character_Menu");
        Main.UpdatePlayerClothes(player);
    }


    [RemoteEvent("Update_Player_Clothes")]
    public static void Update_Player_Clothes(Client player)
    {
        Main.UpdatePlayerClothes(player);
    }
}
